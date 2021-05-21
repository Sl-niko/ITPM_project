using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_table.Amasa1
{
    public partial class WorkingDay : Form
    {

        int countTotal = 0;
        private string NotWorking = "NOT WORKING";

        public working_Day1 modelWorking = new working_Day1();
        public WorkingDay()
        {
            InitializeComponent();
        }



        public void Count_working_day()
        {
            if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked && CheckBoxWedneday.Checked && CheckBoxThursday.Checked && CheckBoxFriday.Checked && CheckBoxSaturday.Checked && CheckBoxSunday.Checked)
            {
                countTotal = 7;

                Nume_Total.Value = countTotal;
            }
            else if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked && CheckBoxWedneday.Checked && CheckBoxThursday.Checked && CheckBoxFriday.Checked && CheckBoxSaturday.Checked)
            {
                countTotal = 6;

                Nume_Total.Value = countTotal;
            }
            else if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked && CheckBoxWedneday.Checked && CheckBoxThursday.Checked && CheckBoxFriday.Checked)
            {

                countTotal = 5;

                Nume_Total.Value = countTotal;
            }
            else if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked && CheckBoxWedneday.Checked && CheckBoxThursday.Checked)
            {
                countTotal = 4;

                Nume_Total.Value = countTotal;
            }
            else if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked && CheckBoxWedneday.Checked)
            {
                countTotal = 3;

                Nume_Total.Value = countTotal;
            }
            else if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked)
            {
                countTotal = 2;

                Nume_Total.Value = countTotal;
            }
            else if (CheckBoxMonday.Checked)
            {
                countTotal = 1;

                Nume_Total.Value = countTotal;
            }
            else {
                MessageBox.Show("Opps");
            }


        }

        private void btn_count_Click(object sender, EventArgs e)
        {
            Count_working_day();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked && CheckBoxWedneday.Checked && CheckBoxThursday.Checked && CheckBoxFriday.Checked && CheckBoxSaturday.Checked && CheckBoxSunday.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M.Value.ToString();

                modelWorking.wednesdayH = Numeric_Wed_H.Value.ToString();
                modelWorking.wednesdayM = Numeric_Wed_M.Value.ToString();

                modelWorking.thursdayH = Numeric_Thur_H.Value.ToString();
                modelWorking.thursdayM = Numeric_Thur_M.Value.ToString();

                modelWorking.fridayH = Numeric_Friday_H.Value.ToString();
                modelWorking.fridayM = Numeric_Friday_M.Value.ToString();

                modelWorking.saturdayH = Numeric_Satur_H.Value.ToString();
                modelWorking.saturdayM = Numeric_Satur_M.Value.ToString();

                modelWorking.sundayH = Numeric_Sun_H.Value.ToString();
                modelWorking.sundayM = Numeric_Sun_M.Value.ToString();

                modelWorking.num_of_working_days = Nume_Total.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    db.working_Day1.Add(modelWorking);

                    db.SaveChanges();
                }


                clear();
                MessageBox.Show(" Added Successfully");

            }
            else if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked && CheckBoxWedneday.Checked && CheckBoxThursday.Checked && CheckBoxFriday.Checked && CheckBoxSaturday.Checked)
            {

                modelWorking.MondayH = Numeric_mon_H.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M.Value.ToString();

                modelWorking.wednesdayH = Numeric_Wed_H.Value.ToString();
                modelWorking.wednesdayM = Numeric_Wed_M.Value.ToString();

                modelWorking.thursdayH = Numeric_Thur_H.Value.ToString();
                modelWorking.thursdayM = Numeric_Thur_M.Value.ToString();

                modelWorking.fridayH = Numeric_Friday_H.Value.ToString();
                modelWorking.fridayM = Numeric_Friday_M.Value.ToString();

                modelWorking.saturdayH = Numeric_Satur_H.Value.ToString();
                modelWorking.saturdayM = Numeric_Satur_M.Value.ToString();
                //
                modelWorking.sundayH = NotWorking;
                modelWorking.sundayM = NotWorking;

                modelWorking.num_of_working_days = Nume_Total.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    db.working_Day1.Add(modelWorking);

                    db.SaveChanges();
                }


                clear();
                MessageBox.Show(" Added Successfully");

            }
            else if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked && CheckBoxWedneday.Checked && CheckBoxThursday.Checked && CheckBoxFriday.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M.Value.ToString();

                modelWorking.wednesdayH = Numeric_Wed_H.Value.ToString();
                modelWorking.wednesdayM = Numeric_Wed_M.Value.ToString();

                modelWorking.thursdayH = Numeric_Thur_H.Value.ToString();
                modelWorking.thursdayM = Numeric_Thur_M.Value.ToString();

                modelWorking.fridayH = Numeric_Friday_H.Value.ToString();
                modelWorking.fridayM = Numeric_Friday_M.Value.ToString();

                modelWorking.saturdayH = NotWorking;
                modelWorking.saturdayM = NotWorking;
                //
                modelWorking.sundayH = NotWorking;
                modelWorking.sundayM = NotWorking;

                modelWorking.num_of_working_days = Nume_Total.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    db.working_Day1.Add(modelWorking);

                    db.SaveChanges();
                }


                clear();
                MessageBox.Show(" Added Successfully");
            }
            else if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked && CheckBoxWedneday.Checked && CheckBoxThursday.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M.Value.ToString();

                modelWorking.wednesdayH = Numeric_Wed_H.Value.ToString();
                modelWorking.wednesdayM = Numeric_Wed_M.Value.ToString();

                modelWorking.thursdayH = Numeric_Thur_H.Value.ToString();
                modelWorking.thursdayM = Numeric_Thur_M.Value.ToString();

                modelWorking.fridayH = NotWorking;
                modelWorking.fridayM = NotWorking;

                modelWorking.saturdayH = NotWorking;
                modelWorking.saturdayM = NotWorking;
                //
                modelWorking.sundayH = NotWorking;
                modelWorking.sundayM = NotWorking;

                modelWorking.num_of_working_days = Nume_Total.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    db.working_Day1.Add(modelWorking);

                    db.SaveChanges();
                }


                clear();
                MessageBox.Show(" Added Successfully");

            }
            else if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked && CheckBoxWedneday.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M.Value.ToString();

                modelWorking.wednesdayH = Numeric_Wed_H.Value.ToString();
                modelWorking.wednesdayM = Numeric_Wed_M.Value.ToString();

                modelWorking.thursdayH = NotWorking;
                modelWorking.thursdayM = NotWorking;

                modelWorking.fridayH = NotWorking;
                modelWorking.fridayM = NotWorking;

                modelWorking.saturdayH = NotWorking;
                modelWorking.saturdayM = NotWorking;
                //
                modelWorking.sundayH = NotWorking;
                modelWorking.sundayM = NotWorking;

                modelWorking.num_of_working_days = Nume_Total.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    db.working_Day1.Add(modelWorking);

                    db.SaveChanges();
                }


                clear();
                MessageBox.Show(" Added Successfully");

            }
            else if (CheckBoxMonday.Checked && CheckBoxTeusday.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M.Value.ToString();

                modelWorking.tusedayH = Numeric_Teus_H.Value.ToString();
                modelWorking.tusedayM = Numeric_Teus_M.Value.ToString();

                modelWorking.wednesdayH = NotWorking;
                modelWorking.wednesdayM = NotWorking;

                modelWorking.thursdayH = NotWorking;
                modelWorking.thursdayM = NotWorking;

                modelWorking.fridayH = NotWorking;
                modelWorking.fridayM = NotWorking;

                modelWorking.saturdayH = NotWorking;
                modelWorking.saturdayM = NotWorking;
                //
                modelWorking.sundayH = NotWorking;
                modelWorking.sundayM = NotWorking;

                modelWorking.num_of_working_days = Nume_Total.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    db.working_Day1.Add(modelWorking);

                    db.SaveChanges();
                }


                clear();
                MessageBox.Show(" Added Successfully");

            }
            else if (CheckBoxMonday.Checked)
            {
                modelWorking.MondayH = Numeric_mon_H.Value.ToString();
                modelWorking.MondayM = Numeric_mon_M.Value.ToString();

                modelWorking.tusedayH = NotWorking;
                modelWorking.tusedayM = NotWorking;

                modelWorking.wednesdayH = NotWorking;
                modelWorking.wednesdayM = NotWorking;

                modelWorking.thursdayH = NotWorking;
                modelWorking.thursdayM = NotWorking;

                modelWorking.fridayH = NotWorking;
                modelWorking.fridayM = NotWorking;

                modelWorking.saturdayH = NotWorking;
                modelWorking.saturdayM = NotWorking;
                //
                modelWorking.sundayH = NotWorking;
                modelWorking.sundayM = NotWorking;

                modelWorking.num_of_working_days = Nume_Total.Value.ToString();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    db.working_Day1.Add(modelWorking);

                    db.SaveChanges();
                }


                clear();
                MessageBox.Show(" Added Successfully");

            }

        }



        public void clear()
        {

            Numeric_mon_H.Value = Numeric_mon_H.Minimum;
            Numeric_mon_M.Value = Numeric_mon_M.Minimum;

            Numeric_Teus_H.Value = Numeric_Teus_H.Minimum;
            Numeric_Teus_M.Value = Numeric_Teus_M.Minimum;

            Numeric_Wed_H.Value = Numeric_Wed_H.Minimum;
            Numeric_Wed_M.Value = Numeric_Wed_H.Minimum;

            Numeric_Thur_H.Value = Numeric_Thur_H.Minimum;
            Numeric_Thur_M.Value = Numeric_Thur_M.Minimum;

            Numeric_Friday_H.Value = Numeric_Friday_H.Minimum;
            Numeric_Friday_M.Value = Numeric_Friday_M.Minimum;

            Numeric_Satur_H.Value = Numeric_Satur_H.Minimum;
            Numeric_Satur_M.Value = Numeric_Satur_M.Minimum;

            Numeric_Sun_H.Value = Numeric_Sun_H.Minimum;
            Numeric_Sun_M.Value = Numeric_Sun_M.Minimum;

            Nume_Total.Value = Nume_Total.Minimum;


            CheckBoxMonday.Checked = false;
            CheckBoxTeusday.Checked = false;
            CheckBoxWedneday.Checked = false;
            CheckBoxThursday.Checked = false;
            CheckBoxFriday.Checked = false;
            CheckBoxSaturday.Checked = false;
            CheckBoxSunday.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btn_veiw_Click(object sender, EventArgs e)
        {
            ManageWorkinDay manage = new ManageWorkinDay();
            manage.Show();
            this.Hide();
        }

        private void close1btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home1btn_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
