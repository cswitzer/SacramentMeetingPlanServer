using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacramentMeetingPlannerServer.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SacramentMeetingPlannerServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SacramentMeetingPlannerServerContext") ?? throw new InvalidOperationException("Connection string 'SacramentMeetingPlannerServerContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SacramentMeetingPlannerServerContext>();
    DbHymnInitializer.Initialize(dbContext);
    DbMemberInitializer.Initialize(dbContext);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
