﻿using System;
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
    }
}
