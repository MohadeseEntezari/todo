using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.Common.Models;
using ToDo.Persistence;

namespace ToDo.Application.Users.Queries.GetAll
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserDto>>
    {
        private readonly ApplicationContextDb _context;
        private readonly IMapper _mapper;
        public GetAllUserQueryHandler(ApplicationContextDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
