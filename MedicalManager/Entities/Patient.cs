using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManager.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Patronymic { get; set; }
        public string SNILS { get; set; }
        public DateTime DateBirth { get; set; }

        public override string ToString()
        {
            return $"{Lname} {Fname} {Patronymic}, {SNILS}, {DateBirth:d}";
        }
    }
}
