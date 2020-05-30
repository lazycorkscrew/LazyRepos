using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManager.Entities;

namespace MedicalManager.IDAC
{
    public interface IDataAccessContracts
    {
        Employee GetEmployeeByLoginAndPassword(string login, string password);

        bool RegisterNewUser(string login, string password, string fname, string lname, string patronymic, int role);

        bool CreateNewPatient(string fname, string lname, string patronymic, string snils, DateTime dateBirth);

        IEnumerable<PatientString> SearchPatientsByString(string query);

        Patient GetPatientById(int id);
    }
}
