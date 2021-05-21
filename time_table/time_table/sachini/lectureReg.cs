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

namespace time_table.sachini
{
    public partial class lectureReg : Form
    {

        Lecture modelLect = new Lecture();
        public lectureReg()
        {
            InitializeComponent();
        }
        public void clear()
        {
            tboxName.Text = "";
            tboxID.Text = "";
            tboxrank.Text = "";
            tboxATime.Text = "";
            cboxFaculty.ResetText();
            cboxDepart.ResetText();
            cboxBuilding.ResetText();
            cboxLevel.ResetText();
            cboxDate.ResetText();
            cboxCenter.ResetText();
            btnDeleteR.Enabled = false;

        }


        public void generaterank()
        {
            if (cboxLevel.SelectedItem.ToString() == "Professor")
            {
                tboxrank.Text = 1 + "." + tboxID.Text;
            }
            else if (cboxLevel.SelectedItem.ToString() == "Assistant Professor")
            {
                tboxrank.Text = 2 + "." + tboxID.Text;
            }
            else if (cboxLevel.SelectedItem.ToString() == "Senior Lecture(HG)")
            {
                tboxrank.Text = 3 + "." + tboxID.Text;
            }
            else if (cboxLevel.SelectedItem.ToString() == "Senior Lecture")
            {
                tboxrank.Text = 4 + "." + tboxID.Text;
            }
            else if (cboxLevel.SelectedItem.ToString() == "Lecture")
            {
                tboxrank.Text = 5 + "." + tboxID.Text;
            }
            else if (cboxLevel.SelectedItem.ToString() == "Assistant Lecture")
            {
                tboxrank.Text = 6 + "." + tboxID.Text;
            }
        }

        private void btnClearR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            modelLect.LectureName = tboxName.Text.Trim();
            modelLect.EmpID = tboxID.Text.Trim();
            modelLect.Faculty = cboxFaculty.Text.Trim();
            modelLect.Department = cboxDepart.Text.Trim();
            modelLect.Center = cboxCenter.Text.Trim();
            modelLect.Building = cboxBuilding.Text.Trim();
            modelLect.Level = cboxLevel.Text.Trim();
            modelLect.Rank = tboxrank.Text.Trim();
            modelLect.Day = cboxDate.Text.Trim();
            modelLect.Time = tboxATime.Text.Trim();


            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.Lectures.Add(modelLect);
                db.SaveChanges();
            }
            clear();

            MessageBox.Show("Lecture Added Successfully");

            loadData();
        }

        public void loadData()
        {

            DataGridLecture.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                DataGridLecture.DataSource = db.Lectures.ToList<Lecture>();
            }
        }

        private void lectureReg_Load(object sender, EventArgs e)
        {
            loadData();
            clear();
        }

        private void DataGridLecture_DoubleClick(object sender, EventArgs e)
        {

            if (DataGridLecture.CurrentRow.Index != -1)
            {
                modelLect.LecID = Convert.ToInt32(DataGridLecture.CurrentRow.Cells["LecID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelLect = db.Lectures.Where(x => x.LecID == modelLect.LecID).FirstOrDefault();
                   

                    tboxName.Text = modelLect.LectureName;
                    tboxID.Text = modelLect.EmpID;
                    cboxFaculty.Text = modelLect.Faculty;
                    cboxDepart.Text = modelLect.Department;
                    cboxCenter.Text = modelLect.Center;
                    cboxBuilding.Text = modelLect.Building;
                    cboxLevel.Text = modelLect.Level;
                    tboxrank.Text = modelLect.Rank;
                    cboxDate.Text = modelLect.Day;
                    tboxATime.Text = modelLect.Time;


                
                }

                btnDeleteR.Enabled = true;
            }

        }

        private void btnUpdateR_Click(object sender, EventArgs e)
        {
            modelLect.LectureName = tboxName.Text.Trim();
            modelLect.EmpID = tboxID.Text.Trim();
            modelLect.Faculty = cboxFaculty.Text.Trim();
            modelLect.Department = cboxDepart.Text.Trim();
            modelLect.Center = cboxCenter.Text.Trim();
            modelLect.Building = cboxBuilding.Text.Trim();
            modelLect.Level = cboxLevel.Text.Trim();
            modelLect.Rank = tboxrank.Text.Trim();
            modelLect.Day = cboxDate.Text.Trim();
            modelLect.Time = tboxATime.Text.Trim();

            using (EFDBEntities1 db = new EFDBEntities1())
            {
                if (modelLect.LecID == 0)
                {

                }
                else
                {
                    db.Entry(modelLect).State = EntityState.Modified;
                    db.SaveChanges();

                }

                clear();
                loadData();

                MessageBox.Show("Lecture Updated Successfully");

            }


        }

        private void btnDeleteR_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modelLect);
                    if (entry.State == EntityState.Detached)
                    {
                        db.Lectures.Attach(modelLect);
                        db.Lectures.Remove(modelLect);
                        db.SaveChanges();
                        loadData();

                        clear();

                        MessageBox.Show("Lecture Deleted Successfully");
                    }
                }
            }
        }

        private void btnrank_Click(object sender, EventArgs e)
        {
            generaterank();
        }

        private void closebtn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home1btn_Click(object sender, EventArgs e)
        {
            Form1 fff = new Form1();
            fff.Show();
            this.Hide();

        }
    }
}
