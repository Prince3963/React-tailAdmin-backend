using Microsoft.EntityFrameworkCore;
using MyDummyAPI.Data;
using MyDummyAPI.Mappings;
using MyDummyAPI.Repositories.Implementations;
using MyDummyAPI.Repositories.Interfaces;
using MyDummyAPI.Services.Implementations;
using MyDummyAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(ProjectMapping));

builder.Services.AddScoped<IUser, UserRepo>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IProfileRepo, ProfileRepo>();
builder.Services.AddScoped<IProfileServices, ProfileServices>();
builder.Services.AddScoped<IPartnerRepo, PartnerRepo>();
builder.Services.AddScoped<IPartnerServices, PartnerServices>();
builder.Services.AddScoped<IProjectServices, ProjectServices>();
builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
builder.Services.AddScoped<IBranchRepo, BranchRepo>();
builder.Services.AddScoped<IBranchServices, BranchServices>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("DefaultPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
