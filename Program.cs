using Microsoft.EntityFrameworkCore;
using LeapYear.Interfaces;
using LeapYear.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<YearFormContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LeapYearDB")));

builder.Services.AddTransient<ILeapYearInterface, LeapYearInterface>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();