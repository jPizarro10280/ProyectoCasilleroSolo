using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region
builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IDetalleFacturaHelper, DetalleFacturaHelper>();
builder.Services.AddScoped<IDireccionHelper, DireccionHelper>();
builder.Services.AddScoped<IFacturaHelper, FacturaHelper>();
builder.Services.AddScoped<IPaqueteHelper, PaqueteHelper>();
builder.Services.AddScoped<IPrealertaPaqueteHelper, PrealertaPaqueteHelper>();
builder.Services.AddScoped<IPrealertumHelper, PrealertumHelper>();
builder.Services.AddScoped<IRolHelper, RolHelper>();
builder.Services.AddScoped<IUsuarioRolHelper, UsuarioRolHelper>();
builder.Services.AddScoped<IUsuarioHelper, UsuarioHelper>();
#endregion

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
