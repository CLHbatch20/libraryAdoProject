using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Domain.Entities;

namespace Ado.Net.Core.Application.Interfaces.Repositories
{
    public interface IBorrowRepository
    {
        Borrow Add(Borrow borrow);
        Borrow Get(string BookName);
        ICollection <Borrow> GetAll();
    }
}