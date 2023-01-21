using AutoMapper;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ResumeBuilder.Api.Profiles;
using ResumeBuilder.Data.Context;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<ResumeBuilderDbContext>(ob => ob.UseInMemoryDatabase(databaseName: "ResumeBuilder"));


builder.Services.AddAutoMapper(c => {
    c.AddProfile<ContactProfile>();
    c.AddProfile<ResumeProfile>();
    c.AddProfile<SkillProfile>();
});


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


