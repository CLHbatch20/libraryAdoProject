using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ado.Net.Core.Application.DTOs;
using Ado.Net.Core.Application.Interfaces.Repositories;
using Ado.Net.Core.Application.Interfaces.Services;
using Ado.Net.Core.Domain.Entities;
using Ado.Net.Infrastructure.Repositories;

namespace Ado.Net.Core.Application.Implementation.Services
{
    public class BookService : IBookService
    {
        IBookRepository _bookRepo = new BookRepository();
        public BookDTO CreateBook(CreateBookRequestModel request)
        {
            var bookExist = _bookRepo.Get(request.BookName);
            if (bookExist != null)
            {
                return null;
            }
            var book = new Book
            {
                Author = request.Author,
                Quantity = request.Quantity,
                Title = request.Title
            };
            _bookRepo.Add(book);

            var bookDTO = new BookDTO
            {
                Author = book.Author,
                Quantity = book.Quantity,
                Title = book.Title

            };
            return bookDTO;

        }

        public ICollection<BookDTO> GetAllBooks()
        {
            var books = _bookRepo.GetAll();
            var bookDTO = books.Select(b => new BookDTO
            {
                Author = b.Author,
                Quantity = b.Quantity,
                Id = b.Id,
                Title = b.Title
            });
            return bookDTO.ToList();
        }

        public BookDTO GetBook(string bookName)
        {
            var book = _bookRepo.Get(bookName);
            if (book == null)
            {
                return null;
            }
            var bookDTO = new BookDTO
            {
                Author = book.Author,
                Id = book.Id,
                Quantity = book.Quantity,
                Title = book.Title
            };
            return bookDTO;
        }

    }
}