using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Domain.Enums;

namespace Ado.Net.Core.Domain.Entities
{
    public class User : Auditables
    {
        public string FullName{ get; set; } = default!;
        public string Email{ get; set; } = default!;
        public string PassWord{ get; set; }  = default!;
        public string Role{ get; set; }  = default!;
        public Gender Gender{ get; set; }

    }
}