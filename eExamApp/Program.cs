using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Repository;
using eExam.Core.Interfaces;
using eExam.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbConnection"));
});
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ICourseRepository,CourseRepository>();
builder.Services.AddScoped<ICourseService,CourseService>();



builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
