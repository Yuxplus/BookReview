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
using Business.Models;
using Business.Services;
using DataAccess.Results.Bases;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class BooksController : Controller
    {
        // TODO: Add service injections here
        private readonly IBooksService _bookService;

        public BooksController(IBooksService bookService)
        {
            _bookService = bookService;
        }

        // GET: Books
        public IActionResult Index()
        {
            List<BookModel> bookList = _bookService.Query().ToList(); // TODO: Add get collection service logic here
            return View(bookList);
        }

        // GET: Books/Details/5
        public IActionResult Details(int id)
        {
            BookModel book = _bookService.Query().SingleOrDefault(s =>s.Id == id); // TODO: Add get item service logic here
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            //ViewData["AuthorId"] = new SelectList(new List<SelectListItem>(), "Value", "Text");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookModel book)
        {
            if (ModelState.IsValid)
            {
                Result result = _bookService.Add(book);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;

                    return RedirectToAction(nameof(Index));
                }
                ViewBag.ViewMessage = result.Message;
                // TODO: Add insert service logic here
                //return RedirectToAction(nameof(Index));
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            //ViewData["AuthorId"] = new SelectList(new List<SelectListItem>(), "Value", "Text");
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int id)
        {
            BookModel book = _bookService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (book == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            //ViewData["AuthorId"] = new SelectList(new List<SelectListItem>(), "Value", "Text");
            return View(book);
        }

        // POST: Books/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookModel book)
        {
            if (ModelState.IsValid)
            {
                Result result = _bookService.Update(book);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = book.Id });
                }
                TempData["Message"] = result.Message;
                // TODO: Add update service logic here
                return RedirectToAction(nameof(Details), new { id = book.Id });
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            //ViewData["AuthorId"] = new SelectList(new List<SelectListItem>(), "Value", "Text");
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int id)
        {
            BookModel book = _bookService.Query().SingleOrDefault(s => s.Id == id); // TODO: Add get item service logic here
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Result result = _bookService.Delete(id);
            TempData["Message"] = result.Message;
            // TODO: Add delete service logic here
            return RedirectToAction(nameof(Index));
        }
	}
}
