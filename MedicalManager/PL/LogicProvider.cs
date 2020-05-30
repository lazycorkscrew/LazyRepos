using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManager.BLL;
using MedicalManager.IBLC;

namespace MedicalManager.PL
{
    public static class LogicProvider
    {
        public static ILogicContracts Logic { get; }

        static LogicProvider()
        {
            Logic = new Logic();
        }
    }
}
