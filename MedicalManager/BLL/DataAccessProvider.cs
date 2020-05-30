using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManager.DAL;
using MedicalManager.IDAC;

namespace MedicalManager.BLL
{
    internal static class DataAccessProvider
    {
        internal static IDataAccessContracts DBAccessor { get; }

        static DataAccessProvider()
        {
            DBAccessor = new DBAccessor();
        }
    }
}
