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

namespace time_table.Amasa1
{
    public partial class ManageWorkinDay : Form
    {

        working_Day1 modelWorking = new working_Day1();
        private string NotWorking111 = "NOT WORKING";
        public ManageWorkinDay()
        {
            InitializeComponent();
        }



        void show_data_GridView()
        {
            GridVWorking.AutoGenerateColumns = false;

            using (EFDBEntities1 db = new EFDBEntities1())
            {
                GridVWorking.DataSource = db.working_Day1.ToList<working_Day1>();


            }


        }

        private void ManageWorkinDay_Load(object sender, EventArgs e)
        {
            show_data_GridView();
        }

        private void GridVWorking_DoubleClick(object sender, EventArgs e)
        {
            if (GridVWorking.CurrentRow.Index != -1)
            {
                modelWorking.weekID = Convert.ToInt32(GridVWorking.CurrentRow.Cells["weekID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelWorking = db.working_Day1.Where(x => x.weekID == modelWorking.weekID).FirstOrDefault();

                    if (modelWorking.tusedayH.Equals(NotWorking111) && modelWorking.wednesdayH.Equals(NotWorking111) && modelWorking.thursdayH.Equals(NotWorking111) && modelWorking.fridayH.Equals(NotWorking111) && modelWorking.saturdayH.Equals(NotWorking111) && modelWorking.sundayH.Equals(NotWorking111))
                    {
                        Numeric_mon_H1.Value = int.Parse(modelWorking.MondayH);
                        Numeric_mon_M1.Value = int.Parse(modelWorking.MondayM);

                        Numeric_Teus_H1.Value = Numeric_Teus_H1.Minimum;
                        Numeric_Teus_M1.Value = Numeric_Teus_M1.Minimum;

                        Numeric_Wed_H1.Value = Numeric_Wed_H1.Minimum;
                        Numeric_Wed_M1.Value = Numeric_Wed_H1.Minimum;

                        Numeric_Thur_H1.Value = Numeric_Thur_H1.Minimum;
                        Numeric_Thur_M1.Value = Numeric_Thur_M1.Minimum;

                        Numeric_Friday_H1.Value = Numeric_Friday_H1.Minimum;
                        Numeric_Friday_M1.Value = Numeric_Friday_M1.Minimum;

                        Numeric_Satur_H1.Value = Numeric_Satur_H1.Minimum;
                        Numeric_Satur_M1.Value = Numeric_Satur_M1.Minimum;

                        Numeric_Sun_H1.Value = Numeric_Sun_H1.Minimum;
                        Numeric_Sun_M1.Value = Numeric_Sun_M1.Minimum;

                        Nume_Total1.Value = int.Parse(modelWorking.num_of_working_days);

                        CheckBoxMonday1.Checked = true;
                        CheckBoxTeusday1.Checked = false;
                        CheckBoxWedneday1.Checked = false;
                        CheckBoxThursday1.Checked = false;
                        CheckBoxFriday1.Checked = false;
                        CheckBoxSaturday1.Checked = false;
                        CheckBoxSunday1.Checked = false;

                    }
                    else if (modelWorking.wednesdayH.Equals(NotWorking111) && modelWorking.thursdayH.Equals(NotWorking111) && modelWorking.fridayH.Equals(NotWorking111) && modelWorking.saturdayH.Equals(NotWorking111) && modelWorking.sundayH.Equals(NotWorking111))
                    {

                        Numeric_mon_H1.Value = int.Parse(modelWorking.MondayH);
                        Numeric_mon_M1.Value = int.Parse(modelWorking.MondayM);

                        Numeric_Teus_H1.Value = int.Parse(modelWorking.tusedayH);
                        Numeric_Teus_M1.Value = int.Parse(modelWorking.tusedayM);

                        Numeric_Wed_H1.Value = Numeric_Wed_H1.Minimum;
                        Numeric_Wed_M1.Value = Numeric_Wed_H1.Minimum;

                        Numeric_Thur_H1.Value = Numeric_Thur_H1.Minimum;
                        Numeric_Thur_M1.Value = Numeric_Thur_M1.Minimum;

                        Numeric_Friday_H1.Value = Numeric_Friday_H1.Minimum;
                        Numeric_Friday_M1.Value = Numeric_Friday_M1.Minimum;

                        Numeric_Satur_H1.Value = Numeric_Satur_H1.Minimum;
                        Numeric_Satur_M1.Value = Numeric_Satur_M1.Minimum;

                        Numeric_Sun_H1.Value = Numeric_Sun_H1.Minimum;
                        Numeric_Sun_M1.Value = Numeric_Sun_M1.Minimum;

                        Nume_Total1.Value = int.Parse(modelWorking.num_of_working_days);

                        CheckBoxMonday1.Checked = true;
                        CheckBoxTeusday1.Checked = true;
                        CheckBoxWedneday1.Checked = false;
                        CheckBoxThursday1.Checked = false;
                        CheckBoxFriday1.Checked = false;
                        CheckBoxSaturday1.Checked = false;
                        CheckBoxSunday1.Checked = false;

                    }
                    else if (modelWorking.thursdayH.Equals(NotWorking111) && modelWorking.fridayH.Equals(NotWorking111) && modelWorking.saturdayH.Equals(NotWorking111) && modelWorking.sundayH.Equals(NotWorking111))
                    {
                        Numeric_mon_H1.Value = int.Parse(modelWorking.MondayH);
                        Numeric_mon_M1.Value = int.Parse(modelWorking.MondayM);

                        Numeric_Teus_H1.Value = int.Parse(modelWorking.tusedayH);
                        Numeric_Teus_M1.Value = int.Parse(modelWorking.tusedayM);

                        Numeric_Wed_H1.Value = int.Parse(modelWorking.wednesdayH);
                        Numeric_Wed_M1.Value = int.Parse(modelWorking.wednesdayM);

                        Numeric_Thur_H1.Value = Numeric_Thur_H1.Minimum;
                        Numeric_Thur_M1.Value = Numeric_Thur_M1.Minimum;

                        Numeric_Friday_H1.Value = Numeric_Friday_H1.Minimum;
                        Numeric_Friday_M1.Value = Numeric_Friday_M1.Minimum;

                        Numeric_Satur_H1.Value = Numeric_Satur_H1.Minimum;
                        Numeric_Satur_M1.Value = Numeric_Satur_M1.Minimum;

                        Numeric_Sun_H1.Value = Numeric_Sun_H1.Minimum;
                        Numeric_Sun_M1.Value = Numeric_Sun_M1.Minimum;

                        Nume_Total1.Value = int.Parse(modelWorking.num_of_working_days);

                        CheckBoxMonday1.Checked = true;
                        CheckBoxTeusday1.Checked = true;
                        CheckBoxWedneday1.Checked = true;
                        CheckBoxThursday1.Checked = false;
                        CheckBoxFriday1.Checked = false;
                        CheckBoxSaturday1.Checked = false;
                        CheckBoxSunday1.Checked = false;

                    }
                    else if (modelWorking.fridayH == NotWorking111 && modelWorking.saturdayH == NotWorking111 && modelWorking.sundayH == NotWorking111)
                    {
                        Numeric_mon_H1.Value = int.Parse(modelWorking.MondayH);
                        Numeric_mon_M1.Value = int.Parse(modelWorking.MondayM);

                        Numeric_Teus_H1.Value = int.Parse(modelWorking.tusedayH);
                        Numeric_Teus_M1.Value = int.Parse(modelWorking.tusedayM);

                        Numeric_Wed_H1.Value = int.Parse(modelWorking.wednesdayH);
                        Numeric_Wed_M1.Value = int.Parse(modelWorking.wednesdayM);

                        Numeric_Thur_H1.Value = int.Parse(modelWorking.thursdayH);
                        Numeric_Thur_M1.Value = int.Parse(modelWorking.thursdayM);

                        Numeric_Friday_H1.Value = Numeric_Friday_H1.Minimum;
                        Numeric_Friday_M1.Value = Numeric_Friday_M1.Minimum;

                        Numeric_Satur_H1.Value = Numeric_Satur_H1.Minimum;
                        Numeric_Satur_M1.Value = Numeric_Satur_M1.Minimum;

                        Numeric_Sun_H1.Value = Numeric_Sun_H1.Minimum;
                        Numeric_Sun_M1.Value = Numeric_Sun_M1.Minimum;

                        Nume_Total1.Value = int.Parse(modelWorking.num_of_working_days);

                        CheckBoxMonday1.Checked = true;
                        CheckBoxTeusday1.Checked = true;
                        CheckBoxWedneday1.Checked = true;
                        CheckBoxThursday1.Checked = true;
                        CheckBoxFriday1.Checked = false;
                        CheckBoxSaturday1.Checked = false;
                        CheckBoxSunday1.Checked = false;
                    }
                    else if (modelWorking.saturdayH.Equals(NotWorking111) && modelWorking.sundayH.Equals(NotWorking111))
                    {
                        Numeric_mon_H1.Value = int.Parse(modelWorking.MondayH);
                        Numeric_mon_M1.Value = int.Parse(modelWorking.MondayM);

                        Numeric_Teus_H1.Value = int.Parse(modelWorking.tusedayH);
                        Numeric_Teus_M1.Value = int.Parse(modelWorking.tusedayM);

                        Numeric_Wed_H1.Value = int.Parse(modelWorking.wednesdayH);
                        Numeric_Wed_M1.Value = int.Parse(modelWorking.wednesdayM);

                        Numeric_Thur_H1.Value = int.Parse(modelWorking.thursdayH);
                        Numeric_Thur_M1.Value = int.Parse(modelWorking.thursdayM);

                        Numeric_Friday_H1.Value = int.Parse(modelWorking.fridayH);
                        Numeric_Friday_M1.Value = int.Parse(modelWorking.fridayM);

                        Numeric_Satur_H1.Value = Numeric_Satur_H1.Minimum;
                        Numeric_Satur_M1.Value = Numeric_Satur_M1.Minimum;

                        Numeric_Sun_H1.Value = Numeric_Sun_H1.Minimum;
                        Numeric_Sun_M1.Value = Numeric_Sun_M1.Minimum;

                        Nume_Total1.Value = int.Parse(modelWorking.num_of_working_days);

                        CheckBoxMonday1.Checked = true;
                        CheckBoxTeusday1.Checked = true;
                        CheckBoxWedneday1.Checked = true;
                        CheckBoxThursday1.Checked = true;
                        CheckBoxFriday1.Checked = true;
                        CheckBoxSaturday1.Checked = false;
                        CheckBoxSunday1.Checked = false;

                    }
                    else if (modelWorking.sundayH == NotWorking111)
                    {
                        Numeric_mon_H1.Value = int.Parse(modelWorking.MondayH);
                        Numeric_mon_M1.Value = int.Parse(modelWorking.MondayM);

                        Numeric_Teus_H1.Value = int.Parse(modelWorking.tusedayH);
                        Numeric_Teus_M1.Value = int.Parse(modelWorking.tusedayM);

                        Numeric_Wed_H1.Value = int.Parse(modelWorking.wednesdayH);
                        Numeric_Wed_M1.Value = int.Parse(modelWorking.wednesdayM);

                        Numeric_Thur_H1.Value = int.Parse(modelWorking.thursdayH);
                        Numeric_Thur_M1.Value = int.Parse(modelWorking.thursdayM);

                        Numeric_Friday_H1.Value = int.Parse(modelWorking.fridayH);
                        Numeric_Friday_M1.Value = int.Parse(modelWorking.fridayM);

                        Numeric_Satur_H1.Value = int.Parse(modelWorking.saturdayH);
                        Numeric_Satur_M1.Value = int.Parse(modelWorking.saturdayH);

                        Numeric_Sun_H1.Value = Numeric_Sun_H1.Minimum;
                        Numeric_Sun_M1.Value = Numeric_Sun_M1.Minimum;

                        Nume_Total1.Value = int.Parse(modelWorking.num_of_working_days);

                        CheckBoxMonday1.Checked = true;
                        CheckBoxTeusday1.Checked = true;
                        CheckBoxWedneday1.Checked = true;
                        CheckBoxThursday1.Checked = true;
                        CheckBoxFriday1.Checked = true;
                        CheckBoxSaturday1.Checked = true;
                        CheckBoxSunday1.Checked = false;


                    }
                    else
                    {
                        MessageBox.Show("error");

                    }



                }

            }
        }

        public void clear()
        {

            Numeric_mon_H1.Value = Numeric_mon_H1.Minimum;
            Numeric_mon_M1.Value = Numeric_mon_M1.Minimum;

            Numeric_Teus_H1.Value = Numeric_Teus_H1.Minimum;
            Numeric_Teus_M1.Value = Numeric_Teus_M1.Minimum;

            Numeric_Wed_H1.Value = Numeric_Wed_H1.Minimum;
            Numeric_Wed_M1.Value = Numeric_Wed_H1.Minimum;

            Numeric_Thur_H1.Value = Numeric_Thur_H1.Minimum;
            Numeric_Thur_M1.Value = Numeric_Thur_M1.Minimum;

            Numeric_Friday_H1.Value = Numeric_Friday_H1.Minimum;
            Numeric_Friday_M1.Value = Numeric_Friday_M1.Minimum;

            Numeric_Satur_H1.Value = Numeric_Satur_H1.Minimum;
            Numeric_Satur_M1.Value = Numeric_Satur_M1.Minimum;

            Numeric_Sun_H1.Value = Numeric_Sun_H1.Minimum;
            Numeric_Sun_M1.Value = Numeric_Sun_M1.Minimum;

            Nume_Total1.Value = Nume_Total1.Minimum;


            CheckBoxMonday1.Checked = false;
            CheckBoxTeusday1.Checked = false;
            CheckBoxWedneday1.Checked = false;
            CheckBoxThursday1.Checked = false;
            CheckBoxFriday1.Checked = false;
            CheckBoxSaturday1.Checked = false;
            CheckBoxSunday1.Checked = false;
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (CheckBoxMonday1.Checked && CheckBoxTeusday1.Checked && CheckBoxWedneday1.Checked && CheckBoxThursday1.Checked && CheckBoxFriday1.Checked && CheckBoxSaturday1.Checked && CheckBoxSunday1.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H1.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M1.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H1.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M1.Value.ToString();

                modelWorking.wednesdayH = Numeric_Wed_H1.Value.ToString();
                modelWorking.wednesdayM = Numeric_Wed_M1.Value.ToString();

                modelWorking.thursdayH = Numeric_Thur_H1.Value.ToString();
                modelWorking.thursdayM = Numeric_Thur_M1.Value.ToString();

                modelWorking.fridayH = Numeric_Friday_H1.Value.ToString();
                modelWorking.fridayM = Numeric_Friday_M1.Value.ToString();

                modelWorking.saturdayH = Numeric_Satur_H1.Value.ToString();
                modelWorking.saturdayM = Numeric_Satur_M1.Value.ToString();

                modelWorking.sundayH = Numeric_Sun_H1.Value.ToString();
                modelWorking.sundayM = Numeric_Sun_M1.Value.ToString();

                modelWorking.num_of_working_days = Nume_Total1.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    if (modelWorking.weekID == 0)
                    {

                    }
                    else
                    {
                        db.Entry(modelWorking).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }


                clear();
                show_data_GridView();

                MessageBox.Show(" updated Successfully");

            }
            else if (CheckBoxMonday1.Checked && CheckBoxTeusday1.Checked && CheckBoxWedneday1.Checked && CheckBoxThursday1.Checked && CheckBoxFriday1.Checked && CheckBoxSaturday1.Checked)
            {

                modelWorking.MondayH = Numeric_mon_H1.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M1.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H1.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M1.Value.ToString();

                modelWorking.wednesdayH = Numeric_Wed_H1.Value.ToString();
                modelWorking.wednesdayM = Numeric_Wed_M1.Value.ToString();

                modelWorking.thursdayH = Numeric_Thur_H1.Value.ToString();
                modelWorking.thursdayM = Numeric_Thur_M1.Value.ToString();

                modelWorking.fridayH = Numeric_Friday_H1.Value.ToString();
                modelWorking.fridayM = Numeric_Friday_M1.Value.ToString();

                modelWorking.saturdayH = Numeric_Satur_H1.Value.ToString();
                modelWorking.saturdayM = Numeric_Satur_M1.Value.ToString();
                //
                modelWorking.sundayH = NotWorking111;
                modelWorking.sundayM = NotWorking111;

                modelWorking.num_of_working_days = Nume_Total1.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    if (modelWorking.weekID == 0)
                    {

                    }
                    else
                    {
                        db.Entry(modelWorking).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }


                clear();

                show_data_GridView();
                MessageBox.Show(" updated Successfully");

            }
            else if (CheckBoxMonday1.Checked && CheckBoxTeusday1.Checked && CheckBoxWedneday1.Checked && CheckBoxThursday1.Checked && CheckBoxFriday1.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H1.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M1.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H1.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M1.Value.ToString();

                modelWorking.wednesdayH = Numeric_Wed_H1.Value.ToString();
                modelWorking.wednesdayM = Numeric_Wed_M1.Value.ToString();

                modelWorking.thursdayH = Numeric_Thur_H1.Value.ToString();
                modelWorking.thursdayM = Numeric_Thur_M1.Value.ToString();

                modelWorking.fridayH = Numeric_Friday_H1.Value.ToString();
                modelWorking.fridayM = Numeric_Friday_M1.Value.ToString();

                modelWorking.saturdayH = NotWorking111;
                modelWorking.saturdayM = NotWorking111;
                //
                modelWorking.sundayH = NotWorking111;
                modelWorking.sundayM = NotWorking111;

                modelWorking.num_of_working_days = Nume_Total1.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    if (modelWorking.weekID == 0)
                    {

                    }
                    else
                    {
                        db.Entry(modelWorking).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }


                clear();
                show_data_GridView();
                MessageBox.Show(" updated Successfully");
            }
            else if (CheckBoxMonday1.Checked && CheckBoxTeusday1.Checked && CheckBoxWedneday1.Checked && CheckBoxThursday1.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H1.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M1.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H1.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M1.Value.ToString();

                modelWorking.wednesdayH = Numeric_Wed_H1.Value.ToString();
                modelWorking.wednesdayM = Numeric_Wed_M1.Value.ToString();

                modelWorking.thursdayH = Numeric_Thur_H1.Value.ToString();
                modelWorking.thursdayM = Numeric_Thur_M1.Value.ToString();

                modelWorking.fridayH = NotWorking111;
                modelWorking.fridayM = NotWorking111;

                modelWorking.saturdayH = NotWorking111;
                modelWorking.saturdayM = NotWorking111;
                //
                modelWorking.sundayH = NotWorking111;
                modelWorking.sundayM = NotWorking111;

                modelWorking.num_of_working_days = Nume_Total1.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    if (modelWorking.weekID == 0)
                    {

                    }
                    else
                    {
                        db.Entry(modelWorking).State = EntityState.Modified;
                        db.SaveChanges();
                    };
                }


                clear();
                show_data_GridView();
                MessageBox.Show(" updated Successfully");

            }
            else if (CheckBoxMonday1.Checked && CheckBoxTeusday1.Checked && CheckBoxWedneday1.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H1.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M1.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H1.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M1.Value.ToString();

                modelWorking.wednesdayH = Numeric_Wed_H1.Value.ToString();
                modelWorking.wednesdayM = Numeric_Wed_M1.Value.ToString();

                modelWorking.thursdayH = NotWorking111;
                modelWorking.thursdayM = NotWorking111;

                modelWorking.fridayH = NotWorking111;
                modelWorking.fridayM = NotWorking111;

                modelWorking.saturdayH = NotWorking111;
                modelWorking.saturdayM = NotWorking111;
                //
                modelWorking.sundayH = NotWorking111;
                modelWorking.sundayM = NotWorking111;

                modelWorking.num_of_working_days = Nume_Total1.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    if (modelWorking.weekID == 0)
                    {

                    }
                    else
                    {
                        db.Entry(modelWorking).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }


                clear();

                show_data_GridView();
                MessageBox.Show(" updated Successfully");

            }
            else if (CheckBoxMonday1.Checked && CheckBoxTeusday1.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H1.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M1.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H1.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M1.Value.ToString();

                modelWorking.wednesdayH = NotWorking111;
                modelWorking.wednesdayM = NotWorking111;

                modelWorking.thursdayH = NotWorking111;
                modelWorking.thursdayM = NotWorking111;

                modelWorking.fridayH = NotWorking111;
                modelWorking.fridayM = NotWorking111;

                modelWorking.saturdayH = NotWorking111;
                modelWorking.saturdayM = NotWorking111;
                //
                modelWorking.sundayH = NotWorking111;
                modelWorking.sundayM = NotWorking111;

                modelWorking.num_of_working_days = Nume_Total1.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    if (modelWorking.weekID == 0)
                    {

                    }
                    else
                    {
                        db.Entry(modelWorking).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }


                clear();

                show_data_GridView();
                MessageBox.Show(" updated Successfully");

            }
            else if (CheckBoxMonday1.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H1.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M1.Value.ToString();

                modelWorking.tusedayH = NotWorking111;
                modelWorking.tusedayM = NotWorking111;

                modelWorking.wednesdayH = NotWorking111;
                modelWorking.wednesdayM = NotWorking111;

                modelWorking.thursdayH = NotWorking111;
                modelWorking.thursdayM = NotWorking111;

                modelWorking.fridayH = NotWorking111;
                modelWorking.fridayM = NotWorking111;

                modelWorking.saturdayH = NotWorking111;
                modelWorking.saturdayM = NotWorking111;
                //
                modelWorking.sundayH = NotWorking111;
                modelWorking.sundayM = NotWorking111;

                modelWorking.num_of_working_days = Nume_Total1.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    if (modelWorking.weekID == 0)
                    {

                    }
                    else
                    {
                        db.Entry(modelWorking).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                clear();
                show_data_GridView();
                MessageBox.Show(" updated Successfully");

            }
            else
            {
                MessageBox.Show(" Error");
            }

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modelWorking);
                    if (entry.State == EntityState.Detached)
                    {
                        db.working_Day1.Attach(modelWorking);
                        db.working_Day1.Remove(modelWorking);
                        db.SaveChanges();
                        show_data_GridView();

                        clear();

                        MessageBox.Show(" Deleted Successfully");
                    }
                }
            }
        }

        private void close1btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home1btn_Click(object sender, EventArgs e)
        {
            WorkingDay day = new WorkingDay();
            day.Show();
            this.Hide();
        }
    }
}
