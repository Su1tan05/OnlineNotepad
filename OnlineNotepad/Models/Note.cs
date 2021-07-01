using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNotepad.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public string DateOfCreation { get; set; }
    }
}



