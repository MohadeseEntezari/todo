using AutoMapper;
using ToDo.Application.Common.Models;
using ToDo.Application.ToDoTasks.Commands.Create;
using ToDo.Domain.Entities;

namespace ToDo.Application.Common.Mappings
{
    public class ToDoTaskProfile : Profile
    {
        public ToDoTaskProfile()
        {
            CreateMap<CreateToDoTaskCommand, ToDoTask>()
                .ForMember(c => c.TaskDate, o => o.MapFrom(x => DateTime.Parse(x.ToDo.TaskDate)));

            CreateMap<ToDoTask, ToDoTaskDto>()
                .ForMember(c => c.TaskDate, o => o.MapFrom(x => x.TaskDate.ToShortDateString())).ReverseMap();

        }
    }
}
