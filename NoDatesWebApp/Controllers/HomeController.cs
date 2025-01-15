using Microsoft.AspNetCore.Mvc;
using NoDatesWebApp.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace NoDatesWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

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

// AppointmentDTO.cs
public class AppointmentDTO
{
    [Required]
    [Range(2000, 2100)]
    public int StartYear { get; set; }

    [Required]
    [Range(1, 12)]
    public int StartMonth { get; set; }

    [Required]
    [Range(1, 31)]
    public int StartDay { get; set; }

    [Required]
    [Range(0, 23)]
    public int StartHour { get; set; }

    [Required]
    [Range(0, 59)]
    public int StartMinute { get; set; }

    [Required]
    [Range(2000, 2100)]
    public int EndYear { get; set; }

    [Required]
    [Range(1, 12)]
    public int EndMonth { get; set; }

    [Required]
    [Range(1, 31)]
    public int EndDay { get; set; }

    [Required]
    [Range(0, 23)]
    public int EndHour { get; set; }

    [Required]
    [Range(0, 59)]
    public int EndMinute { get; set; }
}

// AppointmentService.cs
public class AppointmentService
{
    private readonly AppDbContext _context;

    public AppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task Create(AppointmentDTO dto)
    {
        ValidateDateTime(dto.StartYear, dto.StartMonth, dto.StartDay, dto.StartHour, dto.StartMinute);
        ValidateDateTime(dto.EndYear, dto.EndMonth, dto.EndDay, dto.EndHour, dto.EndMinute);

        var appointment = new Appointment
        {
            StartYear = dto.StartYear,
            StartMonth = dto.StartMonth,
            StartDay = dto.StartDay,
            StartHour = dto.StartHour,
            StartMinute = dto.StartMinute,
            EndYear = dto.EndYear,
            EndMonth = dto.EndMonth,
            EndDay = dto.EndDay,
            EndHour = dto.EndHour,
            EndMinute = dto.EndMinute
        };

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task Update(int id, AppointmentDTO dto)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            throw new ArgumentException("Appointment not found.");
        }

        ValidateDateTime(dto.StartYear, dto.StartMonth, dto.StartDay, dto.StartHour, dto.StartMinute);
        ValidateDateTime(dto.EndYear, dto.EndMonth, dto.EndDay, dto.EndHour, dto.EndMinute);

        appointment.StartYear = dto.StartYear;
        appointment.StartMonth = dto.StartMonth;
        appointment.StartDay = dto.StartDay;
        appointment.StartHour = dto.StartHour;
        appointment.StartMinute = dto.StartMinute;
        appointment.EndYear = dto.EndYear;
        appointment.EndMonth = dto.EndMonth;
        appointment.EndDay = dto.EndDay;
        appointment.EndHour = dto.EndHour;
        appointment.EndMinute = dto.EndMinute;

        await _context.SaveChangesAsync();
    }

    private void ValidateDateTime(int year, int month, int day, int hour, int minute)
    {
        bool isValid = true;

        if (year < 1 || month < 1 || month > 12 || day < 1 || day > DateTime.DaysInMonth(year, month) || hour < 0 || hour > 23 || minute < 0 || minute > 59)
        {
            isValid = false;
        }

        if (!isValid)
        {
            throw new ArgumentException("Invalid date and time values.");
        }
    }
}

// Appointment.cs
public class Appointment
{
    public int Id { get; set; }
    public int StartYear { get; set; }
    public int StartMonth { get; set; }
    public int StartDay { get; set; }
    public int StartHour { get; set; }
    public int StartMinute { get; set; }
    public int EndYear { get; set; }
    public int EndMonth { get; set; }
    public int EndDay { get; set; }
    public int EndHour { get; set; }
    public int EndMinute { get; set; }
}
