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
        string GetDBConnectionString();

        bool SetDBConnectionString(string connectionString);

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

        IEnumerable<EmployeeInfo> GetRegistrationRequests(string login, string password);

        bool AcceptRegistrationRequest(int requestId, string login, string password);

        bool RejectRegistrationRequest(int requestId, string login, string password);

        IEnumerable<Analysis> GetAnalysesByTypeId(int typeId);

        bool SetConclusionByAnalysisId(int analysisId, string conclusion);
    }
}
