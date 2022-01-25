using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    /// <summary>
    /// Класс формы работы с заметками: Редактирование и добавление заметок.
    /// </summary>
    public partial class NoteForm : Form
    {
        /// <summary>
        /// Редактируемая заметка.
        /// </summary>
        private Note _note = new Note();

        /// <summary>
        /// Клон редактируемой заметки.
        /// </summary>
        private Note _tempNote = new Note();

        public Note Note
        {
            get
            {
                _note.Text =textBoxTextNote.Text;
                if (textBoxNameNote.Text == "")
                {
                    string noteName = "Untitled";
                    textBoxNameNote.Text = noteName;
                }
                _note.Name = textBoxNameNote.Text;
                _note.Category = (NoteCategory)comboBoxCategory.SelectedItem;
                return _note;
            }
            set
            {
                if (value != null) 
                {
                    textBoxNameNote.Text = value.Name;
                    value.ModifiedAt = DateTime.Now;
                    textBoxTextNote.Text = value.Text;
                    comboBoxCategory.SelectedItem = value.Category;
                }
            }
        }

        /// <summary>
        /// Создает экземпляр AddEditNote добавления новой заметки.
        /// </summary>
        /// <param name="project">Проект, в котором хранятся заметки.</param>
        public NoteForm()
        {
            InitializeComponent();
            InitComboBox();
        }

        /// <summary>
        /// Метод заполнение ComboBoxCategory.
        /// </summary>
        private void InitComboBox()
        {
            var valuesAsList = Enum.GetValues(typeof(NoteCategory)).Cast<Object>().ToArray();
            comboBoxCategory.Items.AddRange(valuesAsList);
            comboBoxCategory.SelectedIndex = 0;
        }

        private void textBoxNameNote_TextChanged(object sender, EventArgs e)
        {

            try
            {
                textBoxNameNote.BackColor = Color.White;
                _tempNote.Name = textBoxNameNote.Text;
            }
            catch 
            {
                textBoxNameNote.BackColor = Color.FromArgb(0xFF, 0x55, 0x55);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                //_note.Name = _tempNote.Name;
                //_note.Text = _tempNote.Text;
                //_note.Category = _tempNote.Category;
                //_note.ModifiedAt = DateTime.Now;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Input error",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information);
            }
        }

        private void textBoxTextNote_TextChanged(object sender, EventArgs e)
        {
            if (_tempNote != null)
                _tempNote.Text = textBoxTextNote.Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_tempNote != null)
                _tempNote.Category = (NoteCategory)comboBoxCategory.SelectedItem;
        }
    }
}
