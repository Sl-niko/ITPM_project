using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using time_table.Location;

namespace time_table.TimeTable
{
    public partial class linkTimeTable : Form
    {
        public linkTimeTable()
        {
            InitializeComponent();
        }

        private void close1btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home7btn_Click(object sender, EventArgs e)
        {
            Form1 gotoForm1 = new Form1();
            gotoForm1.Show();
            this.Hide();
        }

        private void lectStst_btn_Click(object sender, EventArgs e)
        {
            lectureTimeTa lecture = new lectureTimeTa();
            lecture.Show();
            this.Hide();

        }

        private void student_stst_btn_Click(object sender, EventArgs e)
        {
            StudentTimeTable student = new StudentTimeTable();
            student.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SendMail send = new SendMail();
            send.Show();
            this.Hide();
        }
    }
}
