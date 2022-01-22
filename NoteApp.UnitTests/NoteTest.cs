using NUnit.Framework;
using System;

namespace NoteApp.UnitTests
{
    public class NoteTest
    {
        private Note _note;

        [SetUp]
        public void InitNote()
        {
            _note = new Note();
        }

        #region GetSetNameText

        [Test(Description = "Positive Getter Test Name")]
        public void TestNameGet_CorrectValue()
        {
            var expected = "Untitled";
            _note.Name = expected;
            var actual = _note.Name;
            Assert.AreEqual(expected, actual, "The Name getter returns an incorrect note name");
        }

        [TestCase("", "An exception should occur if the last name is an empty string",
                TestName = "Assigning an empty string as a name")]
        [TestCase("Untitled-Untitled-Untitled-Untitled-Untiled-Untiled", " Misnaming more than 50 characters",
                TestName = "Assigning an incorrect name more than 50 characters")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            //var contact = new Contact(); // Теперь эта строка не нужна
            Assert.Throws<ArgumentException>(
            () => { _note.Name = wrongSurname; },
            message);
        }

        #endregion

        #region GetTextNote

        [Test(Description = "Positive TextNote Getter test")]
        public void TestTextNoteGet_CorrectValue()
        {
            var expected = "Text of the note";
            _note.TextNote = expected;
            var actual = _note.TextNote;
            Assert.AreEqual(expected, actual, "The TextNote getter returns the wrong note text");
        }

        #endregion

    }
}
