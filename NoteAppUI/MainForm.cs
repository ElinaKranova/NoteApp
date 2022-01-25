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
    /// Класс главной формы программы.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Проект, в котором хранятся данные о заметках.
        /// </summary>
        private Project _project;

        /// <summary>
        /// Заметки, которые в данный момент находятся в listBoxNote.
        /// </summary>
        private List<Note> _currentNotes;

        /// <summary>
        /// Создает экземпляр MainForm.
        /// </summary>  
        public MainForm()
        {
            InitializeComponent();
            InitComboBox();
            _project = ProjectManager.LoadData(ProjectManager.DefaultFilename);
            UpdateNoteListBox();
        }

        /// <summary>
        /// Метод заполнение ComboBoxCategory.
        /// </summary>
        private void InitComboBox()
        {
            var valuesAsList = Enum.GetValues(typeof(NoteCategory)).Cast<Object>().ToArray();
            comboBoxCategory.Items.Add("All");
            comboBoxCategory.Items.AddRange(valuesAsList);
            comboBoxCategory.SelectedIndex = 0;
        }

        /// <summary>
        /// Метод удаления заметки,
        /// </summary>
        private void RemoveNote()
        {
            if (listBoxNote.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Remove note: " + listBoxNote.SelectedItem +
                                                        "?",
                                                        "Message",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question); ;
                if (result == DialogResult.OK)
                {
                    _project.Notes.Remove(_currentNotes[listBoxNote.SelectedIndex]);
                    _currentNotes.RemoveAt(listBoxNote.SelectedIndex);
                    listBoxNote.Items.RemoveAt(listBoxNote.SelectedIndex);
                    ProjectManager.SaveData(_project, ProjectManager.DefaultFilename);
                    UpdateNoteListBox();
                }
            }
            else
            {
                MessageBox.Show("Note not selected");
            }
        }

        /// <summary>
        /// Метод создания новой формы NoteForm,
        /// для редактирования заметки.
        /// </summary>
        private void EditNote()
        {
            if (listBoxNote.SelectedItem != null)
            {
                NoteForm noteForm = new NoteForm();
                noteForm.Note = _currentNotes[listBoxNote.SelectedIndex];
                DialogResult result = noteForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _project.Notes.RemoveAt(listBoxNote.SelectedIndex);
                    _project.Notes.Insert(listBoxNote.SelectedIndex, noteForm.Note);
                }
                    _project.Notes = _project.SortNotes(_project.Notes);
                UpdateNoteListBox();
            }
            else
            {
                MessageBox.Show("Note not selected");
            }
        }

        /// <summary>
        /// Метод создания новой формы AddEditeNote,
        /// для добавления новой заметки.
        /// </summary>
        private void AddNote()
        {
            NoteForm noteForm = new NoteForm();
            DialogResult result = noteForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Note newNote = noteForm.Note;
                _project.Notes.Add(newNote);
                _project.Notes = _project.SortNotes(_project.Notes);
            }
            UpdateNoteListBox();
        }

        /// <summary>
        /// Метод замолнения ListBox заметками,
        /// которые относятся к текущей категории в
        /// comboBoxCategory
        /// </summary>
        private void UpdateNoteListBox()
        {
            if (_project != null)
            {
                ClearAllFields();
                listBoxNote.Items.Clear();
                _currentNotes = new List<Note>();
                for (int i = 0; i < _project.Notes.Count; i++)
                {
                    if (comboBoxCategory.SelectedItem.ToString() == "All" ||
                        _project.Notes[i].Category == (NoteCategory)comboBoxCategory.SelectedItem)
                    {
                        listBoxNote.Items.Add(_project.Notes[i].Name);
                        _currentNotes.Add(_project.Notes[i]);
                    }
                }
                if (listBoxNote.Items.Count >= 1)
                {
                    listBoxNote.SetSelected(0, true);
                }
            }
        }


        /// <summary>
        /// Метод очищения всех информационных полей о заметке.
        /// </summary>
        private void ClearAllFields()
        {
            textCurrentNote.Text = "";
            labelNameCurrentNote.Text = "";
            dateCreation.Visible = false;
            dateModifiend.Visible = false;
        }

        private void listBoxNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            Note tempNote = new Note();
            if (listBoxNote.SelectedIndex >= 0)
            {
                if (comboBoxCategory.SelectedItem.ToString() == "All")
                {
                    tempNote = _project.Notes[listBoxNote.SelectedIndex];
                }
                else
                {
                    tempNote = _currentNotes[listBoxNote.SelectedIndex];
                }
            }
            labelNameCurrentNote.Text = tempNote.Name;
            textCurrentNote.Text = tempNote.Text;
            dateModifiend.Visible = dateCreation.Visible = true;
            dateCreation.Value = tempNote.CreatedAt;
            dateModifiend.Value = tempNote.ModifiedAt;
            labelNameCurrentCategory.Text = Enum.GetName(typeof(NoteCategory), tempNote.Category);
        }

        private void listBoxNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveNote();
            }
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e) => UpdateNoteListBox();

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e) => new About().ShowDialog();

        private void ImageAddNote_Click(object sender, EventArgs e) => AddNote();

        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e) => AddNote();

        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e) => EditNote();

        private void ImageEditNote_Click(object sender, EventArgs e) => EditNote();

        private void ImageRemoveNote_Click(object sender, EventArgs e) => RemoveNote();

        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e) => RemoveNote();

    }
}