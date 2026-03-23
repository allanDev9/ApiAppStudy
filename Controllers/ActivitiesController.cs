using ApiAppStudy.DTOs;
using ApiAppStudy.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppStudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly IActivityService _service;

    public ActivitiesController(IActivityService service)
    {
        _service = service;
    }

    // GET: api/activities
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityDto>>> GetAll()
    {
        var activities = await _service.GetAllAsync();
        return Ok(activities);
    }

    // GET: api/activities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityDto>> GetById(int id)
    {
        var activity = await _service.GetByIdAsync(id);
        if (activity is null) return NotFound(
            new
            {
                Message = "La actividad con el ID especificado no existe."
            }
        );
        return Ok(activity);
    }

    // POST: api/activities
    [HttpPost]
    public async Task<ActionResult<ActivityDto>> Create(CreateActivityDto createDto)
    {
        var activity = await _service.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = activity.Id }, activity);
    }

    // PUT: api/activities/5
    [HttpPut("{id}")]
    public async Task<ActionResult<ActivityDto>> Update(int id, UpdateActivityDto updateDto)
    {
        var activity = await _service.UpdateAsync(id, updateDto);
        if (activity is null) return NotFound(
            new
            {
                Message = "La actividad con el ID especificado no existe y no se puede actualizar."
            }
        );
        return Ok(activity);
    }

    // DELETE: api/activities/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
