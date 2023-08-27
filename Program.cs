using Microsoft.EntityFrameworkCore;
using WebApplicationwithApiAndAngular.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options=>

    options.UseSqlServer(builder.Configuration.GetConnectionString("Places")));


builder.Services.AddEndpointsApiExplorer(); // generates description for all endpoints
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));
}); // gen openAi specification


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseRouting();

app.UseSwagger(); // create endpoint for swagger.json
app.UseSwaggerUI(); //create swagger UI for testing all web api endpoints / action method

app.UseAuthorization();

app.MapControllers();

app.Run();
