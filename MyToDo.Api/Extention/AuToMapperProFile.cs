using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.share.Dtos;

namespace MyToDo.Api.Extention 
{
    public class AutoMapperProFile
    {
        public AutoMapperProFile()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ToDo, ToDoDto>().ReverseMap();
                //cfg.CreateMap<Memo, MemoDto>().ReverseMap();
                //cfg.CreateMap<User, UserDto>().ReverseMap();


            });
        }
    }
}
