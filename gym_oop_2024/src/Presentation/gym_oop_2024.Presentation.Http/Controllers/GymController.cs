using Microsoft.AspNetCore.Mvc;
using gym_oop_2024.Application.Models;
using gym_oop_2024.Application.Models.Models.Interfaces;

namespace gym_oop_2024.Presentation.Http.Controllers;

public class GymController: ControllerBase
{
    private readonly IGymService _gymService;

    public GymController(IGymService gymService)
    {
        _gymService = gymService;
    }

    [HttpGet("{id}")]
    public ActionResult<Gym> Get(Guid id)
    {
        var gym = _gymService.GetGymById(id);

        return Ok(gym);
    }
    
    [HttpPost]
    public ActionResult<Gym> Post(Gym gym)
    {

        var createdGym = _gymService.AddGym(gym);
        return CreatedAtAction(nameof(Get), new { id = gym.GymId }, createdGym);
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        try
        {
            var gym = _gymService.GetGymById(id);

            _gymService.RemoveGym(gym);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    [HttpPut("{id}")]
    public IActionResult UpdateGym(Guid id, Gym updatedGym)
    {
        if (id != updatedGym.GymId)
        {
            return BadRequest();
        }

        try
        {
            var existGym = _gymService.GetGymById(id);

            _gymService.UpdateGym(id, updatedGym);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}