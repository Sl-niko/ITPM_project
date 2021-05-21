using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using time_table.Location;

namespace time_table
{
    public partial class StudentStat : Form
    {
        //find the count sql statement
        SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\EFDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot");


        SqlCommand cmd, cmd2;
        SqlCommand cmd1,cmd3,cmd4;

        //sql query 
        String query = "SELECT COUNT(*) FROM Academic1 where AcademicYrSemester =1";
        String query1 = "SELECT COUNT(*) FROM Academic1 where AcademicYrSemester =2";
        String query2 = "SELECT COUNT(*) FROM Academic1 where AcademicYrSemester =3";
        String query3 = "SELECT COUNT(*) FROM Academic1 where AcademicYrSemester =4";
        String query4 = "SELECT COUNT(*) FROM Academic1";

        private double firstYear;
        private double secondYear;
        private double thirdYear;
        private double fourthYear;



        public StudentStat()
        {
            InitializeComponent();
        }

        private void closebtn9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home6btn_Click(object sender, EventArgs e)
        {
            StatMain main = new StatMain();
            main.Show();
            this.Close();
        }

        private void StudentStat_Load(object sender, EventArgs e)
        {
            using (EFDBEntities1 db = new EFDBEntities1())
            { 
            
            }

            count_student();
            chart_load();
            Barchart_load();
            label2.Text = DateTime.Now.ToLongDateString();
            
        }

        public void count_student() {
            try
            {

                con.Open();
                cmd = new SqlCommand(query, con);
                cmd1 = new SqlCommand(query1, con);
                cmd2 = new SqlCommand(query2, con);
                cmd3 = new SqlCommand(query3, con);
                cmd4 = new SqlCommand(query4, con);
                Int32 Count1year = Convert.ToInt32(cmd.ExecuteScalar());
                Int32 Count2year = Convert.ToInt32(cmd1.ExecuteScalar());
                Int32 Count3year = Convert.ToInt32(cmd2.ExecuteScalar());
                Int32 Count4year = Convert.ToInt32(cmd3.ExecuteScalar());
                Int32 countTotal = Convert.ToInt32(cmd4.ExecuteScalar());

                lbl1stY.Text = Count1year.ToString();
                lbl2stY.Text = Count2year.ToString();
                lbl3stY.Text = Count3year.ToString();
                lbl4stY.Text = Count4year.ToString();
                lblTotal.Text = countTotal.ToString();

                firstYear = Count1year;
                secondYear = Count2year;
                thirdYear = Count3year;
                fourthYear = Count4year;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public void chart_load() 
        {
            chartStudents.Series["Number Of Student"].Points.AddXY("1St Year", firstYear);
            chartStudents.Series["Number Of Student"].Points.AddXY("2nd Year", secondYear);
            chartStudents.Series["Number Of Student"].Points.AddXY("3rd Year", thirdYear);
            chartStudents.Series["Number Of Student"].Points.AddXY("4rd Year", fourthYear);

        }

        public void Barchart_load()
        {


            chartstd.Series["Number Of Student"].Points.AddXY("1St Year", firstYear);
           chartstd.Series["Number Of Student"].Points.AddXY("2nd Year", secondYear);
            chartstd.Series["Number Of Student"].Points.AddXY("3rd Year", thirdYear);
            chartstd.Series["Number Of Student"].Points.AddXY("4rd Year", fourthYear);




        }


    }
}
