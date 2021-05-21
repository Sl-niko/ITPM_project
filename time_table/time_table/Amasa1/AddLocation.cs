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
    public partial class AddLocation : Form
    {

        AddLocation11 modeladdLocation11 = new AddLocation11();
        public AddLocation()
        {
            InitializeComponent();
        }

        private void loadSession()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combo_sessionID.DataSource = db.SessionNs.ToList();
                    combo_sessionID.ValueMember = "SessionId";
                    combo_sessionID.DisplayMember = "SessionId";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


      

        private void loadStartTime()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combo_strtTime.DataSource = db.add_time_slot.ToList();
                    combo_strtTime.ValueMember = "Lec_id";
                    combo_strtTime.DisplayMember = "start_time_hrs";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void loadEndTime()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    Combo_endTime.DataSource = db.add_time_slot.ToList();
                    Combo_endTime.ValueMember = "Lec_id";
                    Combo_endTime.DisplayMember = "end_time_hrs";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void loadroomID()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combo_roomID.DataSource = db.Rooms.ToList();
                    combo_roomID.ValueMember = "RoomID";
                    combo_roomID.DisplayMember = "RoomName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void close1btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void clear()
        {
            combo_sessionID.SelectedIndex = -1;
            combo_strtTime.SelectedIndex = -1;
            Combo_endTime.SelectedIndex = -1;
            combo_roomID.SelectedIndex = -1;

        }

        private void AddLocation_Load(object sender, EventArgs e)
        {
            loadSession();
            loadroomID();
            loadStartTime();
            loadEndTime();
            clear();

            btn_delete_addlocation.Enabled = false;
        }

        private void btnClear_Addlocation_Click(object sender, EventArgs e)
        {

            clear();
        }


        public void loadData()
        {

            AddLoc_GridView1.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                AddLoc_GridView1.DataSource = db.AddLocation11.ToList<AddLocation11>();

            }
        }

        private void btn_save_addlocation_Click(object sender, EventArgs e)
        {
            modeladdLocation11.SessionID = combo_sessionID.Text.Trim();
            modeladdLocation11.Date = guna2DateTimePicker1.Text.Trim();
            modeladdLocation11.StartTime = combo_strtTime.Text.Trim();
            modeladdLocation11.EndTime = Combo_endTime.Text.Trim();
            modeladdLocation11.RoomID = combo_roomID.Text.Trim();


            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.AddLocation11.Add(modeladdLocation11);
                db.SaveChanges();
            }
            loadData();
            clear();

            MessageBox.Show("Location added Successfully");
        }

        private void btn_Update_addlocation_Click(object sender, EventArgs e)
        {
            modeladdLocation11.SessionID = combo_sessionID.Text.Trim();//trim is use to remove sapases 
            modeladdLocation11.Date = guna2DateTimePicker1.Text.Trim();
            modeladdLocation11.StartTime = combo_strtTime.Text.Trim();
            modeladdLocation11.EndTime = Combo_endTime.Text.Trim();
            modeladdLocation11.RoomID = combo_roomID.Text.Trim();

            using (EFDBEntities1 db = new EFDBEntities1())
            {
                if (modeladdLocation11.Id == 0)
                {

                }
                else
                {
                    db.Entry(modeladdLocation11).State = EntityState.Modified;
                    db.SaveChanges();

                }

                clear();
                loadData();

                MessageBox.Show("Location Updated Successfully");
            }
        }

        private void AddLoc_GridView1_DoubleClick(object sender, EventArgs e)
        {
            if (AddLoc_GridView1.CurrentRow.Index != -1)
            {
                modeladdLocation11.Id = Convert.ToInt32(AddLoc_GridView1.CurrentRow.Cells["Id"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modeladdLocation11 = db.AddLocation11.Where(x => x.Id == modeladdLocation11.Id).FirstOrDefault();
                    combo_sessionID.Text = modeladdLocation11.SessionID;
                    guna2DateTimePicker1.Text = modeladdLocation11.Date;
                    combo_strtTime.Text = modeladdLocation11.StartTime;

                    Combo_endTime.Text = modeladdLocation11.EndTime;
                    combo_roomID.Text = modeladdLocation11.RoomID;
  
                }

                btn_delete_addlocation.Enabled = true;
            }
        }

        private void btn_delete_addlocation_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modeladdLocation11);
                    if (entry.State == EntityState.Detached)
                    {
                        db.AddLocation11.Attach(modeladdLocation11);
                        db.AddLocation11.Remove(modeladdLocation11);
                        db.SaveChanges();
                        loadData();

                        clear();

                        MessageBox.Show("Location Deleted Successfully");
                    }
                }
            }
        }

        private void home1btn_Click(object sender, EventArgs e)
        {
            linlTimeSlot link = new linlTimeSlot();
            link.Show();
            this.Close();

        }
    }
}
