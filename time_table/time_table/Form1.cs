using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using time_table.Amasa1;
using time_table.Location;
using time_table.malee;
using time_table.sachini;
using time_table.TimeTable;

namespace time_table
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void MainLocationLink_Click(object sender, EventArgs e)
        {
            LinkLocation location = new LinkLocation();
            location.Show();
            this.Hide();


        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void home_stat_btn_Click(object sender, EventArgs e)
        {
            StatMain statMain= new StatMain();
            statMain.Show();
            this.Close();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

            GotoAcademic gotoAcademic = new GotoAcademic();
            gotoAcademic.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            lectureReg lecture = new lectureReg();
            lecture.Show();
            this.Hide();

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            SubjReg subj = new SubjReg();
            subj.Show();
            this.Hide();

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            linlTimeSlot linlTimeSlot = new linlTimeSlot();
            linlTimeSlot.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongDateString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            linkTimeTable Timet = new linkTimeTable();
            Timet.Show();
            this.Hide();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Make_session make = new Make_session();

            make.Show();
            this.Hide();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            AddStudentsGroups stude = new AddStudentsGroups();
            stude.Show();
            this.Hide();
        }
    }
}
