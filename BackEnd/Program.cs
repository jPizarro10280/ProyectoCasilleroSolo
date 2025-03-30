using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI
builder.Services.AddDbContext<CasilleroProyectoContext>();

builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();

builder.Services.AddScoped<IDetalleFacturaService, DetalleFacturaService>();
builder.Services.AddScoped<IDetalleFacturaDAL, DetalleFacturaDAL>();

builder.Services.AddScoped<IDireccionService, DireccionService>();
builder.Services.AddScoped<IDireccionDAL, DireccionDAL>();

builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IFacturaDAL, FacturaDAL>();

builder.Services.AddScoped<IPaqueteService, PaqueteService>();
builder.Services.AddScoped<IPaqueteDAL, PaqueteDAL>();

builder.Services.AddScoped<IPrealertaPaqueteService, PrealertaPaqueteService>();
builder.Services.AddScoped<IPrealertaPaqueteDAL, PrealertaPaqueteDAL>();

builder.Services.AddScoped<IPrealertumService, PrealertumService>();
builder.Services.AddScoped<IPrealertumDAL, PrealertumDAL>();

builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IRolDAL, RolDAL>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioDAL, UsuarioDAL>();

builder.Services.AddScoped<IUsuarioRolService, UsuarioRolService>();
builder.Services.AddScoped<IUsuarioRolDAL, UsuarioRolDAL>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
