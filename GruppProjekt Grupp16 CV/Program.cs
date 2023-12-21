using GruppProjekt_Grupp16_CV.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CvContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("CvContext")));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (CvContext cvContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<CvContext>())
{
    cvContext.Status.RemoveRange(cvContext.Status);

    cvContext.Status.Add(new Status
    {
        Title = "Offentlig"
    });

    cvContext.Status.Add(new Status
    {
        Title = "Privat"
    });

    Console.WriteLine("Saving Data...");
    try
    {
        cvContext.SaveChanges();
        Console.WriteLine($"Saved! {cvContext.Status.Count()}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

app.Run();