using ArmoblaProject.Models; // Asegúrate de tener este namespace correcto
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml; // <-- Necesario para ExcelPackage.LicenseContext

var builder = WebApplication.CreateBuilder(args);

// Establecer el contexto de licencia para EPPlus
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

// 1. Agregar DbContext con PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<ExcelWriterService>();

// 2. Habilitar controladores con vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 4. Definición de rutas por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
