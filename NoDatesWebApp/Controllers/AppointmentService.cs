using NoDatesWebApp.Data;

namespace NoDatesWebApp.Controllers;

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

        var appointment = new Appointment(
            dto.StartYear,
            dto.StartMonth,
            dto.StartDay,
            dto.StartHour,
            dto.StartMinute,
            dto.EndYear,
            dto.EndMonth,
            dto.EndDay,
            dto.EndHour,
            dto.EndMinute);

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
