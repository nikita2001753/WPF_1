using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp2
{
   public class Workers 
    {
        /// <summary>
        /// Имя работника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст  работника
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// ID департамента, в котором находится работник
        /// </summary>
        public int DepartamentId { get; set; }

        public Workers()
        {

        }

        /// <summary>
        /// Конструктор Работника
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="age"></param>
        /// <param name="DepId"></param>
        public Workers(string Name, int age, int DepId)
        {
            this.Name = Name;
            this.Age = age;
            this.DepartamentId = DepId;
        }
    }
}
