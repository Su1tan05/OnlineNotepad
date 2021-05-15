using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineNotepad.Models
{
    public class EFNoteRepository : INoteRepository
    {
        private ApplicationDbContext context;

        public EFNoteRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Note> Notes => context.Notes;
    }
}
