using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineNotepad.Models;

namespace OnlineNotepad.Controllers
{
    public class NotesController : Controller
    {
        private INoteRepository repository;
        public NotesController(INoteRepository repo)
        {
            repository = repo; 
        }

        public ViewResult List() => View(repository.Notes);

        public ViewResult CreateNote() => View();
    }
}
