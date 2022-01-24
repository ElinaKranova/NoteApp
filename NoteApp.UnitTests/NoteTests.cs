using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
	/// <summary>
	/// Специальный атрибут для отличия обычных классов от тестовых.
	/// </summary>
	[TestFixture]
    public class NoteTests
    {
		/// <summary>
		/// Отдельный метод для избежания дублирования кода.
		/// </summary>
		private Note _note;
		[SetUp]
		public void InitNote()
		{
			_note = new Note();
		}

		[Test(Description = "Позитивный тест геттера Name")]
		public void TestTitleGet_CorrectValue()
		{
			//Setup
			var expected = "Безымянный";
			_note.Name = expected;
			//Testing
			var actual = _note.Name;
			//Assert
			Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильный заголовок");
		}

		[Test(Description = "Присвоение неправильного заголовка больше 50 символов")]
		public void TestTitleSet_ArgumentException()
		{
			//Setup
			var wrongTitle = "TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest";
			//Assert
			Assert.Throws<ArgumentException>(
			() => { _note.Name = wrongTitle; },
			"message");
		}

		[Test(Description = "Позитивный тест cеттера Tittle")]
		public void TestTitleSet_CorrectValue()
		{
			//Setup
			var expected = "Заголовок";
			//Testing
			_note.Name = expected;
			//Assert
			Assert.AreEqual(expected, _note.Name, "Cеттер Name  устанавливает неправильное значение");
		}

		[Test(Description = "Позитивный тест геттера CategoryNote")]
		public void TestCategoryNoteGet_CorrectValue()
		{
			//Setup
			var expected = NoteCategory.Home;
			//Testing
			_note.Category = expected;
			var actual = _note.Category;
			//Assert
			Assert.AreEqual(expected, actual, "Геттер NoteCategory возвращает неправильную категорию заметки");
		}

		public void TestCategoryNoteSet_CorrectValue()
		{
			//Setup
			var expected = NoteCategory.Home;
			//Testing
			_note.Category = expected;
			//Assert
			Assert.AreEqual(expected, _note.Category = expected, "Сеттер CategoryNote устанавливает неправильную категорию заметки");
		}

		[Test(Description = "Позитивный тест геттера Text")]
		public void TestTextGet_CorrectValue()
		{
			//Setup
			var expected = "Какой-нибудь там текст";
			//Testing
			_note.Text = expected;
			var actual = _note.Text;
			//Assert
			Assert.AreEqual(expected, actual, "Геттер NoteText возвращает неправильный текст заметки");
		}

		[Test(Description = "Позитивный тест cеттера Text")]
		public void TestTextSet_CorrectValue()
		{
			//Setup
			var expected = "Текстище";
			//Testing
			_note.Text = expected;
			//Assert
			Assert.AreEqual(expected, _note.Text, "Cеттер Text устанавливает неправильное значение");
		}

		[Test(Description = "Проверка даты")]
		public void TestDateCreated_CorrectValue()
		{
			bool trueDate= false;
			if (DateTime.Now >=_note.CreatedAt)
			{
				trueDate = true;
			}
			Assert.AreEqual(trueDate, true, "Даты не равны");
		}
	}
}
