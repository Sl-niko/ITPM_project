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

namespace time_table.Location
{
    public partial class ManageRoom : Form
    {
        Room modelRoom = new Room();
        private String RoomtypeM;
        public ManageRoom()
        {
            InitializeComponent();
        }

        public void loadData() {

            DataGridRoom.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                DataGridRoom.DataSource = db.Rooms.ToList<Room>();
            }
        }

        private void ManageRoom_Load(object sender, EventArgs e)
        {
            loadData();
            label3.Text = DateTime.Now.ToLongDateString();
            
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    ComboBoxbName.DataSource = db.Buildings.ToList();
                    ComboBoxbName.ValueMember = "BuildingID";
                    ComboBoxbName.DisplayMember = "BuildingName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closebtn7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home5btn_Click(object sender, EventArgs e)
        {
            AddRooms addRooms = new AddRooms();
            addRooms.Show();
            this.Close();
        }

        private void DataGridRoom_DoubleClick(object sender, EventArgs e)
        {
            if (DataGridRoom.CurrentRow.Index != -1)
            {
                modelRoom.RoomID = Convert.ToInt32(DataGridRoom.CurrentRow.Cells["RoomID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelRoom = db.Rooms.Where(x => x.RoomID == modelRoom.RoomID).FirstOrDefault();
                    ComboBoxbName.Text = modelRoom.RoomName;
                    txtRoomName.Text = modelRoom.RoomName;
                    txtCapacity.Text = modelRoom.Capacity;
                    if (modelRoom.RoomType == "LectureHall")
                    {
                        Readio_lec.Checked = true;
                    }
                    else if (modelRoom.RoomType == "Laboratory")
                    {
                        RadioLab.Checked = true;

                    }
                    else {
                        Readio_lec.Checked = false;
                        RadioLab.Checked = false;

                    }
                }

                btnDeleteR.Enabled = true;
            }
        }

        private void btnUpdateR_Click(object sender, EventArgs e)
        {
            //trim is use to remove sapases 


            modelRoom.BuildingName = ComboBoxbName.Text.Trim();
            modelRoom.RoomName = txtRoomName.Text.Trim();
            modelRoom.RoomType = RoomtypeM;
            modelRoom.Capacity = txtCapacity.Text.Trim();
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                if (modelRoom.RoomID == 0)
                {

                }
                else
                {
                    db.Entry(modelRoom).State = EntityState.Modified;
                    db.SaveChanges();

                }

                clear();
                loadData();

                MessageBox.Show("Room Updated Successfully");

            }
        }


        public void clear()
        {
            ComboBoxbName.SelectedIndex = -1;
            txtRoomName.Text = "";
            txtCapacity.Text = "";
            Readio_lec.Checked = false;
            RadioLab.Checked = false;
            btnDeleteR.Enabled = false;
            modelRoom.RoomID = 0;

        }

        private void Readio_lec_CheckedChanged(object sender, EventArgs e)
        {
            RoomtypeM = "LectureHall";
        }

        private void RadioLab_CheckedChanged(object sender, EventArgs e)
        {
            RoomtypeM = "Laboratory";
        }

        private void btnDeleteR_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modelRoom);
                    if (entry.State == EntityState.Detached)
                    {
                        db.Rooms.Attach(modelRoom);
                        db.Rooms.Remove(modelRoom);
                        db.SaveChanges();
                        loadData();

                        clear();

                        MessageBox.Show("Room Deleted Successfully");
                    }
                }
            }
        }

        private void btnClearR_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
