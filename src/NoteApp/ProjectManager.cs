using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace NoteApp
{
    /// <summary>
    /// Менеджер проекта.
    /// </summary>
    static public class ProjectManager
    {
        /// <summary>
        /// Путь к сохраняему файлу
        /// </summary>
        private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                                      + "\\NoteApp\\NoteApp.json";

        public static string DefaultFilename { get; set; } = _path;

        /// <summary>
        /// Метод сохранения данных в файл с расширением json
        /// </summary>
        public static void SaveData(Project project, string filename)
        {
            CreateDirectory();
            JsonSerializer serializer = new JsonSerializer();

            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(filename))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем десериализацию
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Метод загрузки данных из файла с расширением json
        /// </summary>
        ///<param name="filename">
        ///Значение имени файла
        ///</param> 
        public static Project LoadData(string filename)
        {
            Project project;
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                //Открываем поток для чтения из файла с указанием пути
                using (StreamReader sr = new StreamReader(filename))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    //Вызываем десериализацию
                    project = serializer.Deserialize<Project>(reader);
                }
                return project;
            }
            catch
            {
                project = new Project();
                return project;
            }
        }
        private static void CreateDirectory()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\NoteApp";
            if (!System.IO.Directory.Exists(path))
            Directory.CreateDirectory(path);
        }
    }
}
