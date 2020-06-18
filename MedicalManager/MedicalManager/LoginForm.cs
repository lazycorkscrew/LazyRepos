using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalManager.Entities;
using MedicalManager.PL;

namespace MedicalManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            /*textBoxLogin.Text = Properties.Settings.Default.login;
            textBoxPassword.Text = Properties.Settings.Default.password;*/
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = LogicProvider.Logic.GetEmployeeByLoginAndPassword(textBoxLogin.Text, LogicProvider.Logic.GetMD5Hash(textBoxPassword.Text));

                if (employee == null)
                {
                    MessageBox.Show("Не удалось найти соответствие логина/пароля при авторизации.", "Ошибка");
                    return;
                }
                else
                {
                    Properties.Settings.Default.login = textBoxLogin.Text;
                    Properties.Settings.Default.password = textBoxPassword.Text;
                    Properties.Settings.Default.Save();
                    Visible = false;
                    textBoxLogin.Text = string.Empty;
                    textBoxPassword.Text = string.Empty;

                    FormWorkflow formWorkflow = new FormWorkflow(employee);
                    DialogResult dialogResult = formWorkflow.ShowDialog();
                    switch (dialogResult)
                    {
                        case DialogResult.Cancel: Close(); break;
                        case DialogResult.Abort: Visible = true; break;
                        default: break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не удалось соединиться с базой данных.","Ошибка");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormRegistration().ShowDialog();
        }

        private void linkLabelSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog();
        }
    }
}
