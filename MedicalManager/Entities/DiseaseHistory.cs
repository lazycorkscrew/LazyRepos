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
        public int Status { get; set; }
        public string Anamnes { get; set; }
        public string FinalDiagnoses { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<int> SymptomIds { get; set; }
        public IEnumerable<int> DiseaseIds { get; set; }
        public IEnumerable<int> AnalysisIds { get; set; }
    }
}
