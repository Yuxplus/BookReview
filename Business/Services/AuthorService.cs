using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results.Bases;
using DataAccess.Results;
using Microsoft.EntityFrameworkCore;
using Business.Services.Bases;

namespace Business.Services
{
    public interface IAuthorService
    {
        IQueryable<AuthorModel> Query();
        Result Add(AuthorModel model);
        Result Update(AuthorModel model);
        Result Delete(int id);
    }
    public class AuthorService : ServiceBase , IAuthorService
    {
        public AuthorService(Db db) : base(db)
        {
        }

        public IQueryable<AuthorModel> Query()
        {
            return _db.Authors.Include(s=>s.Books).OrderBy(s => s.Name).Select(s => new AuthorModel()
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname,
                IsRetired = s.IsRetired,

                AuthorCountOutput = s.Books.Count,
                BookNamesOutput = string.Join(Environment.NewLine,
                                                                s.Books.OrderByDescending(p => p.PublishedYear)
                                                                .ThenBy(p => p.Title)
                                                                .Select(p => $"<tr style='padding: 10 0px'><td style='padding: 0 20px'>{p.Title}</td><td>{p.PublishedYear.Value.Year}</td></tr>"))




        });
        }

        public Result Add(AuthorModel model)
        {
            if (_db.Authors.Any(s => s.Name.ToLower() == model.Name.ToLower().Trim()) && _db.Authors.Any(k => k.Surname.ToLower() == model.Surname.ToLower().Trim())) {
                return new ErrorResult("Author with the same name exists!");
            }
            Author author = new Author()
            {
                Name = model.Name.Trim(),
                Surname = model.Surname.Trim(),
                IsRetired = model.IsRetired,
            };
            _db.Authors.Add(author);
            _db.SaveChanges();
            return new SuccessResult("Author added successfully.");
        }

        public Result Update(AuthorModel model)
        {
            if(_db.Authors.Any(s=> s.Id != model.Id && s.Name.ToLower().Trim() == model.Name.ToLower().Trim() && s.Surname.ToLower().Trim() == model.Surname.ToLower().Trim())) {
                return new ErrorResult("Author with the same name exists!");

            }
            Author author = _db.Authors.Find(model.Id);
            if (author == null)
            {
                return new ErrorResult("Author not found!");
            }
            author.Name = model.Name.Trim();
            author.Surname = model.Surname.Trim();
            author.IsRetired = model.IsRetired;
            _db.Authors.Update(author);
            _db.SaveChanges();
            return new SuccessResult("Authors updated successfully.");
        }

        public Result Delete(int id)
        {
            Author author = _db.Authors.Include(s=>s.Books).SingleOrDefault(s => s.Id == id);
            
            if (author == null)
            {
                return new ErrorResult("Author not found!");
            }
            if (author.Books is not null && author.Books.Any())
            {
                return new ErrorResult("Author Can't be deleted because it has relational books!");
            }

            _db.Authors.Remove(author);
            _db.SaveChanges();
            return new SuccessResult("Author deleted successfully");
        }
    }
}
