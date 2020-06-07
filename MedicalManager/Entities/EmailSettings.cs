using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManager.Entities
{
    public class EmailSettings
    {
        public string Host { get; set; }
        public decimal Port { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool EnableSSL { get; set; }

    }
}
