using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalManager.Entities;

namespace MedicalManager.IDAC
{
    public interface IEmailAccessorContracts
    {
        bool SendMail(string mailto, string caption, string message, string[] attachFiles);
        EmailSettings GetEmailSettings();
        bool SetEmailSettings(EmailSettings emailSettings);
    }
}
