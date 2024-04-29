using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Ado.Net.Core.Application.DTOs;
using Ado.Net.Core.Application.Interfaces.Repositories;
using Ado.Net.Core.Application.Interfaces.Services;
using Ado.Net.Core.Domain.Entities;
using Ado.Net.Infrastructure.Repositories;

namespace Ado.Net.Core.Application.Implementation.Services
{
    public class UserService : IUSerService
    {
         public static User LoggedInUser{ get; set; }  = default!;
        IUserRepository userRepo = new UserRepository();
        public ICollection<UserDTO> GetAllUsers()
        {
            var users = userRepo.GetAll();
            var userDtos = new List<UserDTO>();
            foreach (var user in users)
            {
                UserDTO userDTO = new UserDTO
                {
                   FullName = user.FullName,
                   Email = user.Email,
                   Gender = user.Gender,
                   Id = user.Id,
                   Role = user.Role
                };
                userDtos.Add(userDTO);
            }
            return userDtos;
        }

        public UserDTO GetUser(string email)
        {
            var user = userRepo.Get(email);
            if (user == null)
            {
                return null;
            }
            var userDto = new UserDTO()
            {
                FullName = user.FullName,
                Email = user.Email,
                Gender = user.Gender,
                Id = user.Id,
                Role = user.Role
            };
            return userDto;
        }

        public UserDTO LogInUser(LogInUserRequestModel request)
        {
            var user = userRepo.Get(request.Email);
            if (user == null)
            {
                return null;
            }

            if (request.PassWord != user.PassWord)
            {
                return null;
            }
            LoggedInUser = user;
            var userDTO = new UserDTO
            {
                Email = user.Email,
                FullName = user.FullName,
                Gender = user.Gender,
                Id = user.Id,
                Role = user.Role
            };
            return userDTO;
        }

        public User GetCurrentUser()
        {
            return LoggedInUser;
        }
    }
}