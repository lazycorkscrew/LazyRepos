using System;
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
        DiseaseHistory currentHistory3 = null;

        public ControlDoctor()
        {
            InitializeComponent();
            listBoxAnalyzes.DataSource = LogicProvider.Logic.GetAnalysisTypes();
            listBoxPatients.DataSource = LogicProvider.Logic.SearchPatientsByString(textBoxSearchPatient.Text) as List<PatientString>;
            listBoxPatients3.DataSource = LogicProvider.Logic.SearchPatientsByString(textBoxSearchPatient.Text) as List<PatientString>;
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

        private void SearchAnalyses()
        {
            int selectedDiseasesCount = listBoxSelectedDiagnoses.Items.Count;
            int[] diseaseIds = new int[selectedDiseasesCount];

            for (int i = 0; i < selectedDiseasesCount; i++)
            {
                diseaseIds[i] = (listBoxSelectedDiagnoses.Items[i] as Disease).Id;
            }

            listBoxAnalyzes.DataSource = LogicProvider.Logic.GetAnalysesByDiseases(diseaseIds);
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


            if(checkBoxAllAnalyses.Checked)
            {
                listBoxAnalyzes.DataSource = LogicProvider.Logic.GetAnalysisTypes();
            }
            else
            {
                SearchAnalyses();
            }
        }

        private void buttonRemoveDiagnosis_Click(object sender, EventArgs e)
        {
            listBoxSelectedDiagnoses.Items.Remove(listBoxSelectedDiagnoses.SelectedItem);

            if (checkBoxAllAnalyses.Checked)
            {
                listBoxAnalyzes.DataSource = LogicProvider.Logic.GetAnalysisTypes();
            }
            else
            {
                SearchAnalyses();
            }
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
            label23.Text = $"Пациент {currentPatient3.Lname} {currentPatient3.Fname} {currentPatient3.Patronymic} {currentPatient3.DateBirth:d} {currentPatient3.SNILS}";
            if(listBoxHistories.Items.Count == 0)
            {
                textBoxAnamnes.Clear();
                textBoxPreDiagnoses.Clear();
                textBoxFinalDiagnoses.Clear();
                labelConclusion.Text = "...";
                listBoxAnalyses3.DataSource = null;
                listBoxAnalyses3.Items.Clear();
                textBoxTreatmentPlan.Clear();

            }
        }

        private void listBoxHistories_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentHistory3 = LogicProvider.Logic.GetHistoryById( (listBoxHistories.SelectedItem as History).Id);
            textBoxAnamnesis3.Text = currentHistory3.Anamnesis;
            textBoxPreDiagnoses.Text = string.Join(", ", LogicProvider.Logic.GetDiagnosesByHistoryId(currentHistory3.Id));
            textBoxFinalDiagnoses.Text = currentHistory3.FinalDiagnoses;
            textBoxTreatmentPlan.Text = currentHistory3.TreatmentPlan;
            listBoxAnalyses3.DataSource = LogicProvider.Logic.GetAnalysesByHistoryId(currentHistory3.Id);
        }

        private void listBoxAnalyses3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labelConclusion.Text = (listBoxAnalyses3.SelectedItem as Analysis)?.Conclusion?? "...";
            }
            catch(Exception ex)
            {
                labelConclusion.Text = "...";
            }
        }

        private void linkLabelCopyFromPrevDia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxFinalDiagnoses.Text = textBoxPreDiagnoses.Text;
        }

        private void buttonSaveCurrentHistory_Click(object sender, EventArgs e)
        {
            bool historyUpdated = LogicProvider.Logic.UpdateHistoryById(currentHistory3.Id, textBoxFinalDiagnoses.Text, textBoxTreatmentPlan.Text);
            string message = (historyUpdated ? "Данные обновлены." : "Ошибка обновления данных. Обратитесь к администратору.");
            MessageBox.Show(message, "Уведомление");
        }

        private void linkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxAnamnes.Text = string.Empty;
            listBoxSelectedSymptoms.DataSource = null;
            listBoxSelectedSymptoms.Items.Clear();
            listBoxSelectedDiagnoses.DataSource = null;
            listBoxSelectedDiagnoses.Items.Clear();
            listBoxSelectedAnalyzes.DataSource = null;
            listBoxSelectedAnalyzes.Items.Clear();
        }

        private void checkBoxAllAnalyses_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAllAnalyses.Checked)
            {
                listBoxAnalyzes.DataSource = LogicProvider.Logic.GetAnalysisTypes();
            }
            else
            {
                SearchAnalyses();
            }
        }
    }
}
