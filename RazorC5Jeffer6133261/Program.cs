using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("RazorC3Jeffer6133261Context") ?? throw new InvalidOperationException("Connection string 'RazorC3Jeffer6133261Context' not found.");

builder.Services.AddDbContext<RazorC3Jeffer6133261Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RazorC3Jeffer6133261Context")));

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
