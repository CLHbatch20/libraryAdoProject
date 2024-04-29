using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Application.DTOs;

namespace Ado.Net.Core.Application.Interfaces.Services
{
    public interface IBookService
    {
        BookDTO CreateBook(CreateBookRequestModel request);
        BookDTO GetBook(string bookName);
        ICollection<BookDTO> GetAllBooks();
    }
}