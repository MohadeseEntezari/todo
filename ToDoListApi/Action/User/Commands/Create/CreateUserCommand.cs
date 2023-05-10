using AutoMapper;
using MediatR;

namespace ToDoListApi.Action.User.Commands.Create
{
    public record CreateUserCommand : IRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.User>(request);

        }
    }
}
