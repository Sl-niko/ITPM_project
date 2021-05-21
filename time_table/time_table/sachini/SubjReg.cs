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
    public partial class SubjReg : Form
    {


        private String semesterReadio;
        Subject1 modelsub = new Subject1();
        public SubjReg()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            semesterReadio = "Semester 1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            semesterReadio = "Semester 2";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            modelsub.Year = comboBoxyear.Text.Trim();
            modelsub.Semester = semesterReadio;
            modelsub.Subject_Name = textSubName.Text.Trim();
            modelsub.Subject_Code = textcode.Text.Trim();
            modelsub.Lecture_Hours = numericUpDown1.Value.ToString();
            modelsub.Tute_Hours = numericUpDown2.Value.ToString();
            modelsub.Lab_Hours = numericUpDown3.Value.ToString();
            modelsub.Evaluation_Hours = numericUpDown4.Value.ToString();


            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.Subject1.Add(modelsub);
                db.SaveChanges();

            }
            clear();
            MessageBox.Show(" Added Successfully");

            LoadData();

        }

        public void clear()
        {

            comboBoxyear.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textSubName.Text = "";
            textcode.Text = "";
            numericUpDown1.Value = numericUpDown1.Minimum;
            numericUpDown2.Value = numericUpDown2.Minimum;
            numericUpDown3.Value = numericUpDown3.Minimum;
            numericUpDown4.Value = numericUpDown4.Minimum;
            btnDeleteR.Enabled = false;



        }

        private void btnUpdateR_Click(object sender, EventArgs e)
        {
            modelsub.Year = comboBoxyear.Text.Trim();
            modelsub.Semester = semesterReadio;
            modelsub.Subject_Name = textSubName.Text.Trim();
            modelsub.Subject_Code = textcode.Text.Trim();
            modelsub.Lecture_Hours = numericUpDown1.Value.ToString();
            modelsub.Tute_Hours = numericUpDown2.Value.ToString();
            modelsub.Lab_Hours = numericUpDown3.Value.ToString();
            modelsub.Evaluation_Hours = numericUpDown4.Value.ToString();


            using (EFDBEntities1 db = new EFDBEntities1())
            {
                if (modelsub.SID == 0)
                {

                }
                else
                {
                    db.Entry(modelsub).State = EntityState.Modified;
                    db.SaveChanges();

                }

                clear();
                LoadData();

                MessageBox.Show("Lecture Updated Successfully");

            }

        }



        public void LoadData()
        {
            dataGridView1.AutoGenerateColumns = false;

            using (EFDBEntities1 db = new EFDBEntities1())
            {

                dataGridView1.DataSource = db.Subject1.ToList<Subject1>();
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                modelsub.SID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelsub = db.Subject1.Where(x => x.SID == modelsub.SID).FirstOrDefault();
                    comboBoxyear.Text = modelsub.Year;

                    textSubName.Text = modelsub.Subject_Name;
                    textcode.Text = modelsub.Subject_Code;
                    numericUpDown1.Value = int.Parse(modelsub.Lecture_Hours);
                    numericUpDown2.Value = int.Parse(modelsub.Tute_Hours);
                    numericUpDown3.Value = int.Parse(modelsub.Lab_Hours);
                    numericUpDown4.Value = int.Parse(modelsub.Evaluation_Hours);

                    if (modelsub.Semester == "Semester 1")
                    {

                        radioButton1.Checked = true;
                    }
                    else if (modelsub.Semester == "Semester 2")
                    {
                        radioButton2.Checked = true;
                    }
                    else
                    {

                        radioButton2.Checked = false;
                        radioButton1.Checked = false;
                    }
                }

                btnDeleteR.Enabled = true;

            }
        }

        private void btnDeleteR_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modelsub);
                    if (entry.State == EntityState.Detached)
                    {
                        db.Subject1.Attach(modelsub);
                        db.Subject1.Remove(modelsub);
                        db.SaveChanges();
                        LoadData();

                        clear();

                        MessageBox.Show("Lecture Deleted Successfully");
                    }
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearR_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 formx = new Form1();
            formx.Show();
            this.Hide();
        }
    }
}
