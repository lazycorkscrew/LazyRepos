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
        public string connectionString = Properties.SettingsDB.Default.ConnectionString; //"Data Source=ХИМИК-ПК\\SQLEXPRESS; Initial Catalog=MedicalDB; Integrated Security=True";// False; User Id=; Password=" 

        public bool AcceptRegistrationRequest(int requestId, string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AcceptRegistrationRequest", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", requestId);
                command.Parameters.AddWithValue("@adminLogin", login);
                command.Parameters.AddWithValue("@adminPassword", password);
                connection.Open();
                try
                {
                    int result = command.ExecuteNonQuery();
                    return result == 2;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool CreateNewHistory(int patientId, int status, string anamnesis, IEnumerable<Symptom> symptoms, IEnumerable<Disease> diagnoses, IEnumerable<AnalysisType> analyses)
        {
            int historyId = 0;

            //createHistoryPart
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("exec [CreateNewHistoryAndReturnId] @patientId, @anamnes, @status", connection);
                command.Parameters.AddWithValue("@patientId", patientId);
                command.Parameters.AddWithValue("@anamnes", anamnesis);
                command.Parameters.AddWithValue("@status", status);
                connection.Open();
                SqlDataReader reader = null;
                try
                {
                    reader = command.ExecuteReader();
                }
                catch (SqlException ex)
                {
                    return false;
                }

                if (reader.Read())
                {
                    historyId = (int)reader["Id"];

                    StringBuilder sb = new StringBuilder();

                    //SymptomsPart
                    foreach(Symptom symptom in symptoms)
                    {
                        sb.AppendLine($"insert into LinksHistorySymptoms (HistoryId, SymptomId) values ({historyId}, {symptom.Id})");
                    }

                    //DiagnosesPart
                    foreach (Disease disease in diagnoses)
                    {
                        sb.AppendLine($"insert into LinksHistoryDisease (HistoryId, DiseaseId) values ({historyId}, {disease.Id})");
                    }

                    //AnalysesPart
                    foreach (AnalysisType analysis in analyses)
                    {
                        sb.AppendLine($"insert into Analysis (HistoryId, TypeId) values ({historyId}, {analysis.Id})");
                    }

                    string str = sb.ToString();
                    reader.Close();
                    reader = null;
                    command = new SqlCommand(str, connection);
                    //connection.Open();
                    try
                    {
                        return command.ExecuteNonQuery() >= 1;
                    }
                    catch (SqlException ex)
                    {
                        return false;
                    }
                }

                return false; 
            }
        }

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

        public bool CreateRegistrationRequest(string login, string password, string fname, string lname, string patronymic, int role, int departmentId, string phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CreateRegistrationRequest", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@fname", fname);
                command.Parameters.AddWithValue("@lname", lname);
                command.Parameters.AddWithValue("@patronymic", patronymic);
                command.Parameters.AddWithValue("@role", role);
                command.Parameters.AddWithValue("@departmentId", departmentId);
                command.Parameters.AddWithValue("@phone", phone);
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

        public IEnumerable<Analysis> GetAnalysesByHistoryId(int historyId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetAnalysesByHistoryId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@historyId", historyId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Analysis> analyses = new List<Analysis>();

                while (reader.Read())
                {
                    analyses.Add(new Analysis
                    {
                        Id = (int)reader["Id"],
                        TypeName = (string)reader["TypeName"],
                        DateCreated = ($"{(DateTime)reader["DateCreated"]:d}"),
                        DateCompleted = reader.IsDBNull(3)? null : ($"{(DateTime)reader["DateCompleted"]:d}"), 
                        Conclusion = reader.IsDBNull(4)? "(Анализ ещё не готов)" : reader["conclusion"] as string
                    });
                }

                return analyses;
            }
        }

        public IEnumerable<AnalysisType> GetAnalysisTypes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetAnalysisTypes", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<AnalysisType> analysisTypes = new List<AnalysisType>();

                while (reader.Read())
                {
                    analysisTypes.Add(new AnalysisType
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["TypeName"],
                    });
                }

                return analysisTypes;
            }
        }

        public string GetDBConnectionString()
        {
            return connectionString;
        }

        public IEnumerable<Department> GetDepartments()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetDepartments", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Department> departments = new List<Department>();

                while (reader.Read())
                {
                    departments.Add(new Department
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["DepartmentName"],
                    });
                }

                return departments;
            }
        }

        public IEnumerable<string> GetDiagnosesByHistoryId(int historyId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetDiagnosesByHistoryId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@historyId", historyId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<string> diagnoses = new List<string>();

                while (reader.Read())
                {
                    diagnoses.Add((string)reader["DiseaseName"]);
                }

                return diagnoses;
            }
        }

        public IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<int> symptomIds)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("if object_id('tempdb..#SymptomIDs') is not null drop table #SymptomIDs CREATE TABLE #SymptomIDs (Value INT)");
            foreach(int symptomId in symptomIds)
            {
                sb.AppendLine($"insert into #SymptomIDs (Value) values ({symptomId})");
            }

            sb.AppendLine("exec [GetDiseasesBySymptoms]");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sb.ToString(), connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Disease> diseases = new List<Disease>();

                while (reader.Read())
                {
                    diseases.Add(new Disease
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["DiseaseName"],
                        Rate = (int)reader["ResRate"]
                    });
                }

                return diseases;
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

        public IEnumerable<History> GetHistoriesByUserId(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetHistoriesByUserId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userId", userId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<History> histories = new List<History>();

                while (reader.Read())
                {
                    histories.Add(new History
                    {
                        Id = (int)reader["Id"],
                        Name = $"{(DateTime)reader["Created"]:F}",
                        Anamnesis = (string)reader["Anamnesis"]
                    });
                }

                return histories;
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

        public IEnumerable<EmployeeInfo> GetRegistrationRequests(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetRegistrationRequests", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<EmployeeInfo> employees = new List<EmployeeInfo>();

                while (reader.Read())
                {
                    employees.Add(new EmployeeInfo
                    {
                        Id = (int)reader["Id"],
                        Info = (string)reader["Info"]
                    });
                }

                return employees;
            }
        }

        public IEnumerable<Role> GetRoles()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetRoles", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                List<Role> roles = new List<Role>();

                while (reader.Read())
                {
                    roles.Add(new Role
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                    });
                }

                return roles;
            }
        }

        public bool RegisterNewUser(string login, string password, string fname, string lname, string patronymic, int role, int departmentId)
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
                command.Parameters.AddWithValue("@departmentId", departmentId);
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

        public bool RejectRegistrationRequest(int requestId, string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("RejectRegistrationRequest", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", requestId);
                command.Parameters.AddWithValue("@adminLogin", login);
                command.Parameters.AddWithValue("@adminPassword", password);
                connection.Open();
                try
                {
                    int result = command.ExecuteNonQuery();
                    return result == 1;
                }
                catch (Exception ex)
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

        public IEnumerable<Symptom> SearchSymptomsByString(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SearchSymptomsByString", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@queryString", query);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Symptom> patients = new List<Symptom>();

                while (reader.Read())
                {
                    patients.Add(new Symptom
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["SymptomName"],
                    });
                }

                return patients;
            }
        }

        public bool SetDBConnectionString(string connectionString)
        {
            try
            {
                this.connectionString = connectionString;
                Properties.SettingsDB.Default.ConnectionString = connectionString;
                Properties.SettingsDB.Default.Save();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
