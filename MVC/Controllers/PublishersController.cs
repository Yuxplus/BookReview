#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Services;
using Business.Models;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class PublishersController : Controller
    {
        // TODO: Add service injections here
        private readonly IPublisherService _publisherService;
        private readonly IBooksService _booksService;

        public PublishersController(IPublisherService publisherService, IBooksService booksService)
        {
            _publisherService = publisherService;
            _booksService = booksService;
        }

        // GET: Publishers
        public IActionResult Index()
        {
            List<PublisherModel> publisherList = _publisherService.GetList(); // TODO: Add get collection service logic here
            return View(publisherList);
        }

        // GET: Publishers/Details/5
        public IActionResult Details(int id)
        {
            PublisherModel publisher = _publisherService.GetItem(id); // TODO: Add get item service logic here
            if (publisher == null)
            {
                return View("Error", "Publisher not found!");
            }
            return View(publisher);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewBag.Books = new MultiSelectList(_booksService.Query(), "Id", "Title");

			return View();
        }

		// POST: Publishers/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(PublisherModel publisher)
		{
			if (ModelState.IsValid)
			{
				var result = _publisherService.Add(publisher);
				if (result.IsSuccessful)
				{
					TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = publisher.Id});
				}
				ModelState.AddModelError("", result.Message);
			}
			ViewBag.Books = new MultiSelectList(_booksService.Query(), "Id", "Title");
			return View(publisher);
		}

		// GET: Publishers/Edit/5
		public IActionResult Edit(int id)
        {
            PublisherModel publisher = _publisherService.GetItem(id); ; // TODO: Add get item service logic here
            if (publisher == null)
            {
                return View("Error", "Publisher not Found!");
            }
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Books = new MultiSelectList(_booksService.Query(), "Id", "Title");
			return View(publisher);
        }

        // POST: Publishers/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PublisherModel publisher)
        {
			if (ModelState.IsValid)
			{
				// TODO: Add update service logic here
				var result = _publisherService.Update(publisher);
				if (result.IsSuccessful)
				{
					TempData["Message"] = result.Message;
					return RedirectToAction(nameof(Details), new { id = publisher.Id });
				}
				ModelState.AddModelError("", result.Message);
			}
			// TODO: Add get related items service logic here to set ViewData if necessary
			ViewBag.Books = new MultiSelectList(_booksService.Query().ToList(), "Id", "Title");
			return View(publisher);
		}

        // GET: Publishers/Delete/5
        public IActionResult Delete(int id)
        {
            PublisherModel publisher = _publisherService.GetItem(id); // TODO: Add get item service logic here
            if (publisher == null)
            {
                return View("Error", "Owner not found!");
            }
            return View(publisher);
        }

        // POST: Publishers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _publisherService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
