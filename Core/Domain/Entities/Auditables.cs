using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ado.Net.Core.Domain.Entities
{
    public abstract class Auditables
    {
        public string Id{ get; set; } = Guid.NewGuid().ToString();
    
    }
}