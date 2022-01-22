using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace NoteApp.UnitTests
{
    class ProjectTest
    {
        private Project _project;
        private Note _notes;

        [SetUp]
        public void InitNote()
        {
            _notes = new Note();
            _project = new Project();
            _project.Notes = new List<Note>();
        }

        [Test(Description = "Positive Getter test List<Note>")]
        public void TestProjectGet_CorrectValue()
        {
            _notes.Name = "Title";
            _project.Notes.Add(_notes);
            var expected = _project.Notes;
            _project.Notes = expected;
            var actual = _project.Notes;
            Assert.AreEqual(expected, actual, "The List<Note> getter returns incorrect notes");
        }
    }
}
