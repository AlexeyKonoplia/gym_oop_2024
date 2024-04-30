using Microsoft.AspNetCore.Mvc;
using gym_oop_2024.Application.Models;
using gym_oop_2024.Application.Models.Models.Interfaces;

namespace gym_oop_2024.Presentation.Http.Controllers;

public class SubscriptionController: ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet("{id}")]
    public ActionResult<Subscription> Get(Guid id)
    {
        var subscription = _subscriptionService.GetById(id);
        if (subscription == null)
        {
            return NotFound();
        }

        return Ok(subscription);
    }
    
    [HttpPost]
    public ActionResult<Subscription> Post(Subscription subscription)
    {
        if (subscription == null)
        {
            return BadRequest();
        }

        var createdSubscription = _subscriptionService.Add(subscription);
        return CreatedAtAction(nameof(Get), new { id = subscription.SubscriptionId }, createdSubscription);
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        try
        {
            var subscritpion = _subscriptionService.GetById(id);
            if (subscritpion == null)
            {
                return NotFound();
            }

            _subscriptionService.Remove(id);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
    [HttpPut("{id}")]
    public IActionResult UpdateSubscription(Guid id, Subscription updatedSubscription)
    {
        if (id != updatedSubscription.SubscriptionId)
        {
            return BadRequest();
        }

        try
        {
            var existingSubscription = _subscriptionService.GetById(id);
            if (existingSubscription == null)
            {
                return NotFound();
            }

            _subscriptionService.Update(id, existingSubscription);
            return NoContent();
        }
        catch (Exception)
        {
            // Обработка исключения
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}