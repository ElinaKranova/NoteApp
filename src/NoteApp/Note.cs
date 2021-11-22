using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{ 
    /// <summary>
    /// Класс: Заметки.
    /// </summary>
    public class Note : ICloneable
    {
        /// <summary>
        /// Категория заметки.
        /// </summary>
        private Category _category;

        /// <summary>
        /// Имя заметки.
        /// </summary>
        private string _name = "Untitled";

        /// <summary>
        /// Текст заметки.
        /// </summary>
        private string _textNote = "";

        /// <summary>
        /// Дата и время создания заметки
        /// </summary>
        private DateTime _dateCreation;

        /// <summary>
        /// Дата и время последнего изменения
        /// </summary>
        private DateTime _timeLastEdit;

        /// <summary>
        /// Создает экземпляр Note.
        /// </summary>
        public Note()
        {
            _timeLastEdit = _dateCreation = DateTime.Now;
        }

        /// <summary>
        /// Возвращает и задает категорию заметок.
        /// </summary>
        public Category Category
        {
            get { return _category; }
            set { _category = (Category)Enum.GetValues(typeof(Category)).GetValue((int)value); }
        }

        /// <summary>
        /// Возвращает и задает имя заметки.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if(value.Length == 0)
                {
                    throw new ArgumentException("Note name cannot be empty");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("The number of characters in the title of the note cannot exceed 50");
                }
                else
                {
                    _name = value;
                }
            }
        }

        /// <summary>
        /// Возвращает и задает текст заметки.
        /// </summary>
        public string TextNote
        {
            get { return _textNote; }
            set { _textNote = value; }
        }

        /// <summary>
        /// Возвращает дату создани заметки.
        /// </summary>
        public DateTime DateCreation
        {
            get { return _dateCreation; }
        }

        /// <summary>
        /// Возвращает и задает дату последнего изменения заметки
        /// </summary>
        public DateTime TimeLastEdit
        {
            get { return _timeLastEdit; }
            set { _timeLastEdit = DateTime.Now; }
        }

        /// <summary>
        /// Создание копии заметки
        /// </summary>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}