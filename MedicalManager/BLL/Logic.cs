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

        public bool RegisterNewUser(string login, string password, string fname, string lname, string patronymic, int role, int departmentId)
        {
            return DataAccessProvider.DBAccessor.RegisterNewUser(login, GetMD5Hash(password), fname, lname, patronymic, role, departmentId);
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

        public IEnumerable<Symptom> SearchSymptomsByString(string query)
        {
            return DataAccessProvider.DBAccessor.SearchSymptomsByString(query);
        }

        public IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<int> symptomIds)
        {
            List<Disease> diseases = DataAccessProvider.DBAccessor.GetDiseasesBySymptoms(symptomIds) as List<Disease>;
            int fullRate = 0;
            int diseasesCount = diseases.Count;

            foreach (Disease disease in diseases)
            {
                fullRate += disease.Rate;
            }
            
            for (int i = 0; i < diseasesCount; i++)
            {
                diseases[i].Percent = (float)diseases[i].Rate / (float)fullRate * 100;
            }

            return diseases;
        }

        public IEnumerable<AnalysisType> GetAnalysisTypes()
        {
            return DataAccessProvider.DBAccessor.GetAnalysisTypes();
        }

        public bool CreateNewHistory(int patientId, int status, string anamnesis, IEnumerable<Symptom> symptoms, IEnumerable<Disease> diagnoses, IEnumerable<AnalysisType> analyses)
        {
            //Создать историю и привязать к пациенту
            //Привязать симптомы
            //Привязать диагнозы
            //создать и привязать анализы
            return DataAccessProvider.DBAccessor.CreateNewHistory(patientId, status, anamnesis, symptoms, diagnoses, analyses);
        }

        public IEnumerable<History> GetHistoriesByUserId(int userId)
        {
            return DataAccessProvider.DBAccessor.GetHistoriesByUserId(userId);
        }

        public IEnumerable<string> GetDiagnosesByHistoryId(int historyId)
        {
            return DataAccessProvider.DBAccessor.GetDiagnosesByHistoryId(historyId);
        }

        public IEnumerable<Analysis> GetAnalysesByHistoryId(int historyId)
        {
            return DataAccessProvider.DBAccessor.GetAnalysesByHistoryId(historyId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return DataAccessProvider.DBAccessor.GetDepartments();
        }

        public IEnumerable<Role> GetRoles()
        {
            return DataAccessProvider.DBAccessor.GetRoles();
        }

        public bool CreateRegistrationRequest(string login, string password, string fname, string lname, string patronymic, int role, int departmentId, string phone)
        {
            return DataAccessProvider.DBAccessor.CreateRegistrationRequest(login, GetMD5Hash(password), fname, lname, patronymic, role, departmentId, phone);
        }

        public IEnumerable<EmployeeInfo> GetRegistrationRequests(string login, string password)
        {
            return DataAccessProvider.DBAccessor.GetRegistrationRequests(login, password);
        }

        public bool AcceptRegistrationRequest(int requestId, string login, string password)
        {
            return DataAccessProvider.DBAccessor.AcceptRegistrationRequest(requestId, login, password);
        }

        public bool RejectRegistrationRequest(int requestId, string login, string password)
        {
            return DataAccessProvider.DBAccessor.RejectRegistrationRequest(requestId, login, password);
        }

        public string GetDBConnectionString()
        {
            return DataAccessProvider.DBAccessor.GetDBConnectionString();
        }

        public bool SetDBConnectionString(string connectionString)
        {
            return DataAccessProvider.DBAccessor.SetDBConnectionString(connectionString);
        }

        public IEnumerable<Analysis> GetAnalysesByTypeId(int typeId)
        {
            return DataAccessProvider.DBAccessor.GetAnalysesByTypeId(typeId);
        }

        public bool SetConclusionByAnalysisId(int analysisId, string conclusion)
        {
            return DataAccessProvider.DBAccessor.SetConclusionByAnalysisId(analysisId, conclusion);
        }

        public DiseaseHistory GetHistoryById(int historyId)
        {
            return DataAccessProvider.DBAccessor.GetHistoryById(historyId);
        }

        public bool UpdateHistoryById(int historyId, string finalDiagnosis, string treatmentPlan)
        {
            return DataAccessProvider.DBAccessor.UpdateHistoryById(historyId, finalDiagnosis, treatmentPlan);
        }

        public bool SendMail(string mailto, string caption, string message, string[] attachFiles)
        {
            return DataAccessProvider.EmailAccessor.SendMail(mailto, caption, message, attachFiles);
        }

        public EmailSettings GetEmailSettings()
        {
            return DataAccessProvider.EmailAccessor.GetEmailSettings();
        }

        public bool SetEmailSettings(EmailSettings emailSettings)
        {
            return DataAccessProvider.EmailAccessor.SetEmailSettings(emailSettings);
        }

        public string GetReportText(int historyId)
        {
            //Загрузить всю известную инфу о истории болезни
            DiseaseHistory history = DataAccessProvider.DBAccessor.GetFullInfoByHistoryId(historyId);
            //Привязать жалобы
            IEnumerable<Symptom> symptoms = DataAccessProvider.DBAccessor.GetSymptomsByHistoryId(historyId);
            //Привязать предварительные диагнозы
            IEnumerable<string> diseases = DataAccessProvider.DBAccessor.GetDiagnosesByHistoryId(historyId);
            //Привязать анализы
            IEnumerable<Analysis> analyses = DataAccessProvider.DBAccessor.GetAnalysesByHistoryId(historyId);
            //
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"История болезни № {history.Id} от {history.Created:d}");
            sb.AppendLine();
            sb.AppendLine($"Пациент № {history.PatientId} - {history.Lname} {history.Fname} {history.Patronymic}, родился {history.DateBirth:d} г.");
            sb.AppendLine($"Поступление: {history.StatusText}");
            sb.AppendLine();
            sb.AppendLine($"Анамнез: ");
            sb.AppendLine($"{history.Anamnesis}");
            sb.AppendLine();

            sb.AppendLine($"Жалобы:");
            foreach (Symptom symptom in symptoms)
            {
                sb.AppendLine($"- {symptom.Name}");
            }
            sb.AppendLine();
            sb.AppendLine($"Предварительные диагнозы:");
            sb.AppendLine($"{string.Join(", ", diseases)}");
            sb.AppendLine();
            sb.AppendLine($"Назначенные анализы:");
            foreach(Analysis analysis in analyses)
            {
                sb.AppendLine($"\t{analysis.ShowName}, выполнен {analysis.DateCompleted:d}");
                sb.AppendLine($" - {analysis.Conclusion}");
            }
            sb.AppendLine();
            sb.AppendLine($"Окончательные диагнозы:");
            sb.AppendLine($"{history.FinalDiagnoses}");
            sb.AppendLine();
            sb.AppendLine($"План лечения:");
            sb.AppendLine($"{history.TreatmentPlan}");

            return sb.ToString();
        }

        public bool EditEmployee(string login, string password, int id, string fname, string lname, string patronymic, int role, int departmentId)
        {
            return DataAccessProvider.DBAccessor.EditEmployee(login, GetMD5Hash(password), id, fname, lname, patronymic, role, departmentId);
        }

        public IEnumerable<EmployeeInfo> GetEmployees()
        {
            return DataAccessProvider.DBAccessor.GetEmployees();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return DataAccessProvider.DBAccessor.GetEmployeeById(employeeId);
        }

        public bool DeleteEmployee(string login, string password, int employeeId)
        {
            return DataAccessProvider.DBAccessor.DeleteEmployee(login, GetMD5Hash(password), employeeId);
        }
    }
}
