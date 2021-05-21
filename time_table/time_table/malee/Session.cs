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

namespace time_table.malee
{
    public partial class Session : Form
    {

        AddTag model = new AddTag();
        SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\EFDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot");
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;

        consecuTable modelconsec = new consecuTable();

        parellelTable modelpara = new parellelTable();

        NonOverlapTable modelNonover = new NonOverlapTable();


        String SessioId,Lect1,Lect2,Subj,SubtCode,tag,GroId;
        public Session()
        {
            InitializeComponent();
        }



        private void loadSubject()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    consCombo.DataSource = db.SessionNs.ToList();
                    consCombo.ValueMember = "SessionId";
                    consCombo.DisplayMember = "Subject";


                    pareCombo.DataSource = db.SessionNs.ToList();
                    pareCombo.ValueMember = "SessionId";
                    pareCombo.DisplayMember = "Subject";



                    NonOcombo.DataSource = db.SessionNs.ToList();
                    NonOcombo.ValueMember = "SessionId";
                    NonOcombo.DisplayMember = "Subject";



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Session_Load(object sender, EventArgs e)
        {


            loadSubject();
            clear();
           
        }
        private void clear() {

            consCombo.SelectedIndex = -1;

            pareCombo.SelectedIndex = -1;

            NonOcombo.SelectedIndex = -1;
        }

        private void gridCons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnParSession_Click(object sender, EventArgs e)
        {
            int total = gridParellel.Rows.Cast<DataGridViewRow>().Where(p => Convert.ToBoolean(p.Cells["selected11"].Value) == true).Count();
            if (total > 0)
            {
                string message = $"Are you sure want the add {total} row?";

                if (total > 1)
                    message = $"Are you sure want the add {total} row?";
                if (MessageBox.Show(message, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = gridParellel.RowCount - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = gridParellel.Rows[i];
                        if (Convert.ToBoolean(row.Cells["selected11"].Value) == true)
                        {
                            SessioId = row.Cells[0].Value.ToString();
                            Lect1 = row.Cells[1].Value.ToString();
                            Lect2 = row.Cells[2].Value.ToString();
                            Subj = row.Cells[3].Value.ToString();
                            SubtCode = row.Cells[4].Value.ToString();
                            tag = row.Cells[5].Value.ToString();
                            GroId = row.Cells[6].Value.ToString();

                            modelpara.SessionId = SessioId;
                            modelpara.Lecture1 = Lect1;
                            modelpara.Lecture2 = Lect2;
                            modelpara.Subject = Subj;
                            modelpara.SubjectCode = SubtCode;
                            modelpara.Tag = tag;
                            modelpara.GroupId = GroId;


                            using (EFDBEntities1 db = new EFDBEntities1())
                            {
                                db.parellelTables.Add(modelpara);
                                db.SaveChanges();
                            }
                            clear();

                            MessageBox.Show("Sessionid Added Successfully");
                        }

                    }

                }

            }
        }

        private void btnNonSession_Click(object sender, EventArgs e)
        {

            int total = gridNonOverlap.Rows.Cast<DataGridViewRow>().Where(p => Convert.ToBoolean(p.Cells["selected22"].Value) == true).Count();
            if (total > 0)
            {
                string message = $"Are you sure want the add {total} row?";

                if (total > 1)
                    message = $"Are you sure want the add {total} row?";
                if (MessageBox.Show(message, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = gridNonOverlap.RowCount - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = gridNonOverlap.Rows[i];
                        if (Convert.ToBoolean(row.Cells["selected22"].Value) == true)
                        {
                            SessioId = row.Cells[0].Value.ToString();
                            Lect1 = row.Cells[1].Value.ToString();
                            Lect2 = row.Cells[2].Value.ToString();
                            Subj = row.Cells[3].Value.ToString();
                            SubtCode = row.Cells[4].Value.ToString();
                            tag = row.Cells[5].Value.ToString();
                            GroId = row.Cells[6].Value.ToString();

                            modelNonover.SessionId = SessioId;
                            modelNonover.Lecture1 = Lect1;
                            modelNonover.Lecture2 = Lect2;
                            modelNonover.Subject = Subj;
                            modelNonover.SubjectCode = SubtCode;
                            modelNonover.Tag = tag;
                            modelNonover.GroupId = GroId;


                            using (EFDBEntities1 db = new EFDBEntities1())
                            {
                                db.NonOverlapTables.Add(modelNonover);
                                db.SaveChanges();
                            }
                            clear();

                            MessageBox.Show("Sessionid Added Successfully");
                        }

                    }

                }

            }



        
    }

        private void btnParView_Click(object sender, EventArgs e)
        {
            string valueToSerch2 = pareCombo.Text.ToString();
            serch2(valueToSerch2);
        }

        private void btnNOView_Click(object sender, EventArgs e)
        {
            string valueToSerch3 = pareCombo.Text.ToString();
            serch3(valueToSerch3);
        }

        public void serch(String valueToSerch)
        {


            try
            {

                con.Open();
                String query = "SELECT * FROM SessionN WHERE Subject Like '%" + valueToSerch + "%'";

                command = new SqlCommand(query, con);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                gridCons.DataSource = table;
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



        public void serch2(String valueToSerch)
        {


            try
            {

                con.Open();
                String query = "SELECT * FROM SessionN WHERE Subject Like '%" + valueToSerch + "%'";

                command = new SqlCommand(query, con);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
               

                gridParellel.DataSource = table;

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


        public void serch3(String valueToSerch)
        {


            try
            {

                con.Open();
                String query = "SELECT * FROM SessionN WHERE Subject Like '%" + valueToSerch + "%'";

                command = new SqlCommand(query, con);
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);


                gridNonOverlap.DataSource = table;

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

        private void btnConView_Click(object sender, EventArgs e)
        {
            string valueToSerch1 = consCombo.Text.ToString();
            serch(valueToSerch1);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home2btn_Click(object sender, EventArgs e)
        {
            GotoAcademic academic = new GotoAcademic();
            academic.Show();
            this.Hide();
        }

        private void AddHeaderCheckBox() { 
            
        
        }

        private void btnAddSesCon_Click(object sender, EventArgs e)
        {
            int total = gridCons.Rows.Cast<DataGridViewRow>().Where(p => Convert.ToBoolean(p.Cells["selected"].Value) == true).Count();
            if (total > 0)
            {
                string message = $"Are you sure want the add {total} row?";

                if(total>1)
                     message = $"Are you sure want the add {total} row?";
                if (MessageBox.Show(message, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = gridCons.RowCount - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = gridCons.Rows[i];
                        if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                        {
                            SessioId = row.Cells[0].Value.ToString();
                            Lect1 = row.Cells[1].Value.ToString();
                            Lect2 = row.Cells[2].Value.ToString();
                            Subj = row.Cells[3].Value.ToString();
                            SubtCode = row.Cells[4].Value.ToString();
                            tag = row.Cells[5].Value.ToString();
                            GroId = row.Cells[6].Value.ToString();

                            modelconsec.SessionId = SessioId;
                            modelconsec.Lecture1 = Lect1;
                            modelconsec.Lecture2 = Lect2;
                            modelconsec.Subject = Subj;
                            modelconsec.SubjectCode = SubtCode;
                            modelconsec.Tag = tag;
                            modelconsec.GroupId = GroId;


                            using (EFDBEntities1 db = new EFDBEntities1())
                            {
                                db.consecuTables.Add(modelconsec);
                                db.SaveChanges();
                            }
                            clear();

                            MessageBox.Show("Sessionid Added Successfully");
                        }

                    }
                
                }

            }
        }
    }
}
