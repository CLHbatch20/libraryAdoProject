using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ado.Net.Core.Domain.Entities
{
    public class Borrow : Auditables
    {
        public  string StudentEmail{ get; set; } = default!;
        public string BookName{ get; set; } = default!;
        public DateTime DateBorrowed{ get; set; }
        public DateTime DateReturned{ get; set;}
    }
}