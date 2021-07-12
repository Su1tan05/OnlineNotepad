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
using Microsoft.AspNetCore.Identity;

namespace OnlineNotepad.Controllers
{
    public class NotesController : Controller
    {
        private INoteRepository repository;
        private readonly UserManager<AppUser> userManager;
        private ApplicationDbContext context;
        public NotesController(INoteRepository repo, ApplicationDbContext _context, UserManager<AppUser> _userManager)
        {
            repository = repo;
            context = _context;
            userManager = _userManager;
        }
        public ViewResult List()
        {
            string user = userManager.GetUserId(HttpContext.User);
            ViewData["UserMassage"] = user;
            return View(repository.Notes); 
        }
            
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
            string user = userManager.GetUserId(HttpContext.User);
            ViewData["UserMassage"] = "Hello";
            var note = new Note { Name = model.Name, Content = model.Content, DateOfCreation = DateTime.Now.ToString("MM/dd/yyyy H:mm"), UserId = user};
            context.Add<Note>(note);
            context.SaveChanges();
            return RedirectToAction("List", "Notes");
        }
        public ViewResult EditNote(int? noteId)
        {
            Note note = repository.Notes.Single(p => p.Id == Convert.ToInt32(noteId));

            return View(note);
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditNote(Note model)
        {

            return RedirectToAction("List", "Notes");
        }
    }
}
