using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ToDo.Application.Common.Models;
using ToDo.Domain.Entities;
using ToDo.Persistence;

namespace ToDo.Application.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContextDb _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public CreateUserCommandHandler(IMapper mapper, ApplicationContextDb context, IPasswordHasher<User> passwordHasher)
        {
            _mapper = mapper;
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = _mapper.Map<User>(request);

            user.Password = _passwordHasher.HashPassword(user, user.Password);

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserDto>(user);
        }
    }
}
