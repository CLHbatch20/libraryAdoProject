using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Application.DTOs;

namespace Ado.Net.Core.Application.Interfaces.Services
{
    public interface IStudentService
    {
        StudentDTO CreateStudent (RegisterStudentRequestModel request);
        StudentDTO GetStudent(string email);
        ICollection<StudentDTO> GetAllStudent();
    }
}