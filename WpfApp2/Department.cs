using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
   public class Department
    {
        /// <summary>
        /// Название департамента
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// ID департамента
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Конструктор Департамента 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Id"></param>
        public Department(string Name, int Id)
        {
            DepartmentName = Name;
            DepartmentId = Id;
        }

    }
}
