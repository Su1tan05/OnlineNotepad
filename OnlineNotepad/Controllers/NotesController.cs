using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineNotepad.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;

namespace OnlineNotepad.Controllers
{
    public class NotesController : Controller
    {
        private INoteRepository repository;
        private ApplicationDbContext context;
        public NotesController(INoteRepository repo, ApplicationDbContext _context)
        {
            repository = repo;
            context = _context;
        }

        [Authorize]
        public ViewResult List() => View(repository.Notes);
        [Authorize]
        [HttpGet]
        public IActionResult CreateNote()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateNote(Note model)
        {
            var note = new Note { Name = model.Name, Content = model.Content, Date = DateTime.Now};
            context.Add<Note>(note);
            context.SaveChanges();
            return RedirectToAction("List", "Notes");
        }
    }
}
