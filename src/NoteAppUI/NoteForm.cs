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
        private Note _note;

        /// <summary>
        /// Клон редактируемой заметки.
        /// </summary>
        private Note _tempNote;

        /// <summary>
        /// Создает экземпляр AddEditNote добавления новой заметки.
        /// </summary>
        /// <param name="project">Прокет, в котором хранятся заметки.</param>
        public NoteForm(Note note)
        {
            InitializeComponent();
            InitializationComboBox();
            _note = note;
            _tempNote = (Note)_note.Clone();
            _tempNote.ModifiedAt = DateTime.Now;
            comboBoxCategory.SelectedIndex = (int)_tempNote.Category;
            textBoxNameNote.Text = _tempNote.Name;
            textBoxTextNote.Text = _tempNote.Text;
        }

        /// <summary>
        /// Метод заполнение ComboBoxCategory.
        /// </summary>
        private void InitializationComboBox()
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
                _note.Name = _tempNote.Name;
                _note.Text = _tempNote.Text;
                _note.Category = _tempNote.Category;
                Close();
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Input error",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information);
            }
        }

        private void textBoxTextNote_TextChanged(object sender, EventArgs e)
        {
            if (_tempNote != null)
                _tempNote.Text = textBoxTextNote.Text;
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_tempNote != null)
                _tempNote.Category = (NoteCategory)comboBoxCategory.SelectedItem;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NoteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
