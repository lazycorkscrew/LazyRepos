﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalManager.PL;
using MedicalManager.Entities;

namespace MedicalManager
{
    public partial class ControlDoctor : UserControl
    {
        EnumTextBoxFocus inducedTextBox = EnumTextBoxFocus.None;
        Patient currentPatient = null;
        Patient currentPatient3 = null;
        History currentHistory3 = null;

        public ControlDoctor()
        {
            InitializeComponent();
            listBoxAnalyzes.DataSource = LogicProvider.Logic.GetAnalysisTypes();
            listBoxPatients.DataSource = LogicProvider.Logic.SearchPatientsByString(textBoxSearchPatient.Text) as List<PatientString>;
            listBoxResultSymptom.DataSource = LogicProvider.Logic.SearchSymptomsByString(textBoxSearchSymptom.Text) as List<Symptom>;
        }

        private void RunSearch(EnumTextBoxFocus focus)
        {
            inducedTextBox = focus;
            timerTextChangeEvent.Enabled = false;
            timerTextChangeEvent.Enabled = true;
        }

        private void SearchDiseases()
        {
            int selectedSymptomsCount = listBoxSelectedSymptoms.Items.Count;
            int[] symptomIds = new int[selectedSymptomsCount];

            for (int i = 0; i < selectedSymptomsCount; i++)
            {
                symptomIds[i] = (listBoxSelectedSymptoms.Items[i] as Symptom).Id;
            }

            listBoxResultDiagnoses.DataSource = LogicProvider.Logic.GetDiseasesBySymptoms(symptomIds);
        }

        private void buttonCreateNewPatient_Click(object sender, EventArgs e)
        {
            bool isCompleted = LogicProvider.Logic.CreateNewPatient(textBoxFname.Text, textBoxLname.Text, textBoxPatron.Text, textBoxSnils.Text, dateTimeBirth.Value);
            MessageBox.Show(isCompleted ? "Пациент добавлен успешно." : "Не удалось добавить пациента.");
        }

        private void timerTextChangeEvent_Tick(object sender, EventArgs e)
        {
            timerTextChangeEvent.Enabled = false;
            switch(inducedTextBox)
            {
                case EnumTextBoxFocus.SearchPatients: 
                    listBoxPatients.DataSource = LogicProvider.Logic.SearchPatientsByString(textBoxSearchPatient.Text) as List<PatientString>; break;
                case EnumTextBoxFocus.SearchPatients3:
                    listBoxPatients3.DataSource = LogicProvider.Logic.SearchPatientsByString(textBoxSearchPatients3.Text) as List<PatientString>; break;
                case EnumTextBoxFocus.SearchSymptom:
                    listBoxResultSymptom.DataSource = LogicProvider.Logic.SearchSymptomsByString(textBoxSearchSymptom.Text) as List<Symptom>; break;
               
                default: break;
            }

            inducedTextBox = EnumTextBoxFocus.None;
        }

        private void textBoxSearchPatient_TextChanged(object sender, EventArgs e)
        {
            RunSearch(EnumTextBoxFocus.SearchPatients);
        }

        private void listBoxPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPatient = LogicProvider.Logic.GetPatientById((listBoxPatients.SelectedItem as PatientString).Id);
            labelPatientInfo.Text = currentPatient.ToString();
        }

        private void textBoxSearchSymptom_TextChanged(object sender, EventArgs e)
        {
            RunSearch(EnumTextBoxFocus.SearchSymptom);
        }

        private void buttonAddSymptom_Click(object sender, EventArgs e)
        {
            foreach(object symptom in listBoxSelectedSymptoms.Items)
            {
                if(listBoxResultSymptom.SelectedItem.Equals(symptom))
                {
                    return;
                }
            }

            listBoxSelectedSymptoms.Items.Add(listBoxResultSymptom.SelectedItem);

            SearchDiseases();
        }

        private void buttonRemoveSymptom_Click(object sender, EventArgs e)
        {
            listBoxSelectedSymptoms.Items.Remove(listBoxSelectedSymptoms.SelectedItem);
            SearchDiseases();
        }

        private void buttonAddDiagnosis_Click(object sender, EventArgs e)
        {
            foreach (object diagnosis in listBoxSelectedDiagnoses.Items)
            {
                if (listBoxResultDiagnoses.SelectedItem.Equals(diagnosis))
                {
                    return;
                }
            }

            listBoxSelectedDiagnoses.Items.Add(listBoxResultDiagnoses.SelectedItem);
        }

        private void buttonRemoveDiagnosis_Click(object sender, EventArgs e)
        {
            listBoxSelectedDiagnoses.Items.Remove(listBoxSelectedDiagnoses.SelectedItem);
        }

        private void buttonAddAnalyzis_Click(object sender, EventArgs e)
        {
            listBoxSelectedAnalyzes.Items.Add(listBoxAnalyzes.SelectedItem);
        }

        private void buttonRemoveAnalyzis_Click(object sender, EventArgs e)
        {
            listBoxSelectedAnalyzes.Items.Remove(listBoxSelectedAnalyzes.SelectedItem);
        }

        private void buttonSaveNewHistory_Click(object sender, EventArgs e)
        {
            
            LogicProvider.Logic.CreateNewHistory(currentPatient.Id, 1, textBoxAnamnes.Text,
                listBoxSelectedSymptoms.Items.OfType<Symptom>(),
                listBoxSelectedDiagnoses.Items.OfType<Disease>(),
                listBoxSelectedAnalyzes.Items.OfType<AnalysisType>()
                );
            //textBoxAnamnes.Text
            //listBoxSelectedSymptoms.Items
            //listBoxSelectedDiagnoses.Items
            //listBoxSelectedAnalyzes.Items
        }

        private void textBoxSearchPatients3_TextChanged(object sender, EventArgs e)
        {
            RunSearch(EnumTextBoxFocus.SearchPatients3);
        }

        private void listBoxPatients3_SelectedIndexChanged(object sender, EventArgs e)
        {


            currentPatient3 = LogicProvider.Logic.GetPatientById((listBoxPatients3.SelectedItem as PatientString).Id);
            listBoxHistories.DataSource = LogicProvider.Logic.GetHistoriesByUserId(currentPatient3.Id);
        }

        private void listBoxHistories_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentHistory3 = listBoxHistories.SelectedItem as History;
            textBoxAnamnesis3.Text = currentHistory3.Anamnesis;
            textBoxPreDiagnoses.Text = string.Join(", ", LogicProvider.Logic.GetDiagnosesByHistoryId(currentHistory3.Id));
            listBoxAnalyses3.DataSource = LogicProvider.Logic.GetAnalysesByHistoryId(currentHistory3.Id);
        }

        private void listBoxAnalyses3_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelConclusion.Text = (listBoxAnalyses3.SelectedItem as Analysis).Conclusion;
        }
    }
}
