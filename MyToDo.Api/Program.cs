//WebApplication 是在 Program.cs 中配置和启动 ASP.NET Core 应用程序的默认方式
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

//配置连接sqlite
builder.Services.AddDbContext<MyToDoContext>(options =>
{
    //appsetting中的配置
    var connectionString = builder.Configuration.GetConnectionString("ToDoConnection");
    options.UseSqlite(connectionString);
}).AddUnitOfWork<MyToDoContext>()
.AddCustomRepository<ToDo,ToDoRepository>()
.AddCustomRepository<Memo, MemoRepository>()
.AddCustomRepository<User, UserRepository>();//依赖注入工作单元


//注入service
builder.Services.AddTransient<IToDoService, ToDoService>();


//配置添加AutoMapper的服务
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

//配置应用程序的请求处理管道（一系列中间件

app.UseAuthorization();

app.MapControllers();

app.Run();