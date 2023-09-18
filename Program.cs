using DependencyInjectionSample.Classes;
using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IOperationTransient, Operation>();    // PerClass - 
builder.Services.AddScoped<IOperationScoped, Operation>();          // PerRequest - the instance is isolated per requests
builder.Services.AddSingleton<IOperationSingleton, Operation>();    // Once - when the app loads. single instance for all requests

builder.Services.AddTransient<IOperationService, OperationService>();

builder.Services.AddControllersWithViews();





var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();