using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Domain.Entities;

namespace Ado.Net.Core.Application.DTOs
{
    public class BorrowDTO
    {
        public string BookName{ get; set; } = default!;
        public string SudentEmail { get; set; } = default!;
        public DateTime DateBorrowed{ get; set; }
        public DateTime DateReturned{ get; set;} 
        
    
    }

     public class BorrowRequestModel
    {
        public List<string> BookName{ get; set; } = default!;
        public string SudentEmail { get; set; } = default!;
    }
}