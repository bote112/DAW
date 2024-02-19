using bca.Data;
using bca.Models;
using bca.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Adaugă serviciile necesare
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Înregistrează repository-urile
builder.Services.AddScoped<IRepositoryBase<Actori>, ActorRepository>();
builder.Services.AddScoped<IRepositoryBase<Filme>, FilmeRepository>();
builder.Services.AddScoped<IRepositoryBase<FilmActor>, FilmActorRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Configurează rutarea
app.UseRouting();

app.MapControllerRoute(
    name: "actori",
    pattern: "actori/{action=Index}/{id?}",
    defaults: new { controller = "Actori" });

app.MapControllerRoute(
    name: "filme",
    pattern: "filme/{action=Index}/{id?}",
    defaults: new { controller = "Filme" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
