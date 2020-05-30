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
        EnumTextBoxFocus induced = EnumTextBoxFocus.None;
        Patient currentPatient = null;

        public ControlDoctor()
        {
            InitializeComponent();
        }

        private void RunSearch(EnumTextBoxFocus focus)
        {
            induced = focus;
            timerTextChangeEvent.Enabled = false;
            timerTextChangeEvent.Enabled = true;
        }

        private void buttonCreateNewPatient_Click(object sender, EventArgs e)
        {
            bool isCompleted = LogicProvider.Logic.CreateNewPatient(textBoxLname.Text, textBoxFname.Text, textBoxPatron.Text, textBoxSnils.Text, dateTimeBirth.Value);
            MessageBox.Show(isCompleted ? "Пациент добавлен успешно." : "Не удалось добавить пациента.");
        }

        private void timerTextChangeEvent_Tick(object sender, EventArgs e)
        {
            timerTextChangeEvent.Enabled = false;
            switch(induced)
            {
                case EnumTextBoxFocus.SearchPatients: 
                    listBoxPatients.DataSource = LogicProvider.Logic.SearchPatientsByString(textBoxSearchPatient.Text) as List<PatientString>; break;
                default: break;
            }

            induced = EnumTextBoxFocus.None;
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
    }
}
