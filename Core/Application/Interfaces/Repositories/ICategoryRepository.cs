using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Domain.Entities;

namespace Ado.Net.Core.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        Category Delete(string name);
        Category Get(string name);
        ICollection <Category> GetAll();
    }
}