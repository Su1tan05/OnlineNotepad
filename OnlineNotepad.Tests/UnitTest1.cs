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
            // ����������� 
            Note note = new Note();
            // �������� 
            note.Id = 4;
            note.Name = "Hello World!";
            // �����������
            Assert.AreEqual(4, note.Id);
            Assert.AreEqual("Hello World!", note.Name);
        }
    }
}