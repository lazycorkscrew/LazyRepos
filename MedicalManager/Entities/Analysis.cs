using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManager.Entities
{
    public class Analysis
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string DateCreated { get; set; }
        public string DateCompleted { get; set; }
        public string Conclusion { get; set; }

        public string ShowName
        {
            get
            {
                return $"{DateCreated:f} {TypeName} № {Id}";
            }
        }
    }
}
