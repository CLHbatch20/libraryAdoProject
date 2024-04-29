using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ado.Net.Core.Domain.Entities
{
    public class Student : Auditables
    {
        public string UserEmail{ get; set; }  = default!;
        public string AdmissionNumber { get; set; } = default!;


    }
}