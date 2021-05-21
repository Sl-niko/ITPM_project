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
    public partial class lectureStat : Form
    {

        //  Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="E:\Time table management\link_all\time_table\time_table\EFDB.mdf";Integrated Security=True //
        //find the count sql statement
        SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\EFDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot");
        SqlCommand cmd, cmd2;
        SqlCommand cmd1, cmd3, cmd4 ,cmd5,cmd6;

        //sql query 
        String query = "SELECT COUNT(*) FROM lecture_tbl where lectu_type ='Professor'";
        String query1 = "SELECT COUNT(*) FROM lecture_tbl where lectu_type ='Assistant Professor'";
        String query2 = "SELECT COUNT(*) FROM lecture_tbl where lectu_type ='Senior Lecturer(HG)'";
        String query3 = "SELECT COUNT(*) FROM lecture_tbl where lectu_type ='Senior Lecturer'";
        String query4 = "SELECT COUNT(*) FROM lecture_tbl where lectu_type ='Lecturer'";
        String query5 = "SELECT COUNT(*) FROM lecture_tbl where lectu_type ='Assistant Lecturer'";
        String query6 = "SELECT COUNT(*) FROM lecture_tbl";

        private double Professor;
        private double Assistant_Professor;
        private double Senior_LectHG;
        private double Senior_Lect;
        private double Lecturer;
        private double Assistant_lect;

        private void lectureStat_Load(object sender, EventArgs e)
        {
            count_Lec();

            Barchart_load_lec();

            label2.Text = DateTime.Now.ToLongDateString();
        }

        private double TotalLect;
        public lectureStat()
        {
            InitializeComponent();
        }

        private void closebtn5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home3btn_Click(object sender, EventArgs e)
        {
            StatMain stat = new StatMain();
            stat.Show();
            this.Close();
        }


        public void count_Lec()
        {
            try
            {

                con.Open();
                cmd = new SqlCommand(query, con);
                cmd1 = new SqlCommand(query1, con);
                cmd2 = new SqlCommand(query2, con);
                cmd3 = new SqlCommand(query3, con);
                cmd4 = new SqlCommand(query4, con);
                cmd4 = new SqlCommand(query5, con);
                cmd4 = new SqlCommand(query6, con);
                Int32 Countprof = Convert.ToInt32(cmd.ExecuteScalar());
                Int32 CountAssiProf = Convert.ToInt32(cmd1.ExecuteScalar());
                Int32 CountSenior_lectHG = Convert.ToInt32(cmd2.ExecuteScalar());
                Int32 CountSenior_lect = Convert.ToInt32(cmd3.ExecuteScalar());
                Int32 CountLect = Convert.ToInt32(cmd3.ExecuteScalar());
                Int32 CountAssilect = Convert.ToInt32(cmd3.ExecuteScalar());
                Int32 countTotalLect = Convert.ToInt32(cmd4.ExecuteScalar());

                lbl_prof.Text = Countprof.ToString();
                lbl_assi_prof.Text = CountAssiProf.ToString();
                lbl_senior_lect_HG.Text = CountSenior_lectHG.ToString();
                lbl_senior_lect.Text = CountSenior_lect.ToString();
                lbl_lect.Text = CountLect.ToString();
                lbl_Assi_lect.Text = CountAssilect.ToString();
                lbl_total_lect.Text = countTotalLect.ToString();


                Professor = Countprof;
                Assistant_Professor = CountAssiProf;
                Senior_LectHG = CountSenior_lectHG;
                Senior_Lect = CountSenior_lect;
                Lecturer = CountLect;
                Assistant_lect = CountAssilect;
                TotalLect = countTotalLect;


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

        public void Barchart_load_lec()
        {


            chart_lec.Series["Number Of Lecturers"].Points.AddXY("Professor", Professor);
            chart_lec.Series["Number Of Lecturers"].Points.AddXY("Assistant Prof", Assistant_Professor);
            chart_lec.Series["Number Of Lecturers"].Points.AddXY("Senior Lect(HG)", Senior_LectHG);
            chart_lec.Series["Number Of Lecturers"].Points.AddXY("Senior Lect", Senior_Lect);
            chart_lec.Series["Number Of Lecturers"].Points.AddXY("Lecturer", Lecturer);
            chart_lec.Series["Number Of Lecturers"].Points.AddXY("Assistant Lect", Assistant_lect);



        }


    }
}
