using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManager.Entities;

namespace MedicalManager.IBLC
{
    public interface ILogicContracts
    {
        string GetDBConnectionString();

        bool SetDBConnectionString(string connectionString);

        string GetMD5Hash(string input);

        Employee GetEmployeeByLoginAndPassword(string login, string password);

        bool RegisterNewUser(string login, string password, string fname, string lname, string patronymic, int role, int departmentId);

        bool CreateNewPatient(string fname, string lname, string patronymic, string snils, DateTime dateBirth);

        IEnumerable<PatientString> SearchPatientsByString(string query);

        IEnumerable<Symptom> SearchSymptomsByString(string query);

        Patient GetPatientById(int id);

        IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<int> symptomIds);

        IEnumerable<AnalysisType> GetAnalysisTypes();

        bool CreateNewHistory(int patientId, int status, string anamnesis, IEnumerable<Symptom> symptoms, IEnumerable<Disease> diagnoses, IEnumerable<AnalysisType> analyses);

        IEnumerable<History> GetHistoriesByUserId(int userId);

        IEnumerable<string> GetDiagnosesByHistoryId(int historyId);

        IEnumerable<Analysis> GetAnalysesByHistoryId(int historyId);

        IEnumerable<Department> GetDepartments();

        IEnumerable<Role> GetRoles();

        bool CreateRegistrationRequest(string login, string password, string fname, string lname, string patronymic, int role, int departmentId, string phone);

        //Функции, требующие права админа (нужен логин и пароль)
        IEnumerable<EmployeeInfo> GetRegistrationRequests(string login, string password);

        bool AcceptRegistrationRequest(int requestId, string login, string password);

        bool RejectRegistrationRequest(int requestId, string login, string password);

        bool EditEmployee(string login, string password, int id, string fname, string lname, string patronymic, int role, int departmentId);

        //
        IEnumerable<Analysis> GetAnalysesByTypeId(int typeId);

        bool SetConclusionByAnalysisId(int analysisId, string conclusion);

        DiseaseHistory GetHistoryById(int historyId);

        bool UpdateHistoryById(int historyId, string finalDiagnosis, string treatmentPlan);



        //Электронная почта
        bool SendMail(string mailto, string caption, string message, string[] attachFiles);

        EmailSettings GetEmailSettings();

        bool SetEmailSettings(EmailSettings emailSettings);
        //

        string GetReportText(int historyId);

        IEnumerable<EmployeeInfo> GetEmployees();

        Employee GetEmployeeById(int employeeId);

        bool DeleteEmployee(string login, string password, int employeeId);
    }
}
