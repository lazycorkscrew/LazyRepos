using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MedicalManager.IBLC;
using MedicalManager.Entities;
using System.Runtime.InteropServices;

namespace MedicalManager.BLL
{
    public class Logic : ILogicContracts
    {
        public string GetMD5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append((data[i]).ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public bool RegisterNewUser(string login, string password, string fname, string lname, string patronymic, int role)
        {
            return DataAccessProvider.DBAccessor.RegisterNewUser(login, GetMD5Hash(password), fname, lname, patronymic, role);
        }

        public Employee GetEmployeeByLoginAndPassword(string login, string password)
        {
            return DataAccessProvider.DBAccessor.GetEmployeeByLoginAndPassword(login, password);
        }

        public bool CreateNewPatient (string fname, string lname, string patronymic, string snils, DateTime dateBirth)
        {
            return DataAccessProvider.DBAccessor.CreateNewPatient(fname, lname, patronymic, snils, dateBirth);
        }

        public IEnumerable<PatientString> SearchPatientsByString(string query)
        {
            return DataAccessProvider.DBAccessor.SearchPatientsByString(query);
        }

        public Patient GetPatientById(int id)
        {
            return DataAccessProvider.DBAccessor.GetPatientById(id);
        }
    }
}
