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

// localhost 3000 is allowed to make request (make sure to change to "*" later)
builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:3000")));

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

// add this line of code to activate cors
app.UseCors();

app.Run();
