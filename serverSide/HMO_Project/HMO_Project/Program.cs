using HMO_Project.Api.Mapping;
using HMO_Project.Api.Validation;
using HMO_Project.Core.IRepositpries;
using HMO_Project.Core.IServices;
using HMO_Project.Core.Mapping;
using HMO_Project.Service.Services;
using HMO_Project_Data;
using HMO_Project_Data.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//cycles issue
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//auto mapper
builder.Services.AddAutoMapper(typeof(MapEntityToDto), typeof(MapModelToEntity));

//dependency injection
builder.Services.AddScoped<IKoronaDiseasesRepository,KoronaDiseasesRepository>();
builder.Services.AddScoped<IKoronaDiseasesService, KoronaDiseasesService>();
builder.Services.AddScoped<IMembersRepository, MembersRepository>();
builder.Services.AddScoped<IMembersService, MembersService>();
builder.Services.AddScoped<IVaccinationsRepository,VaccinationsRepository>();
builder.Services.AddScoped<IVaccinationsService,VaccinationsService>();
builder.Services.AddScoped<IVaccineProducersRepository,VaccineProducersRepository>();
builder.Services.AddScoped<IVaccineProducersService,VaccineProducersService>();
builder.Services.AddScoped<IValidationKoronaDisease, ValidationKoronaDisease>();
builder.Services.AddScoped<IValidationVaccination, ValidationVacccination>();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddCors(opt => opt.AddPolicy("MyPolicy", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
