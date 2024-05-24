using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IBooksService
    {
        IQueryable<BookModel> Query();
        Result Add(BookModel model);
        Result Update(BookModel model);
        Result Delete(int id);
    }

    public class BooksService : ServiceBase , IBooksService
    {
		public BooksService(Db db) : base(db)
		{
		}

		public IQueryable<BookModel> Query()
        {
            return _db.Books
        .Include(o => o.BookOwners)
        .Include(o => o.Author)
        .OrderBy(s => s.Title)
        .Select(s => new BookModel
        {
            Id = s.Id,
            Title = s.Title,
            PublishedYear = s.PublishedYear,
            Price = s.Price,
            AuthorId = s.AuthorId,
            AuthorName = s.Author.Name,  // Include the author's name
            Guid = s.Guid
        });
        }
        public Result Add(BookModel model)
        {
            if (_db.Books.Any(s => s.Title.ToLower() == model.Title.ToLower().Trim()))
            {
                return new ErrorResult("Book with the same name exists!");
            }
            Book book = new Book()
            {
                Title = model.Title.Trim(),
                PublishedYear = model.PublishedYear,
                Price = model.Price,
                AuthorId = model.AuthorId,
            };
            _db.Books.Add(book);
            _db.SaveChanges();
            return new SuccessResult("Book added successfully.");
        }

        public Result Delete(int id)
        {
            Book book = _db.Books.Include(s => s.Author).SingleOrDefault(s => s.Id == id);

            if (book == null)
            {
                return new ErrorResult("Book not found!");
            }
            //if (author.Books is not null && author.Books.Any())
            //{
            //    return new ErrorResult("Author Can't be deleted because it has relational books!");
            //}

            _db.Books.Remove(book);
            _db.SaveChanges();
            return new SuccessResult("Book deleted successfully");
        }

       

        public Result Update(BookModel model)
        {
            if (_db.Books.Any(s => s.Id != model.Id && s.Title.ToLower().Trim() == model.Title.ToLower().Trim()))
            {
                return new ErrorResult("Book with the same name exists!");

            }
            Book book= _db.Books.Find(model.Id);
            if (book == null)
            {
                return new ErrorResult("Author not found!");
            }
            book.Title = model.Title.Trim();
            book.PublishedYear= model.PublishedYear;
            book.Price = model.Price;
            book.AuthorId = model.AuthorId;
            _db.Books.Update(book);
            _db.SaveChanges();
            return new SuccessResult("Book updated successfully.");
        }
    }
}
