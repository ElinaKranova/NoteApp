using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NoteApp;

namespace NoteApp.UnitTests
{
	[TestFixture]
	class ProjectTests
	{
		[Test(Description = "")]
		public void TestNoteGet_CorrectValue()
		{
			//Setup
			var expected = new List<Note>();
			var note = new Note();
			note.Name = "Заголовок";
			note.Category = NoteCategory.Home;
			expected.Add(note);

			//Testing
			var project = new Project();
			project.Notes.Add(note);
			var actual = project.Notes;

			//Assert
			Assert.AreEqual(expected[0].Name, actual[0].Name);
			Assert.AreEqual(expected[0].Text, actual[0].Text);
			Assert.AreEqual(expected[0].CreatedAt, actual[0].CreatedAt);
			Assert.AreEqual(expected[0].ModifiedAt, actual[0].ModifiedAt);
			Assert.AreEqual(expected[0].Category, actual[0].Category);
		}
	}
}
