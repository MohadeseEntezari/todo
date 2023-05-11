using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ToDoListApi.Data;
using ToDoListApi.Dto;

namespace ToDoListApi.Action.User.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContextDb _context;
        private readonly IPasswordHasher<Domain.User> _passwordHasher;

        public CreateUserCommandHandler(IMapper mapper, ApplicationContextDb context, IPasswordHasher<Domain.User> passwordHasher)
        {
            _mapper = mapper;
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = _mapper.Map<Domain.User>(request);

            user.Password = _passwordHasher.HashPassword(user, user.Password);

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserDto>(user);
        }
    }
}
