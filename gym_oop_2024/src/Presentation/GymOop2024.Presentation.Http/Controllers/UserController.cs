using GymOop2024.Application.Models.Models.Entities;
using GymOop2024.Application.Models.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gym_oop_2024.Presentation.Http.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public ActionResult<User> Get(Guid id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> Post(User user)
    {
        if (user == null)
        {
            return BadRequest();
        }

        var createdSubscription = _userService.Add(user);
        return CreatedAtAction(nameof(Get), new { id = user.UserId }, createdSubscription);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        try
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, User updatedUser)
    {
        try
        {
            if (updatedUser == null)
            {
                return NotFound();
            }

            _userService.UpdateUser(id, updatedUser);
            return NoContent();
        }
        catch (Exception)
        {
            // Обработка исключения
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}