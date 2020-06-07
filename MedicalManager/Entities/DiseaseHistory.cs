using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManager.Entities
{
    public class DiseaseHistory
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime Created { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public string Anamnesis { get; set; }
        public string FinalDiagnoses { get; set; }
        public string TreatmentPlan { get; set; }
    }
}
