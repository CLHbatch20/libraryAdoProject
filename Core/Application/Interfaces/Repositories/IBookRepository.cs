using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Domain.Entities;

namespace Ado.Net.Core.Application.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Book Add(Book book);
        // Book Delete(string ISBN);
        Book? Get(string bookName);
        ICollection<Book?> GetAll();
    }
}