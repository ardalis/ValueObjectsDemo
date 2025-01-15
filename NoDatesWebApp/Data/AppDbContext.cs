using Microsoft.EntityFrameworkCore;
using NoDatesWebApp.Controllers;

namespace NoDatesWebApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Appointment> Appointments => Set<Appointment>();
}