using Microsoft.EntityFrameworkCore;
using BCTECHAPI.Infrastructure.Data;
using ServicesExtension;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BCTECHAPI")));

// Services
builder.Services.AddDependencies();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
