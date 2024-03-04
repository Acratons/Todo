//WebApplication ���� Program.cs �����ú����� ASP.NET Core Ӧ�ó����Ĭ�Ϸ�ʽ
using Microsoft.EntityFrameworkCore;
using MyToDo.Api.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//��������sqlite
builder.Services.AddDbContext<MyToDoContext>(options =>
{
    //appsetting�е�����
    var connectionString = builder.Configuration.GetConnectionString("ToDoConnection");
    options.UseSqlite(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//����Ӧ�ó�����������ܵ���һϵ���м��

app.UseAuthorization();

app.MapControllers();

app.Run();