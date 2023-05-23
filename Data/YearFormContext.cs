using Microsoft.EntityFrameworkCore;
using LeapYear.Form;

public class YearFormContext : DbContext
{
    public DbSet<YearForm> YearForm { get; set; }
    public YearFormContext(DbContextOptions options) : base(options) { }

}