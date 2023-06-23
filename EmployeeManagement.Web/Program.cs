using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Web.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EmployeeManagementWebContextConnection") ?? throw new InvalidOperationException("Connection string 'EmployeeManagementWebContextConnection' not found.");

builder.Services.AddDbContext<EmployeeManagementWebContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<EmployeeManagementWebContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAutoMapper(typeof(EmployeeProfile));
/* while adding Https client services in dependency container, specify the base address of the api
 * This piece of code adds both the .net services i.e HttpsClient and 
 * our own services IEmployeeService, EmployeeServices into the dependency injection container.
 */
builder.Services.AddHttpClient<IEmployeeService, EmployeeService>( client =>
 {
    client.BaseAddress = new Uri("https://localhost:7159/");
});
builder.Services.AddHttpClient<IDepartmentService, DepartmentService>( client =>
{
    client.BaseAddress = new Uri("https://localhost:7159/");
});

builder.Services.AddLogging( logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;

app.Run();
