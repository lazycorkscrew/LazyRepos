using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManager.Entities
{
    public class Disease
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rate { get; set; }
        public float Percent { get; set; }

        public string NamePercent
        {
            get
            {
                return $"{Name} ({Math.Round(Percent, 2)} %)";
            }
        }
    }
}
