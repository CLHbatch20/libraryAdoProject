using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Application.DTOs;
using Ado.Net.Core.Domain.Entities;

namespace Ado.Net.Core.Application.Interfaces.Services
{
    public interface IUSerService
    {
        UserDTO LogInUser(LogInUserRequestModel request);
        UserDTO GetUser(string email);
        ICollection<UserDTO> GetAllUsers();
        User GetCurrentUser();
    }
}