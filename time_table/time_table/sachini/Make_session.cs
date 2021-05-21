using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_table.sachini
{
    public partial class Make_session : Form
    {
        SessionN modelSession = new SessionN();

        public Make_session()
        {
            InitializeComponent();
        }

        private void loadLecture1()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    cboxLec1.DataSource = db.Lectures.ToList();
                    cboxLec1.ValueMember = "LecID";
                    cboxLec1.DisplayMember = "LectureName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void loadLecture2()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    cboxLec2.DataSource = db.Lectures.ToList();
                    cboxLec2.ValueMember = "LecID";
                    cboxLec2.DisplayMember = "LectureName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void loadTag()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    cboxTag.DataSource = db.AddTag11.ToList();
                    cboxTag.ValueMember = "TagID";
                    cboxTag.DisplayMember = "TagName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void loadGroup()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    cboxGroup.DataSource = db.Academic1.ToList();
                    cboxGroup.ValueMember = "Studid";
                    cboxGroup.DisplayMember = "GroupId11";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void loadSubject()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    cboxSubject.DataSource = db.Subject1.ToList();
                    cboxSubject.ValueMember = "SID";
                    cboxSubject.DisplayMember = "Subject_Name";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            modelSession.Lecture1 = cboxLec1.Text.Trim();
            modelSession.Lecture2 = cboxLec2.Text.Trim();
            modelSession.Tag = cboxTag.Text.Trim();
            modelSession.Subject = cboxSubject.Text.Trim();
            modelSession.GroupId = cboxGroup.Text.Trim();
            modelSession.NoOfStudents = tboxNoofstu.Text.Trim();
            modelSession.Duraction = tboxDuration.Text.Trim();


            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.SessionNs.Add(modelSession);
                db.SaveChanges();
            }

            //clear();

            MessageBox.Show("Session Saved Successfully");
        }

        private void Make_session_Load(object sender, EventArgs e)
        {
            loadLecture1();
            loadLecture2();
            loadTag();
            loadGroup();
            loadSubject();
            clear();
        }


        public void clear() {
            cboxLec1.SelectedIndex = -1;
            cboxLec2.SelectedIndex = -1;
            cboxTag.SelectedIndex = -1;
            cboxSubject.SelectedIndex = -1;
            cboxGroup.SelectedIndex = -1;
            tboxNoofstu.Text = "";
            tboxDuration.Text = "";
        }

        private void close1btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home7btn_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.Show();
            this.Hide();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            ManageSession manage = new ManageSession();
            manage.Show();
            this.Hide();
        }
    }
}
