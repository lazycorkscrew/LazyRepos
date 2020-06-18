using MedicalManager.Entities;
using MedicalManager.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalManager
{
    public partial class FormRegistration : Form
    {
        public FormRegistration()
        {
            InitializeComponent();
            comboBoxDepartment.DataSource = LogicProvider.Logic.GetDepartments();
            comboBoxRole.DataSource = LogicProvider.Logic.GetRoles();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Равно true если не заполнено хотя бы одно поле.
            bool someEmpty = (textBoxLogin.Text == string.Empty || textBoxPassword.Text == string.Empty ||
                textBoxFname.Text == string.Empty || textBoxLname.Text == string.Empty ||
                textBoxPatronymic.Text == string.Empty || textBoxPhone.Text == string.Empty);

            //Равно true, если удалось отправить заявку.
            bool created = LogicProvider.Logic.CreateRegistrationRequest
                (textBoxLogin.Text, textBoxPassword.Text, textBoxFname.Text, textBoxLname.Text,
                textBoxPatronymic.Text, (comboBoxRole.SelectedItem as Role).Id, (comboBoxDepartment.SelectedItem as Department).Id,
                textBoxPhone.Text);
            string message = (someEmpty? "Заполнены не все необходимые поля.": created? "Заявка на добавление нового сотрудника успешно передана администратору на проверку." : "Не удалось отправить заявку на добавление нового сотрудника.");
            MessageBox.Show(message);

            if(created)
            {
                Close();
            }
        }
    }
}
