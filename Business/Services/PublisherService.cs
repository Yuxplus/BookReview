using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IPublisherService
    {
        IQueryable<PublisherModel> Query();
        Result Add(PublisherModel model);
        Result Update(PublisherModel model);
        Result Delete(int id);

        List<PublisherModel> GetList();

        PublisherModel GetItem(int id);
    }
    public class PublisherService : ServiceBase , IPublisherService
    {
        public PublisherService(Db db) : base(db)
        {
        }

        public Result Add(PublisherModel model)
        {
            if (_db.Owners.Any(o => o.Name.ToLower() == model.Name.ToLower().Trim() && o.Location.ToLower() == model.Location.ToLower().Trim()))
                return new ErrorResult("Publisher with same name and surname exists!");
            var entity = new Publisher()
            {
                EstablishmentDate = model.EstablishmentDate,
                IsActive = model.IsActive,
                Name = model.Name.Trim(),
                Score = model.Score ?? 0,
                Location = model.Location.Trim(),
                BookOwners = model.BookIdsInput?.Select(bookId => new BookOwner()
                {
                    BookId = bookId
                }).ToList()
            };
            _db.Owners.Add(entity);
            _db.SaveChanges();
            model.Id = entity.Id;
            return new SuccessResult("Publisher added successfuly.");
        }

        public Result Delete(int id)
        {
            var entity = _db.Owners.Include(o => o.BookOwners).SingleOrDefault(o => o.Id == id);
            if (entity is null)
                return new ErrorResult("Publisher not found!");
            _db.BookOwners.RemoveRange(entity.BookOwners);
            _db.Owners.Remove(entity);
            _db.SaveChanges();
            return new SuccessResult("Publisher deleted successfuly.");
        }

        public PublisherModel GetItem(int id) => Query().SingleOrDefault(o => o.Id == id);
        

        public List<PublisherModel> GetList() => Query().ToList();
        
        public IQueryable<PublisherModel> Query()
        {
            return _db.Owners.Include(o => o.BookOwners).ThenInclude(bo => bo.Book)
                .OrderByDescending(o => o.IsActive).ThenBy(o => o.EstablishmentDate).ThenBy(o => o.Name).ThenBy(o => o.Location)
                .Select(o => new PublisherModel()
                {
                    EstablishmentDate = o.EstablishmentDate,
                    Name = o.Name,
                    Location = o.Location,
                    IsActive = o.IsActive,
                    Score = o.Score,
                    Id = o.Id,

                    EstablishmentDateOutput = o.EstablishmentDate.HasValue ? o.EstablishmentDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                    IsActiveOutput = o.IsActive ? "Active" : "Not Active",
                    ScoreOutput = o.Score.ToString("N1"),

                    BookIdsInput = o.BookOwners.Select(bo => bo.BookId).ToList(),
                    BookNamesOutput = string.Join("<br />",o.BookOwners.Select(bo => bo.Book.Title)),
                });
        }

        public Result Update(PublisherModel model)
        {
            if (_db.Owners.Any(o => o.Id != model.Id && o.Name.ToLower() == model.Name.ToLower().Trim() && o.Location.ToLower() == model.Location.ToLower().Trim()))
                return new ErrorResult("Publisher with same name and surname exists!");
            var entity = _db.Owners.Include(o => o.BookOwners).SingleOrDefault(o => o.Id == model.Id);
            if (entity is null)
                return new ErrorResult("Publisher not found!");
            _db.BookOwners.RemoveRange(entity.BookOwners);
            entity.EstablishmentDate = model.EstablishmentDate;
            entity.IsActive = model.IsActive;
            entity.Name = model.Name.Trim();
            entity.Score = model.Score ?? 0;
            entity.Location = model.Location.Trim();
            entity.BookOwners = model.BookIdsInput?.Select(bookId => new BookOwner()
            {
                BookId = bookId
            }).ToList();
            _db.Owners.Update(entity);
            _db.SaveChanges();
            return new SuccessResult("Publisher updated successfuly.");
        }
    }
}
