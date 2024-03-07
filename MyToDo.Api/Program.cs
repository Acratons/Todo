//WebApplication ���� Program.cs �����ú����� ASP.NET Core Ӧ�ó����Ĭ�Ϸ�ʽ
using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyToDo.Api.Context;
using MyToDo.Api.Context.Repository;
using MyToDo.Api.Extention;
using MyToDo.Api.Service;
using MyToDo.share.Dtos;

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


//ע��service
builder.Services.AddTransient<IToDoService, ToDoService>();


//�������AutoMapper�ķ���
var autoConfiguration = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<ToDo, ToDoDto>().ReverseMap();
    //cfg.CreateMap<Memo, MemoDto>().ReverseMap();
    //cfg.CreateMap<User, UserDto>().ReverseMap();
});
builder.Services.AddSingleton(autoConfiguration.CreateMapper());



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