using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace NoteApp.UnitTests
{
    class ProjectManagerTest
    {
        /// <summary>
        /// Путь к папке сохраняемых данных.
        /// </summary>
        private static string _pathFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteAppTest";
        /// <summary>
        /// Проект с заметками.
        /// </summary>
        private Project _project;
        /// <summary>
        /// Заметка для заполнения данных.
        /// </summary>
        private Note _note;

        [SetUp]
        public void InitNote()
        {
            _note = new Note();
            _note.Name = "123";
            _project = new Project();
            _project.Notes = new List<Note>();
            _project.Notes.Add(_note);
            CreatedDirectory();
        }

        [Test(Description = "LoadingProperlySavedProjectFile")]
        public void TestLoadingProperlySavedProjectFile_CorrectValue()
        {
            bool ifEqual = true;
            File.Delete(_pathFile + "\\NoteApp.json");
            ProjectManager.SaveData(_project, _pathFile + "\\NoteApp.json");
            var actual = ProjectManager.LoadData(_pathFile + "\\NoteApp.json");
            for (int i = 0; i < _project.Notes.Count && i < actual.Notes.Count; i++)
            {
                if (!(_project.Notes[i].Name == actual.Notes[i].Name &&
                    _project.Notes[i].TextNote == actual.Notes[i].TextNote &&
                    _project.Notes[i].Category == actual.Notes[i].Category))
                {
                    ifEqual = false;
                    i = _project.Notes.Count + actual.Notes.Count;
                }
            }
            Assert.AreEqual(true, ifEqual, "The file data was saved incorrectly");
        }

        [Test(Description = "Uploading a nonexistent file")]
        public void TestDownloadingNonExistentFilet_NonexistentFile()
        {
            File.Delete(_pathFile + "\\NoteApp.json");
            File.Delete(_pathFile + "\\NoteApp.txt");
            Assert.Throws<FileNotFoundException>(
            () => { _project = ProjectManager.LoadData(_pathFile + "\\NoteApp.json"); },
            "An exception should be thrown if there was an error loading the file");
        }

        [Test(Description = "Uploading a corrupted file")]
        public void TestDownloadingIncorrectlySavedFile_IncorrectLoading()
        {
            File.Delete(_pathFile + "\\NoteApp.json");
            File.WriteAllText(_pathFile + "\\NoteApp.json", "Error");
            Assert.Throws<JsonReaderException>(
            () => { ProjectManager.LoadData(_pathFile + "\\NoteApp.json"); },
            "An exception should be thrown if there was an error loading the file");
        }

        /// <summary>
        /// Создание папки, где хранятся данные.
        /// </summary>
        private static void CreatedDirectory()
        {
            if (!System.IO.Directory.Exists(_pathFile))
                Directory.CreateDirectory(_pathFile);
        }
    }
}