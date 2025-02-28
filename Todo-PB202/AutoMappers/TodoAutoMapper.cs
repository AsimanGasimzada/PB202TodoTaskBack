using AutoMapper;
using Todo_PB202.Models;

namespace Todo_PB202.AutoMappers;

public class TodoAutoMapper : Profile
{
    public TodoAutoMapper()
    {
        CreateMap<Todo, TodoCreateDto>().ReverseMap();
        CreateMap<Todo, TodoGetDto>().ReverseMap();
        CreateMap<Todo, TodoUpdateDto>().ReverseMap();
    }
}
