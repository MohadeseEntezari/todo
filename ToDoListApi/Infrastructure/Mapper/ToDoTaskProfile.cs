using AutoMapper;
using ToDoListApi.Action.ToDoTask.Commands.Create;
using ToDoListApi.Domain;
using ToDoListApi.Dto;

namespace ToDoListApi.Infrastructure.Mapper
{
    public class ToDoTaskProfile:Profile
    {
        public ToDoTaskProfile()
        {
            CreateMap<CreateToDoTaskCommand, ToDoTask>()
                .ForMember(c => c.TaskDate, o => o.MapFrom(x => DateTime.Parse(x.TaskDate)));

            CreateMap<ToDoTask, ToDoTaskDto>()
                .ForMember(c => c.TaskDate, o => o.MapFrom(x => x.TaskDate.ToShortDateString())).ReverseMap();

        }
    }
}
