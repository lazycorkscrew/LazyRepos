using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManager.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Patronymic { get; set; }
        public string Role { get; set; }
        public int RoleId { get; set; }
        public int Power { get; set; }
        public int DepartmentId { get; set; }
        public string Phone { get; set; }
    }
}
