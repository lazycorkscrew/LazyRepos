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
        int selectedIndexEmployee = 0;

        public ControlAdministrator()
        {
            InitializeComponent();
            listBoxRequests.DataSource = LogicProvider.Logic.GetRegistrationRequests(Properties.Settings.Default.login, LogicProvider.Logic.GetMD5Hash(Properties.Settings.Default.password));
            comboBoxNewRole.DataSource = LogicProvider.Logic.GetRoles();
            comboBoxNewDepartment.DataSource = LogicProvider.Logic.GetDepartments();
            listBoxEmployees.DataSource = LogicProvider.Logic.GetEmployees();
            comboBoxOldRole.DataSource = LogicProvider.Logic.GetRoles();
            comboBoxOldDepartment.DataSource = LogicProvider.Logic.GetDepartments();
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
                listBoxRequests.DataSource = LogicProvider.Logic.GetRegistrationRequests(Properties.Settings.Default.login, LogicProvider.Logic.GetMD5Hash(Properties.Settings.Default.password));
            }

            MessageBox.Show(message, "Уведомление");
        }

        private void buttonCreateEmployee_Click(object sender, EventArgs e)
        {
            bool someEmpty = (textBoxNewLogin.Text == string.Empty || textBoxNewPassword.Text == string.Empty ||
                textBoxNewFname.Text == string.Empty || textBoxNewLname.Text == string.Empty ||
                textBoxNewPatronymic.Text == string.Empty);

            bool newEmployeeCreated = LogicProvider.Logic.RegisterNewUser
                (textBoxNewLogin.Text, 
                textBoxNewPassword.Text, 
                textBoxNewFname.Text, 
                textBoxNewLname.Text, 
                textBoxNewPatronymic.Text, 
                (comboBoxNewRole.SelectedItem as Role).Id, 
                (comboBoxNewDepartment.SelectedItem as Department).Id);

            string message = (someEmpty ? "Заполнены не все необходимые поля." : newEmployeeCreated ? "Новый сотрудник успешно добавлен." : "Не удалось добавить нового сотрудника.");
            MessageBox.Show(message);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            bool edited = LogicProvider.Logic.EditEmployee(
                Properties.Settings.Default.login,
                Properties.Settings.Default.password,
                (listBoxEmployees.SelectedItem as EmployeeInfo).Id,
                textBoxOldFname.Text,
                textBoxOldLname.Text,
                textBoxOldPatronymic.Text,
                (comboBoxOldRole.SelectedItem as Role).Id,
                (comboBoxOldDepartment.SelectedItem as Department).Id);
            string message = (edited? "Сотрудник успешно изменён.":"Не удалось изменить сотрудника.");
            MessageBox.Show(message, "Уведомление");
        }

        private void listBoxEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Employee employee = LogicProvider.Logic.GetEmployeeById((listBoxEmployees.SelectedItem as EmployeeInfo).Id);
                textBoxOldFname.Text = employee.Fname;
                textBoxOldLname.Text = employee.Lname;
                textBoxOldPatronymic.Text = employee.Patronymic;

                comboBoxOldRole.SelectedValue = employee.RoleId;
                comboBoxOldDepartment.SelectedValue = employee.DepartmentId;

            }
            catch(Exception ex)
            {

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            bool deleted = LogicProvider.Logic.DeleteEmployee(
                Properties.Settings.Default.login,
                Properties.Settings.Default.password, (listBoxEmployees.SelectedItem as EmployeeInfo).Id);
            string message = (deleted? "Сотрудник успешно удалён.":"Не удалось удалить сотрудника.");
            MessageBox.Show(message, "Уведомление");
            listBoxEmployees.DataSource = LogicProvider.Logic.GetEmployees();
        }
    }
}
