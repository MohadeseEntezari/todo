﻿using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDo.Application.Common.Models;

namespace ToDo.Application.Users.Commands.Create
{
    public record CreateUserCommand : IRequest
    {

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
