using SelectSencillo.Datos.Contrato;
using SelectSencillo.Datos.Implementacion;
using SelectSencillo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IGenericDatos<Categoria>,CategoriasDatos>();
builder.Services.AddScoped<IGenericDatos<Usuario>,UsuarioDatos>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Guardar}/{id?}");

app.Run();
