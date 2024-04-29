using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Domain.Entities;

namespace Ado.Net.Core.Application.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Student Add(Student student);
        Student Delete(string userEmail);
        Student Get(string email);
        ICollection <Student> GetAll();
    }
}