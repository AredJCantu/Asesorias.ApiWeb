using AsesoriasAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("conexion");
builder.Services.AddDbContext<AsesoriasContext>(
           optionsBuilder => optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AsesoriasContext>();
    context.Database.EnsureCreated();
}


app.Run();
