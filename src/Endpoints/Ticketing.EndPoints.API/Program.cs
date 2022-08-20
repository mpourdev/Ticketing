using Microsoft.EntityFrameworkCore;
using Ticketing.Core.ApplicationServices;
using Ticketing.Core.ApplicationServices.IServices;
using Ticketing.Core.ApplicationServices.Services;
using Ticketing.Core.Domain.Tickets.Data;
using Ticketing.EndPoints.API;
using Ticketing.Infrastructures.Data.SqlServer;
using Ticketing.Infrastructures.Data.SqlServer.Tickets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TicketingDbContext>(c =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("TicketingConnection")));


builder.Services.AddScoped<ITicketRepository, EfTicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dataContext = scope.ServiceProvider.GetRequiredService<TicketingDbContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();


dataContext.Database.Migrate();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCustomDeveloperExceptionHandler(logger);
}
else
{
    app.UseCustomExceptionHandler(logger);
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
