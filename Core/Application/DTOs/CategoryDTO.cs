using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ado.Net.Core.Application.DTOs
{
    public class CategoryDTO
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; }  = default!;
        public string Description { get; set;} = default!;
        
    }

    public class CreateCategoryRequestModel
    {
        public string Name { get; set; }  = default!;
        public string Description { get; set;} = default!;
        
    }
}