using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_table.malee
{
    public partial class AddStudentsGroups : Form
    {

        Academic1 modelAcad = new Academic1();
        public AddStudentsGroups()
        {
            InitializeComponent();
        }

        private void home2btn_Click(object sender, EventArgs e)
        {
            GotoAcademic gotoAcademic = new GotoAcademic();
            gotoAcademic.Show();
            this.Hide();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void clear()
        {
            txtAcaYear.Text = "";
            txtprogramme.Text = "";
            txtGroupID.Text = "";

            txtSubGroupID.Text = "";
            txtGroupNum.Value = txtGroupNum.Minimum;
            txtSubGroupNum.Value = txtSubGroupNum.Minimum;
        }

        private void btnClear11_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSaveStd_Click(object sender, EventArgs e)
        {
            modelAcad.AcademicYrSemester = txtAcaYear.Text.Trim();
            modelAcad.Program1 = txtprogramme.Text.Trim();
            modelAcad.GroupNumber = txtGroupNum.Value.ToString();
            modelAcad.SubGroupNo11 = txtSubGroupNum.Value.ToString();
            modelAcad.GroupId11 = txtGroupID.Text.Trim();
            modelAcad.SubGroupId11 = txtSubGroupID.Text.Trim();

            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.Academic1.Add(modelAcad);
                db.SaveChanges();

            }
            clear();

            MessageBox.Show("Added Successfully");
        }

        private void StudentGroupMan_Click(object sender, EventArgs e)
        {
            ManageStudentGroups manage = new ManageStudentGroups();
            manage.Show();
            this.Hide();
        }

        public void genarate_groupID()
        {
            txtGroupID.Text = "Y"+txtAcaYear.Text + "." + txtprogramme.Text + "." + "0" + txtGroupNum.Value.ToString();
        }

        public void genarate_subGroup()
        {
            txtSubGroupID.Text ="Y"+ txtAcaYear.Text + "." + txtprogramme.Text + "." + "0" + txtGroupNum.Value + "." + txtSubGroupNum.Value;
        }

        private void btnGenarateID_Click(object sender, EventArgs e)
        {
            genarate_groupID();
            genarate_subGroup();
        }
    }
}
