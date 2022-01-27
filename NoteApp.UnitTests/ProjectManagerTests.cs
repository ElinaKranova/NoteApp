using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NoteApp;
using NUnit.Framework;

namespace ProjectTests
{
	[TestFixture]
	internal class ProjectManagerTests
	{
		[Test(Description = "Проверка сериализации")]
		public void TestSaveToFile_CorrectValue()
		{
			//Setup
			var example = new Project 
			{ 
				Notes = new List<Note>() 
			};
			Note note = new Note();
			note.Name = "First";
			note.Text = "asd";
			note.Category = NoteCategory.Job;
			example.Notes.Add(note);
			Note note1 = new Note();
			note1.Name = "Second";
			note1.Text = "dsa";
			note1.Category = NoteCategory.Home;
			example.Notes.Add(note1);
			var location = Assembly.GetExecutingAssembly().Location;
			var folder = Path.GetDirectoryName(location);
			folder += @"\TestData\";

			//Act
			ProjectManager.SaveData(example, folder + @"actualProject.json");

            var expected = File.ReadAllText(folder + @"ExpectedNoteApp.notes");
            var actual = File.ReadAllText(folder + @"actualProject.json");
            //Assert
            Assert.AreEqual(actual, expected, "Сравнение сериализатора ProjectManager и встроенного.");
		}
		[Test(Description = "Проверка десериализации")]
		public void TestLoadFromFile_CorrectValue()
		{
			//Setup
			var actual = new Project 
			{
				Notes = new List<Note>() 
			};
			Note note = new Note();
			note.Name = "First";
			note.Text = "asd";
			note.Category = NoteCategory.Job;
			actual.Notes.Add(note);
			Note note1 = new Note();
			note1.Name = "Second";
			note1.Text = "dsa";
			note1.Category = NoteCategory.Home;
			actual.Notes.Add(note1);
			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string fileName = $@"{path}\ExpectedNoteApp.notes";

			//Testing
			var expected = ProjectManager.LoadData(fileName);

			//Assert
			for (int i = 0; i < actual.Notes.Count; i++)
			{
				Assert.AreEqual(actual.Notes[i].Name, expected.Notes[i].Name,
				  "Сравнение результата десериализованного созданного заголовка и ожидаемого");
			}
		}
	}
}
