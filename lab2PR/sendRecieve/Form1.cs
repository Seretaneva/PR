using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using S22.Imap;

namespace sendRecieve
{

    public partial class Form1 : Form
    {
        static Form1 f;
        public Form1()
        {
            InitializeComponent();

            f = this;
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            var message = new MailMessage(txtEmail.Text, txtRecipient.Text);
            message.Subject = txtSubject.Text;
            message.Body = rtxtBody.Text;

            using (SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587))
            {
                mailer.Credentials = new NetworkCredential(txtEmail.Text, txtPassword.Text);
                mailer.EnableSsl = true;
                mailer.Send(message);
            }
            txtRecipient.Text = null;
            txtSubject.Text = null;
            rtxtBody.Text = null;
        }

        private void btnRecieve_Click(object sender, EventArgs e)
        {
            StartRecieving();

        }
        private void StartRecieving()
        {
            Task.Run(() =>
            {
                using (ImapClient client = new ImapClient("imap.gmail.com", 993, txtEmail.Text,
                       txtPassword.Text, AuthMethod.Login, true))
                {
                   
                    client.NewMessage += new EventHandler<IdleMessageEventArgs>(OnNewMessage);
                    while (true) ;
                }
            });
        }
        static void OnNewMessage(object sender, IdleMessageEventArgs e)
        {
            MessageBox.Show("New message recieved.");
            MailMessage m = e.Client.GetMessage(e.MessageUID, FetchOptions.Normal);
            f.Invoke((MethodInvoker)delegate
            {
                f.rtxtRecieve.AppendText("From:" + m.From + "\t" + " Subject: " + m.Subject + "\n" + " Body: " + m.Body);
            });
        }

       
    }

}



