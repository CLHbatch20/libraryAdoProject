using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Domain.Entities;

namespace Ado.Net.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Add(User user);
        User Delete(string email);
        User Get(string email);
        ICollection <User> GetAll();


    }
}