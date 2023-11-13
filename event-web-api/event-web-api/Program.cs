using AutoMapper;
using Contracts.Managers;
using Contracts.Services;
using event_web_api.BLL.Managers;
using event_web_api.BLL.Mapper;
using event_web_api.BLL.Service;
using event_web_api.DAL.EF;
using event_web_api.DAL.Managers;
using event_web_api.Extensions;
using event_web_api.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EventContext>(options =>
                             options.UseSqlServer(builder.Configuration.GetConnectionString("EventsDatabase")));
builder.Services.AddDbContext<UserContext>(options =>
                             options.UseSqlServer(builder.Configuration.GetConnectionString("UsersDatabase")));

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

var config = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile>
    {
        new SpeakerProfile(),
        new EventProfile(),
        new UserProfile()
    }));

builder.Services.AddScoped<IMapper>(x => new Mapper(config));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<ISpeakerService, SpeakerService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();

builder.Services.ConfigureSwagger();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MigrateDatabase<EventContext>();
app.MigrateDatabase<UserContext>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
