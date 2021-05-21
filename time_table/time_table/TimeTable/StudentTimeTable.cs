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

namespace time_table.TimeTable
{
    public partial class StudentTimeTable : Form
    {

        String subjectlect;
        String lectName;
        String subcode1;
        String Tagg;
        String Numstu;
        String Groupidss;

        String getGroupId;
        SessionN modelsessionN = new SessionN();

        SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\EFDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot");
        SqlCommand cmd, cmd2, cmd3, cmd4, cmd5, cmd6;

        private void btngenarate_Click(object sender, EventArgs e)
        {
            getGroupId = comboGroup.Text;
            getsessionDetails(getGroupId);

            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[] {

                new Microsoft.Reporting.WinForms.ReportParameter("TuesStdLectname",lectName),
                new Microsoft.Reporting.WinForms.ReportParameter("TuesStudSub",subjectlect),
                new Microsoft.Reporting.WinForms.ReportParameter("tueSubCode",subcode1),
                new Microsoft.Reporting.WinForms.ReportParameter("tueTag",Tagg),
                new Microsoft.Reporting.WinForms.ReportParameter("TueGrupID",Groupidss),
                new Microsoft.Reporting.WinForms.ReportParameter("tueNumStd",Numstu)

            };
            this.reportViewer2.LocalReport.SetParameters(para);
            this.reportViewer2.RefreshReport();
        }

        private void home3btn_Click(object sender, EventArgs e)
        {
            linkTimeTable linkss = new linkTimeTable();
            linkss.Show();
            this.Hide();

        }

        private void closebtn4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public StudentTimeTable()
        {
            InitializeComponent();
        }

        private void loadGroup()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    comboGroup.DataSource = db.SessionNs.ToList();
                    comboGroup.ValueMember = "SessionId";
                    comboGroup.DisplayMember = "GroupId";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void StudentTimeTable_Load(object sender, EventArgs e)
        {
            loadGroup();
            clear();
        }


        private void clear()
        {
            comboGroup.SelectedIndex = -1;

        }

        public void getsessionDetails(String groupIDsss)
        {


            try
            {

                con.Open();
                String query = "SELECT Subject FROM SessionN WHERE Lecture1 Like '%" + groupIDsss + "%'";
                String query2 = "SELECT Lecture1 FROM SessionN WHERE Lecture1 Like '%" + groupIDsss + "%'";

                String query3 = "SELECT SubjectCode FROM SessionN WHERE Lecture1 Like '%" + groupIDsss + "%'";
                String query4 = "SELECT Tag FROM SessionN WHERE Lecture1 Like '%" + groupIDsss + "%'";
                String query5 = "SELECT NoOfStudents FROM SessionN WHERE Lecture1 Like '%" + groupIDsss + "%'";
                String query6 = "SELECT GroupId FROM SessionN WHERE Lecture1 Like '%" + groupIDsss + "%'";

                cmd = new SqlCommand(query, con);
                cmd2 = new SqlCommand(query2, con);
                cmd3 = new SqlCommand(query3, con);
                cmd4 = new SqlCommand(query4, con);
                cmd5 = new SqlCommand(query5, con);
                cmd6 = new SqlCommand(query6, con);

                String subject = Convert.ToString(cmd.ExecuteScalar());
                String lectname = Convert.ToString(cmd2.ExecuteScalar());
                String subcode = Convert.ToString(cmd3.ExecuteScalar());
                String tag = Convert.ToString(cmd4.ExecuteScalar());
                String noStude = Convert.ToString(cmd5.ExecuteScalar());
                String groupID = Convert.ToString(cmd6.ExecuteScalar());



                subjectlect = subject;
                lectName = lectname;
                Tagg = tag;
                subcode1 = subcode;
                Numstu = noStude;
                Groupidss = groupID;
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





    }
}
