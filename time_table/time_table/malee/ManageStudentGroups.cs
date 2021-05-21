using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_table.malee
{
    public partial class ManageStudentGroups : Form
    {

        Academic1 modelAca = new Academic1();
        public ManageStudentGroups()
        {
            InitializeComponent();
        }

        private void btnUpdateMS_Click(object sender, EventArgs e)
        {
            modelAca.AcademicYrSemester = txtAcYear.Text.Trim();
            modelAca.Program1 = txtProgram.Text.Trim();
            modelAca.GroupNumber = txtGroupNum.Value.ToString();
            modelAca.SubGroupNo11 = txtSubGroupNum.Value.ToString();
            modelAca.GroupId11 = txtGruopId.Text.Trim();
            modelAca.SubGroupId11 = txtSubGroupId.Text.Trim();
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                if (modelAca.Studid == 0)
                {

                }
                else
                {
                    db.Entry(modelAca).State = EntityState.Modified;
                    db.SaveChanges();
                }

                clear();
                Sho_data_gridView();

                MessageBox.Show(" Updated Successfully");
            }
        }

        void Sho_data_gridView()
        {
            DataGridManagestd.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                DataGridManagestd.DataSource = db.Academic1.ToList<Academic1>();
            }
        }

        public void clear()
        {
            txtAcYear.Text = "";
            txtProgram.Text = "";
            txtGruopId.Text = "";

            txtSubGroupId.Text = "";
            txtGroupNum.Value = txtGroupNum.Minimum;
            txtSubGroupNum.Value = txtSubGroupNum.Minimum;
            btnDltMS.Enabled = false;
        }

        private void home2btn_Click(object sender, EventArgs e)
        {
            AddStudentsGroups addg = new AddStudentsGroups();
            addg.Show();
            this.Hide();

        }

        private void ManageStudentGroups_Load(object sender, EventArgs e)
        {
            Sho_data_gridView();
            clear();
        }

        private void DataGridManagestd_DoubleClick(object sender, EventArgs e)
        {
            if (DataGridManagestd.CurrentRow.Index != -1)
            {
                modelAca.Studid = Convert.ToInt32(DataGridManagestd.CurrentRow.Cells["StudId"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelAca = db.Academic1.Where(x => x.Studid == modelAca.Studid).FirstOrDefault();
                    txtAcYear.Text = modelAca.AcademicYrSemester;
                    txtProgram.Text = modelAca.Program1;
                    String groupnum = modelAca.GroupNumber;
                    txtGroupNum.Value = Convert.ToInt32(groupnum);
                    String Subgroupnum = modelAca.SubGroupNo11;
                    txtSubGroupNum.Value = Convert.ToInt32(Subgroupnum);
                    txtGruopId.Text = modelAca.GroupId11;
                    txtSubGroupId.Text = modelAca.SubGroupId11;

                }
                btnDltMS.Enabled = true;
            }
        }

        private void btnDltMS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modelAca);

                    if (entry.State == EntityState.Detached)
                    {
                        db.Academic1.Attach(modelAca);
                        db.Academic1.Remove(modelAca);
                        db.SaveChanges();

                        Sho_data_gridView();

                        clear();

                        MessageBox.Show(" Deleted Successfully");

                    }

                }
            }
        }

        private void btnClearMS_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
