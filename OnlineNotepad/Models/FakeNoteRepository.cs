using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNotepad.Models
{
    public class FakeNoteRepository : INoteRepository
    {
        public IQueryable<Note> Notes => new List<Note> {
            new Note { Name = "MyFirstNote", Description = "I dont know)"},
            new Note { Name = "MySecondNote", Description = "I dont know)" }
        }.AsQueryable<Note>();
    }
}
