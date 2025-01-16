using Microsoft.AspNetCore.Mvc;

namespace NoDatesWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly AppointmentService _appointmentService;

    public AppointmentController(AppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(AppointmentDTO appointmentDto)
    {
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        try
        {
            await _appointmentService.Create(appointmentDto);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, AppointmentDTO appointmentDto)
    {
        //if (!ModelState.IsValid)
        //{
        //    return BadRequest(ModelState);
        //}

        try
        {
            await _appointmentService.Update(id, appointmentDto);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
