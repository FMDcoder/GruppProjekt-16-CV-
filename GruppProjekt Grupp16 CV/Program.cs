using GruppProjekt_Grupp16_CV;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CvContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("CvContext")));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<CvContext>().AddDefaultTokenProviders();

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

using (CvContext cvContext = app.Services.CreateScope()
        .ServiceProvider.GetRequiredService<CvContext>())
{
    if (cvContext.Status.Count() == 0)
    {
        DataHandler.uploadData(cvContext);
    }
}

app.Run();