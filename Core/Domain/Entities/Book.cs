using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ado.Net.Core.Domain.Entities
{
    public class Book : Auditables
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        public int Quantity{ get; set; }
   
    }
}