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
    public partial class SubjectStat : Form
    {
        //find the count sql statement
        SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\EFDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot");
        SqlCommand cmd, cmd2;
        SqlCommand cmd1, cmd3,cmd4;

        //sql query 
        String query = "SELECT COUNT(*) FROM Subject1 where year =1";
        String query1 = "SELECT COUNT(*) FROM Subject1 where year =2";
        String query2 = "SELECT COUNT(*) FROM Subject1 where year =3";
        String query3 = "SELECT COUNT(*) FROM Subject1 where year =4";
         String query4 = "SELECT Subject_Name FROM Subject1 WHERE SID=(SELECT max(SID) FROM Subject1)";


        private double firstYear;
        private double secondYear;
        private double thirdYear;
        private double fourthYear;



        public SubjectStat()
        {
            InitializeComponent();
        }

        private void close1btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home7btn_Click(object sender, EventArgs e)
        {
            StatMain stat = new StatMain();
            stat.Show();
            this.Close();
        }

        private void SubjectStat_Load(object sender, EventArgs e)
        {
            count_subject();
            chartSub_load();
            label3.Text = DateTime.Now.ToLongDateString();
            
        }

        public void count_subject()
        {
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
                String getNew = Convert.ToString(cmd4.ExecuteScalar());


                lblsub1.Text = Count1year.ToString();
                lblsub2.Text = Count2year.ToString();
                lblsub3.Text = Count3year.ToString();
                lblsub4.Text = Count4year.ToString();
                lbl_new_sub.Text = getNew.ToString();


                firstYear = Count1year;
                secondYear = Count2year;
                thirdYear = Count3year;
                fourthYear = Count4year;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }


        public void chartSub_load()
        {
            chartSubj.Series["Number Of Subject"].Points.AddXY("1St Year Sub..", firstYear);
            chartSubj.Series["Number Of Subject"].Points.AddXY("2nd Year Sub..", secondYear);
            chartSubj.Series["Number Of Subject"].Points.AddXY("3rd Year Sub..", thirdYear);
            chartSubj.Series["Number Of Subject"].Points.AddXY("4rd Year Sub..", fourthYear);

        }

    }
}
