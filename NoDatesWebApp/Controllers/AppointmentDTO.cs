using System.ComponentModel.DataAnnotations;

namespace NoDatesWebApp.Controllers;

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
