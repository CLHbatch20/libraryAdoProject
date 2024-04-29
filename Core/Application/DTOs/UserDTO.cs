using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Domain.Entities;
using Ado.Net.Core.Domain.Enums;

namespace Ado.Net.Core.Application.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; } = default!;
        public string FullName{ get; set; } = default!;
        public string Email{ get; set; } = default!;
        public string Role{ get; set; }  = default!;
        public Gender Gender{ get; set; }
    }

    public class LogInUserRequestModel
    {
        public string Email{ get; set; } = default!;
        public string PassWord{ get; set; }  = default!;
    }
}