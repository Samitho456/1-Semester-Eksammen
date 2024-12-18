using hillerodLib.Services.Repos;
using hillerodLib.Models;
using hillerodLib.Exceptions;
using hillerodLib.Enums;
using hillerodLib.MockData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(MockData._boatRepo);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
