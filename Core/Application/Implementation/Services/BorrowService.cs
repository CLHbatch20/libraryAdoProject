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
    public class BorrowService : IBorrowService
    {
        IBookRepository _bookRepo = new BookRepository();
        IBorrowRepository _borrowRepo = new BorrowRepository();
        public void BorrowBook(BorrowRequestModel request)
        {
            foreach (var book in request.BookName)
            {
                var exist = _bookRepo.Get(book);
                if (exist == null)
                {
                    continue;
                }
                if(exist.Quantity < 1)
                {
                    continue;
                }
                var borrow = new Borrow
                {
                    BookName = book,
                    DateBorrowed = DateTime.Now,
                    StudentEmail = request.SudentEmail    
                };
                _borrowRepo.Add(borrow);      
            }
          

            
        }
        // private int GetAllBookByName(string bookName)
        // {
        //     var book = _bookRepo.Get(bookName);
        //     if (book == null)
        //     {
        //         return 0;
        //     }
        //     var bookCount = _bookRepo.GetAll().Where(x => x.Title == bookName);
        //     return bookCount.Count();
        // }

        public ICollection<BorrowDTO> GetAllBooksBorrowed()
        {
            var borows = _borrowRepo.GetAll();
            var borrowDTO = borows.Select(b => new BorrowDTO
            {
                BookName = b.BookName,
                DateBorrowed = DateTime.Now,
                SudentEmail = b.StudentEmail   
            });
            return borrowDTO.ToList();


        }

        public BorrowDTO GetBorrowedBook(string bookName)
        {
            var bookBorrowed = _borrowRepo.Get(bookName);
            if (bookBorrowed == null)
            {
                return null;
            }
            var borrowDTO = new BorrowDTO
            {
                BookName = bookBorrowed.BookName,
                DateBorrowed = bookBorrowed.DateBorrowed,
                DateReturned = bookBorrowed.DateReturned,
                SudentEmail = bookBorrowed.StudentEmail
            };
            return borrowDTO;
        }
    }
}