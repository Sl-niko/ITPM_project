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
    public partial class NotAvailableTime : Form
    {

        NotAvTime notAvailableTimeAlc = new NotAvTime();
        public NotAvailableTime()
        {
            InitializeComponent();
        }

        private void NotAvailableTime_Load(object sender, EventArgs e)
        {
            clear();
            Selectlecture();
            SelectGroup();
            SelectSubGroup();
            SessionIDLoad();
            loadTime();
        }

        public void clear()
        {
            combo_select_Lec.SelectedIndex = -1;
            combo_select_group.SelectedIndex = -1;
            combo_select_subgroup.SelectedIndex = -1;
            Combo_seect_sessionID.SelectedIndex = -1;
            combo_time.SelectedIndex = -1;

        }


        private void Selectlecture()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combo_select_Lec.DataSource = db.Lectures.ToList();
                    combo_select_Lec.ValueMember = "LecID";
                    combo_select_Lec.DisplayMember = "LectureName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void SelectGroup()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combo_select_group.DataSource = db.SessionNs.ToList();
                    combo_select_group.ValueMember = "SessionId";
                    combo_select_group.DisplayMember = "GroupId";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void SelectSubGroup()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combo_select_subgroup.DataSource = db.Academic1.ToList();
                    combo_select_subgroup.ValueMember = "Studid";
                    combo_select_subgroup.DisplayMember = "SubGroupId11";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //loadsession_ID
        private void SessionIDLoad()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combo_select_subgroup.DataSource = db.SessionNs.ToList();
                    combo_select_subgroup.ValueMember = "SessionId";
                    combo_select_subgroup.DisplayMember = "SessionId";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //loadTime
        private void loadTime()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combo_time.DataSource = db.Lectures.ToList();
                    combo_time.ValueMember = "LecID";
                    combo_time.DisplayMember = "Time";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_save_notAvTime_Click(object sender, EventArgs e)
        {

            notAvailableTimeAlc.Selected_Lecturer = combo_select_Lec.Text.Trim();//trim is use to remove sapases 
            notAvailableTimeAlc.Selected_group = combo_select_group.Text.Trim();//trim is use to remove sapases 
            notAvailableTimeAlc.Selected_subgroup = combo_select_subgroup.Text.Trim();
            notAvailableTimeAlc.Selected_sessionId = Combo_seect_sessionID.Text.Trim();
            notAvailableTimeAlc.Time = combo_time.Text.Trim();
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.NotAvTimes.Add(notAvailableTimeAlc);
                db.SaveChanges();
            }
            clear();

            MessageBox.Show("Added Successfully");

            clear();
            loadData();
            MessageBox.Show("added Successfully");
        }


        public void loadData()
        {

            NotAvailableTime_grid.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                NotAvailableTime_grid.DataSource = db.NotAvTimes.ToList<NotAvTime>();
            }
        }

        private void NotAvailableTime_grid_DoubleClick(object sender, EventArgs e)
        {
            if (NotAvailableTime_grid.CurrentRow.Index != -1)
            {
                notAvailableTimeAlc.SessionID = Convert.ToInt32(NotAvailableTime_grid.CurrentRow.Cells["SessionID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    notAvailableTimeAlc = db.NotAvTimes.Where(x => x.SessionID == notAvailableTimeAlc.SessionID).FirstOrDefault();
                    combo_select_Lec.Text = notAvailableTimeAlc.Selected_Lecturer;
                    combo_select_group.Text = notAvailableTimeAlc.Selected_group;
                    combo_select_subgroup.Text = notAvailableTimeAlc.Selected_subgroup;
                    Combo_seect_sessionID.Text = notAvailableTimeAlc.Selected_sessionId;
                    combo_time.Text = notAvailableTimeAlc.Time;
                }

                Delete_notAV_time.Enabled = true;
            }
        }

        private void update_mangenotAV_time_Click(object sender, EventArgs e)
        {
            notAvailableTimeAlc.Selected_Lecturer = combo_select_Lec.Text.Trim();//trim is use to remove sapases 
            notAvailableTimeAlc.Selected_group = combo_select_group.Text.Trim();
            notAvailableTimeAlc.Selected_subgroup = combo_select_subgroup.Text.Trim();
            notAvailableTimeAlc.Selected_sessionId = Combo_seect_sessionID.Text.Trim();
            notAvailableTimeAlc.Time = combo_time.Text.Trim();

            using (EFDBEntities1 db = new EFDBEntities1())
            {
                if (notAvailableTimeAlc.SessionID == 0)
                {

                }
                else
                {
                    db.Entry(notAvailableTimeAlc).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        private void Delete_notAV_time_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(notAvailableTimeAlc);
                    if (entry.State == EntityState.Detached)
                    {
                        db.NotAvTimes.Attach(notAvailableTimeAlc);
                        db.NotAvTimes.Remove(notAvailableTimeAlc);
                        db.SaveChanges();
                        loadData();

                        clear();

                        MessageBox.Show("Location Deleted Successfully");
                    }
                }
            }
        }

        private void btnClear_Addlocation_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void home7btn_Click(object sender, EventArgs e)
        {
            linlTimeSlot linl = new linlTimeSlot();
            linl.Show();
            this.Hide();

        }

        private void close1btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
