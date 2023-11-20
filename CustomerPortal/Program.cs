using BLL.LogicServices;
using DAL.DataContext;
using DAL.DataServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IStudentsLogic, StudentsLogic>(); // Dependency Injection
builder.Services.AddSingleton<IStudentDataDAL, StudentDataDAL>(); // Dependency Injection
builder.Services.AddSingleton<IDapperOrmHelper, DapperOrmHelper>(); // Dependency Injection

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default hi HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
