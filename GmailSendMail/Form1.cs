using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GmailSendMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
         uygulama şifresi oluşturma linki :
        https://accounts.google.com/signin/v2/challenge/pwd?continue=https%3A%2F%2Fmyaccount.google.com%2Fapppasswords&service=accountsettings&osid=1&rart=ANgoxccPTgHWiIJTuBxIIhEbpHWCdSVjrov4k0WWA7w70Q61StH7O6u7chz8QGBeEeXrbGf-bgg9uApvsUGwNjIPOB-I0DrGgQ&TL=AM3QAYbcMkECkxlLu0BrBb8ymLXUopYGiuxElNVxw4o9j5vDeUuE6gdBvwHXssz5&flowName=GlifWebSignIn&cid=1&flowEntry=ServiceLogin
         */
        private void button1_Click(object sender, EventArgs e)
        {
            var fromAddress = new MailAddress("kendimailim@gmail.com", "From Name");
            var toAddress = new MailAddress("gonderilecekmail@gmail.com", "To Name");
            const string fromPassword = "16hanelişifre";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
