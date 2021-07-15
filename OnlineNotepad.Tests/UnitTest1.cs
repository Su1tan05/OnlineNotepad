using OnlineNotepad.Models;
using OnlineNotepad.Controllers;

using NUnit.Framework;
using Moq;
using System.Linq;

namespace OnlineNotepad.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            // Организация 
            Note note = new Note();
            // Действие 
            note.Id = 4;
            note.Name = "Hello World!";
            // Утверждение
            Assert.AreEqual(4, note.Id);
            Assert.AreEqual("Hello World!", note.Name);
        }
    }
}