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
    public partial class ControlAdministrator : UserControl
    {
        int selectedIndex = 0;

        public ControlAdministrator()
        {
            InitializeComponent();
            listBoxRequests.DataSource = LogicProvider.Logic.GetRegistrationRequests(Properties.Settings.Default.login, LogicProvider.Logic.GetMD5Hash(Properties.Settings.Default.password));
        }

        private void timerUpdateInfo_Tick(object sender, EventArgs e)
        {
            try
            {
                selectedIndex = (listBoxRequests.SelectedIndex >= 0 ? listBoxRequests.SelectedIndex : 0);
                listBoxRequests.DataSource = LogicProvider.Logic.GetRegistrationRequests(Properties.Settings.Default.login, LogicProvider.Logic.GetMD5Hash(Properties.Settings.Default.password));
                if (selectedIndex < listBoxRequests.Items.Count)
                {
                    listBoxRequests.SetSelected(selectedIndex, true);
                }
            }
            catch
            {

            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string message = "Нет доступных заявок.";
            if(listBoxRequests.Items.Count > 0)
            {
                bool employeeAccepted = LogicProvider.Logic.AcceptRegistrationRequest((listBoxRequests.SelectedItem as EmployeeInfo).Id, Properties.Settings.Default.login, LogicProvider.Logic.GetMD5Hash(Properties.Settings.Default.password));
                message = (employeeAccepted ? "Новый сотрудник успешно зарегистрирован." : "Не удалось завершить регистрацию. Заявка не найдена.");
                
                listBoxRequests.DataSource = LogicProvider.Logic.GetRegistrationRequests(Properties.Settings.Default.login, LogicProvider.Logic.GetMD5Hash(Properties.Settings.Default.password));
            }

            MessageBox.Show(message, "Уведомление");
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            string message = "Нет доступных заявок.";
            if (listBoxRequests.Items.Count > 0)
            {
                bool employeeRejected = LogicProvider.Logic.RejectRegistrationRequest((listBoxRequests.SelectedItem as EmployeeInfo).Id, Properties.Settings.Default.login, LogicProvider.Logic.GetMD5Hash(Properties.Settings.Default.password));
                message = (employeeRejected ? "Заявка успешно отклонена." : "Не удалось найти данную заявку.");
                MessageBox.Show(message, "Уведомление");
                listBoxRequests.DataSource = LogicProvider.Logic.GetRegistrationRequests(Properties.Settings.Default.login, LogicProvider.Logic.GetMD5Hash(Properties.Settings.Default.password));
            }

            MessageBox.Show(message, "Уведомление");
        }
    }
}
