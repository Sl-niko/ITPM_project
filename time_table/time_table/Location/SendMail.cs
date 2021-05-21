using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
namespace time_table.Location
{
    public partial class SendMail : Form
    {
        public SendMail()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.ShowDialog();
            lblLocation.Text = openFileDialog1.FileName;
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(textFrom.Text);
                mail.To.Add(txtto.Text);
                mail.Subject = txtTital.Text;
                mail.Body = txtBody.Text;

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(lblLocation.Text);
                mail.Attachments.Add(attachment);

                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(textFrom.Text, txtPassword.Text);

                smtp.EnableSsl = true;
                smtp.Send(mail);

                MessageBox.Show("Mail has been successfully send", "Email sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void SendMail_Load(object sender, EventArgs e)
        {
            lalee.Text = DateTime.Now.ToLongDateString();
        }

        private void closebtn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
