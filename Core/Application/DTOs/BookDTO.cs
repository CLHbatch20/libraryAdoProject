using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ado.Net.Core.Application.DTOs
{
    public class BookDTO
    {
        public string Id { get; set; } = default!;
       public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public int Quantity{ get; set; } 
    }

    public class CreateBookRequestModel
    {
       public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string BookName { get; set; } = default!;
        public int Quantity{ get; set; } 
    }
}