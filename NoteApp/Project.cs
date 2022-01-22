using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
	/// <summary>
	/// List для хранения всех заметок проекта.
	/// </summary>
	public class Project
	{
		/// <summary>
		/// Список заметок.
		/// </summary>
		private List<Note> _notes = new List<Note>();

		/// <summary>
		/// Свойство списка всех заметок.
		/// </summary>
		public List<Note> Notes { get; set; } = new List<Note>();

		/// <summary>
		/// Функиця для сортировки списка заметок по дате изменения.
		/// </summary>
		public List<Note> SortNotes(List<Note> noteList = null)
		{
			var sortingList = noteList ?? Notes;

			sortingList.Sort(delegate (Note x, Note y)
			{
				if (x.ModifiedAt == null && y.ModifiedAt == null) return 0;
				else if (x.ModifiedAt == null) return 1;
				else if (y.ModifiedAt == null) return -1;
				else return y.ModifiedAt.CompareTo(x.ModifiedAt);
			});
			return sortingList;
		}
	}
}
