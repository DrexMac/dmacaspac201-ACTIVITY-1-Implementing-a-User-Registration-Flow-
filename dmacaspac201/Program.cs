using AutoMapper;
using dmacaspac201.Contracts;
using dmacaspac201.Contracts.LoginInfo;
using dmacaspac201.Contracts.Users;
using dmacaspac201.EntityFramework;
using dmacaspac201.MySql;
using dmacaspac201.Services;
using dmacaspac201.Services.BaseServices;
using Microsoft.AspNetCore.Authentication.Cookies; // Add this using directive
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure the database context
builder.Services.AddDbContext<DefaultDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 3))));

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Register repositories and services
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ILoginInfoService, LoginInfoService>();
builder.Services.AddScoped<IUserService, UserService>();

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Accounts/Login"; // Set the login path
        options.LogoutPath = "/Accounts/Logout"; // Set the logout path
        options.AccessDeniedPath = "/Accounts/AccessDenied"; // Set the access denied path
    });

// Add authorization
builder.Services.AddAuthorization();

// Add Razor Pages and Controllers
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Use authentication and authorization middleware
app.UseAuthentication(); // Add this line
app.UseAuthorization();

// Add the default route to redirect to the login page
app.MapGet("/", () => Results.Redirect("Components/Accounts/Login")); // Redirect root URL to login page

app.MapRazorPages();
app.MapControllers();

app.Run();