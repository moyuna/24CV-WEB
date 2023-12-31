using _24CV_WEB.Models;
using _24CV_WEB.Repository;
using _24CV_WEB.Services;
using _24CV_WEB.Services.Contracts;
using _24CV_WEB.Services.ContractServices;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<AspNetUser,AspNetRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

builder.Services.AddAuthentication("Cookies").AddCookie("Cookies",
    options =>
    {
        options.LoginPath= "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
     
    }).AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
    {
        options.ClientId = "373830147324-lj621nvljt8ds2sc7sl82289nfnasbe5.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<ICurriculumService, CurriculumService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
