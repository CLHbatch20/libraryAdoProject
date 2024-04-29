using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Application.DTOs;
using Ado.Net.Core.Application.Interfaces.Repositories;
using Ado.Net.Core.Application.Interfaces.Services;
using Ado.Net.Core.Domain.Entities;
using Ado.Net.Infrastructure.Repositories;

namespace Ado.Net.Core.Application.Implementation.Services
{
    public class StudentService : IStudentService
    {
        IUserRepository _userRepo = new UserRepository();
        IStudentRepository _studentRepo = new StudentRepository();
        public StudentDTO CreateStudent(RegisterStudentRequestModel request)
        {
            var userExists = _userRepo.Get(request.Email);
            if (userExists != null)
            {
               return null;
            }
            var user = new User
            {
                Email = request.Email,
                FullName = request.FullName,
                Gender = request.Gender,
                PassWord = request.PassWord,
                Role = "Student",
            };
            _userRepo.Add(user);
            var student = new Student
            {
                UserEmail = user.Email,
            };
            _studentRepo.Add(student);
            var studentDto  = new StudentDTO
            {
                 Email = user.Email,
                 FullName = user.FullName,
                 Gender = user.Gender,
                 Role = user.Role,
                 Id = user.Id,
            };
            return studentDto;
        }

        public ICollection<StudentDTO> GetAllStudent()
        {
            var students = _studentRepo.GetAll();
            var studentDtos = students.Select(x => new StudentDTO
            {
                Email = x.UserEmail,
                FullName = _userRepo.Get(x.UserEmail).FullName,
                Gender = _userRepo.Get(x.UserEmail).Gender,
                Role = _userRepo.Get(x.UserEmail).Role,
                Id = _userRepo.Get(x.UserEmail).Id
            });
            return studentDtos.ToList();
        }

        public StudentDTO GetStudent(string email)
        {
            var student = _studentRepo.Get(email);
            if (student == null)
            {
                return null;
            }
            var studentDtO = new StudentDTO
            {
                Email = student.UserEmail,
            };
            return studentDtO;

        }
    }
}