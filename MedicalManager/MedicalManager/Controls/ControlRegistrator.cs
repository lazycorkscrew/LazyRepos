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

namespace MedicalManager.Controls
{
    public partial class ControlRegistrator : UserControl
    {
        public ControlRegistrator()
        {
            InitializeComponent();
            listBoxPatients.DataSource = LogicProvider.Logic.SearchPatientsByString(textBoxQuery.Text);
        }

        private void linkLabelEmailSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEmailAuth formEmailAuth = new FormEmailAuth();
            formEmailAuth.ShowDialog();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string message;
            bool sent;
            if (listBoxHistories.SelectedItem != null)
            {
                sent = LogicProvider.Logic.SendMail
                (
                    textBoxMailTo.Text,
                    $"Отчёт о истории болезни {(listBoxHistories.SelectedItem as History).Name}",
                    LogicProvider.Logic.GetReportText((listBoxHistories.SelectedItem as History).Id),
                    new string[] { }
                );

                message = (sent ? "Отчёт успешно отправлен." : "Не удалось отправить отчёт. Обратитесь к администратору.");
            }
            else
            {
                message = "Не выбрана история болезни.";
            }
            
            MessageBox.Show(message, "Уведомление");
        }

        private void timerBeforeRequest_Tick(object sender, EventArgs e)
        {
            timerBeforeRequest.Enabled = false;
            listBoxPatients.DataSource = LogicProvider.Logic.SearchPatientsByString(textBoxQuery.Text);
        }

        private void textBoxQuery_TextChanged(object sender, EventArgs e)
        {
            timerBeforeRequest.Enabled = false;
            timerBeforeRequest.Enabled = true;
        }

        private void listBoxPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxHistories.DataSource = LogicProvider.Logic.GetHistoriesByUserId((listBoxPatients.SelectedItem as PatientString).Id);
            labelPatientInfo.Text = (listBoxPatients.SelectedItem as PatientString).FullInfo;
        }

        private void buttonShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                FormReport formReport = new FormReport((listBoxHistories.SelectedItem as History).Id);
                formReport.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не выбрана история болезни.", "Уведомление");
            }
            
        }
    }
}
