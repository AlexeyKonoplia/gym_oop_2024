using Microsoft.AspNetCore.Mvc;
using GymOop2024.Application.Models;
using GymOop2024.Application.Models.Models.Entities;
using GymOop2024.Application.Models.Models.Interfaces;


namespace gym_oop_2024.Presentation.Http.Controllers;

public class UserSubscriptionController: ControllerBase
{
    private readonly IUserSubscriptionServices _userSubscriptionService;

    public UserSubscriptionController(IUserSubscriptionServices userSubscriptionService)
    {
        _userSubscriptionService = userSubscriptionService;
    }

    [HttpGet("{id}")]
    public ActionResult<Gym> Get(Guid id)
    {
        var gym = _userSubscriptionService.GetUserSubscriptionByUserId(id);

        return Ok(gym);
    }
    
    [HttpPost]
    public ActionResult<UserSubscription> Post(UserSubscription userSubscription)
    {
        if (userSubscription == null)
        {
            return BadRequest();
        }
        var createdUserSub = _userSubscriptionService.AddUserSubscription(userSubscription);
        return CreatedAtAction(nameof(Get), new { id = userSubscription.UserSubscriptionId }, createdUserSub);
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        try
        {
            var userSubscription = _userSubscriptionService.GetUserSubscriptionByUserId(id);

            _userSubscriptionService.DeleteUserSubscription(userSubscription);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    [HttpPut("{id}")]
    public IActionResult UpdateUserSubscription(Guid id, UserSubscription updatedUserSub)
    {
        if (id != updatedUserSub.UserSubscriptionId)
        {
            return BadRequest();
        }

        try
        {
            var existGym = _userSubscriptionService.GetUserSubscriptionByUserId(id);

            _userSubscriptionService.UpdateUserSubscription(id, updatedUserSub);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}