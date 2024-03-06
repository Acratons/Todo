//WebApplication ���� Program.cs �����ú����� ASP.NET Core Ӧ�ó����Ĭ�Ϸ�ʽ
using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MyToDo.Api.Context;
using MyToDo.Api.Context.Repository;

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
}).AddUnitOfWork<MyToDoContext>()
.AddCustomRepository<ToDo,ToDoRepository>()
.AddCustomRepository<Memo, MemoRepository>()
.AddCustomRepository<User, UserRepository>();//����ע�빤����Ԫ

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//����Ӧ�ó����������ܵ���һϵ���м��

app.UseAuthorization();

app.MapControllers();

app.Run();