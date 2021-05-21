using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_table.sachini
{
    public partial class ManageSession : Form
    {
        SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\EFDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot");
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;
        SessionN modelsession = new SessionN();

        public string keyword;
        public ManageSession()
        {
            InitializeComponent();
        }

        private void gridwiew_DoubleClick(object sender, EventArgs e)
        {
            if (gridwiew.CurrentRow.Index != -1)
            {
                modelsession.SessionId = Convert.ToInt32(gridwiew.CurrentRow.Cells["SessionId"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelsession = db.SessionNs.Where(x => x.SessionId == modelsession.SessionId).FirstOrDefault();
                    txtLect1.Text = modelsession.Lecture1;
                    txtlect2.Text = modelsession.Lecture2;
                    txtTag.Text = modelsession.Tag;
                    txtGroup.Text = modelsession.GroupId;
                    txtSub.Text = modelsession.Subject;
                    txtNoStd.Text = modelsession.NoOfStudents;
                    txtDuratio.Text = modelsession.Duraction;

                }

                btndelete.Enabled = true;
            }
        }


        void show_data_GridView()
        {
            gridwiew.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                gridwiew.DataSource = db.SessionNs.ToList<SessionN>();
            }
        }

        private void ManageSession_Load(object sender, EventArgs e)
        {
            clear();
            SubjectLoad();

            show_data_GridView();



        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            modelsession.Lecture1 = txtLect1.Text.Trim();
            modelsession.Lecture2 = txtlect2.Text.Trim();
            modelsession.Tag = txtTag.Text.Trim();
            modelsession.Subject = txtSub.Text.Trim();
            modelsession.GroupId = txtGroup.Text.Trim();
            modelsession.NoOfStudents = txtNoStd.Text.Trim();
            modelsession.Duraction = txtDuratio.Text.Trim();
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                if (modelsession.SessionId == 0)
                {

                }
                else
                {
                    db.Entry(modelsession).State = EntityState.Modified;
                    db.SaveChanges();

                }

              
                show_data_GridView();

                MessageBox.Show(" Updated Successfully");

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modelsession);
                    if (entry.State == EntityState.Detached)
                    {
                        db.SessionNs.Attach(modelsession);
                        db.SessionNs.Remove(modelsession);
                        db.SaveChanges();
                        show_data_GridView();

                        MessageBox.Show(" Deleted Successfully");
                    }
                }
            }
        }

        private void clear()
        {

            guna2ComboBox1.SelectedIndex = -1;
        }


        private void search(String value_to_search)
        {

            try
            {

                con.Open();
                String query = "SELECT * FROM SessionN  WHERE Subject  Like '%" + value_to_search + "%'";

                command = new SqlCommand(query, con);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                gridwiew.DataSource = table;

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



        private void SubjectLoad()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    guna2ComboBox1.DataSource = db.SessionNs.ToList();
                    guna2ComboBox1.ValueMember = "SessionId";
                    guna2ComboBox1.DisplayMember = "Subject";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            keyword = guna2ComboBox1.Text;
            search(keyword);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 coooo = new Form1();
            coooo.Show();
            this.Hide();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
