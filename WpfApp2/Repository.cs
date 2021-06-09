using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace WpfApp2
{
    public class Repository
    {
        static Random r;
        static Repository() { r = new Random(); }

        /// <summary>
        /// Коллекция работников
        /// </summary>
        public List<Workers> WorkersDb { get; set; }

        /// <summary>
        /// Коллекция департаментов
        /// </summary>
        public List<Department> DepartmentsDb { get; set; }

        #region Конструктор
        

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="CountDepartment"></param>
        /// <param name="CountEmployee"></param>
        private Repository(int CountDepartment, int CountEmployee)
        {
            WorkersDb = new List<Workers>();
            DepartmentsDb = new List<Department>();

            //Создание департаментов и добавление их в коллекцию департаментов
            for (int i = 0; i < CountDepartment; i++)
            {
                DepartmentsDb.Add(new Department($"Департамент {i + 1}", i));
            }

            //Создание работников и добавление их в Коллекцию работников 
            for (int i = 0; i < CountEmployee; i++)
            {
                WorkersDb.Add(
                        new Workers($"Имя_{i + 1}",
                                     r.Next(18, 30),
                                     r.Next(DepartmentsDb.Count)));
            }
            
        }
        public static Repository CreateRepository(int CountDepartment = 10, int CountEmployee = 300)
        {
            return new Repository(CountDepartment, CountEmployee);
        }

        #endregion

        #region Методы

        /// <summary>
        /// Серилизация Работников XML
        /// </summary>
        public void SerializeWorker(string Path)
        {
            //Создаем сериализатор, на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Workers>));

            //Создаем поток, для сохранения данных
            Stream fstream = new FileStream(Path, FileMode.Create, FileAccess.Write);

            //Запускаем процесс сериализации
            xmlSerializer.Serialize(fstream, WorkersDb);

            //Закрыть поток
            fstream.Close();
        }


        /// <summary>
        /// Десериализация Работников XML
        /// </summary>
        public void DeserializeWorker(string Path)
        {
            List<Workers> NewWorkers = new List<Workers>();

            //Создаем сериализатор, на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Workers>));

            //Создаем поток, для чтения данных
            Stream fstream = new FileStream(Path, FileMode.Open, FileAccess.Read);

            //Запускаем процесс Десериализации
            NewWorkers = xmlSerializer.Deserialize(fstream) as List<Workers>;

            WorkersDb = NewWorkers;

            //Закрыть поток
            fstream.Close();


        }


        /// <summary>
        /// Серилизация Работников JSON
        /// </summary>
        public void SerializeWorkerJSON(string Path)
        {
            string json = JsonConvert.SerializeObject(WorkersDb);

            File.WriteAllText(Path, json);

        }

        /// <summary>
        /// Десериализация Работников JSON
        /// </summary>
        public void DeserializeWorkerJSON(string Path)
        {
            string json = File.ReadAllText(Path);

            WorkersDb = JsonConvert.DeserializeObject<List<Workers>>(json);

        }



        /// <summary>
        /// Метод удаляет всех работников
        /// </summary>
        public void ClearWorkers()
        {
            WorkersDb.Clear();
        }
    

        #endregion

    }
}
