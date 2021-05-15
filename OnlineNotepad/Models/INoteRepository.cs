using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNotepad.Models
{
    public interface INoteRepository
    {
        IQueryable<Note> Notes { get; }
    }
}
