using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNotepad.Models
{
    public class Note
    {
        public int NoteID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime Date { get { return DateTime.Now; } }
    }
}



