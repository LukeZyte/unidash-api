using Microsoft.EntityFrameworkCore;
using UniDash.API.Data;
using UniDash.API.Mappings;
using UniDash.API.Repositories.EventRepository;
using UniDash.API.Repositories.EventTypeRepository;
using UniDash.API.Repositories.FriendshipRepository;
using UniDash.API.Repositories.UserRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UniDashDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("UniDashConnectionString")));

builder.Services.AddScoped<IUserRepository, SQLUserRepository>();
builder.Services.AddScoped<IEventRepository, SQLEventRepository>();
builder.Services.AddScoped<IEventTypeRepository, SQLEventTypeRepository>();
builder.Services.AddScoped<IFriendshipRepository, SQLFriendshipRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
