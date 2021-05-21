using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_table.Location
{
    public partial class StatMain : Form
    {
        public StatMain()
        {
            InitializeComponent();
        }

        private void lectStst_btn_Click(object sender, EventArgs e)
        {
            lectureStat lecture = new lectureStat();
            lecture.Show();
            this.Close();

        }

        private void student_stst_btn_Click(object sender, EventArgs e)
        {
            StudentStat studentStat = new StudentStat();
            studentStat.Show();
            this.Close();

        }

        private void subject_stat_btn_Click(object sender, EventArgs e)
        {
            SubjectStat subject = new SubjectStat();
            subject.Show();
            this.Close();
        }

        private void closebtn8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home5btn_Click(object sender, EventArgs e)
        {
            Form1 add = new Form1();
            add.Show();
            this.Hide();
        }

        private void StatMain_Load(object sender, EventArgs e)
        {

            label1.Text = DateTime.Now.ToLongDateString();
        }
    }
}
