namespace NoDatesWebApp.Controllers;

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

    public Appointment(int startYear, int startMonth, int startDay, int startHour, int startMinute,
                       int endYear, int endMonth, int endDay, int endHour, int endMinute)
    {
        ValidateDateTime(startYear, startMonth, startDay, startHour, startMinute);
        ValidateDateTime(endYear, endMonth, endDay, endHour, endMinute);

        StartYear = startYear;
        StartMonth = startMonth;
        StartDay = startDay;
        StartHour = startHour;
        StartMinute = startMinute;
        EndYear = endYear;
        EndMonth = endMonth;
        EndDay = endDay;
        EndHour = endHour;
        EndMinute = endMinute;
    }

    private void ValidateDateTime(int year, int month, int day, int hour, int minute)
    {
        if (year < 1 || month < 1 || month > 12 || day < 1 || day > DateTime.DaysInMonth(year, month) ||
            hour < 0 || hour > 23 || minute < 0 || minute > 59)
        {
            throw new ArgumentException("Invalid date and time values.");
        }
    }
}
