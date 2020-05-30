using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManager.IDAC;
using MedicalManager.Entities;

namespace MedicalManager.DAL
{
    public class DBAccessor : IDataAccessContracts
    {
        public static string connectionString = "Data Source=ХИМИК-ПК\\SQLEXPRESS; Initial Catalog=MedicalDB; Integrated Security=True";// False; User Id=; Password=" 

        public bool CreateNewPatient(string fname, string lname, string patronymic, string snils, DateTime dateBirth)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CreateNewPatient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@fname", fname);
                command.Parameters.AddWithValue("@lname", lname);
                command.Parameters.AddWithValue("@patronymic", patronymic);
                command.Parameters.AddWithValue("@snils", snils);
                command.Parameters.AddWithValue("@datebirth", dateBirth);
                connection.Open();
                try
                {
                    return command.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public Employee GetEmployeeByLoginAndPassword(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeeByLoginAndPassword", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                SqlDataReader reader = null;
                try
                {
                    reader = command.ExecuteReader();
                }
                catch (SqlException ex)
                {
                    return null;
                }

                if (reader.Read())
                {
                    return new Employee
                    {
                        Id = (int)reader["Id"],
                        Fname = (string)reader["Fname"],
                        Lname = (string)reader["Lname"],
                        Patronymic = (string)reader["Patronymic"],
                        Role = (string)reader["Role"],
                        Power = (int)reader["Power"]
                    };
                }

                return null;
            }
        }

        public Patient GetPatientById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetPatientById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Patient
                    {
                        Id = (int)reader["Id"],
                        Fname = (string)reader["Fname"],
                        Lname = (string)reader["Lname"],
                        Patronymic = (string)reader["Patronymic"],
                        SNILS = (string)reader["InsurancePolicy"],
                        DateBirth = (DateTime)reader["DateBirth"]
                    };
                }

                return null;
            }
        }

        public bool RegisterNewUser(string login, string password, string fname, string lname, string patronymic, int role)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RegisterUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@fname", fname);
                command.Parameters.AddWithValue("@lname", lname);
                command.Parameters.AddWithValue("@patronymic", patronymic);
                command.Parameters.AddWithValue("@role", role);
                connection.Open();
                try
                {
                    return command.ExecuteNonQuery() == 1;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public IEnumerable<PatientString> SearchPatientsByString(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SearchPatientsByString", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@queryString", query);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<PatientString> patients = new List<PatientString>();

                while(reader.Read())
                {
                    patients.Add(new PatientString
                    {
                        Id = (int)reader["Id"],
                        FullInfo = (string)reader["fullInfo"],
                    });
                }

                return patients;
            }
        }
    }
}
