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
    public partial class SuitableRoomForTag : Form
    {
        RoomForTag modelRoomForTag = new RoomForTag();
    
        public SuitableRoomForTag()
        {
            InitializeComponent();
        }

        private void close8btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home10btn_Click(object sender, EventArgs e)
        {
            LinkLocation location3 = new LinkLocation();
            location3.Show();
            this.Close();
        }



        private void loadRoom()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    comboRoom.DataSource = db.Rooms.ToList();
                    comboRoom.ValueMember = "RoomID";
                    comboRoom.DisplayMember = "RoomName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void LoadTag()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    comboTag.DataSource = db.AddTag11.ToList();
                    comboTag.ValueMember = "TagID";
                    comboTag.DisplayMember = "TagName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SuitableRoomForTag_Load(object sender, EventArgs e)
        {
            LoadTag();
            loadRoom();
            loadData();

            clear();
           
            label1.Text = DateTime.Now.ToLongDateString();

        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            modelRoomForTag.tagName = comboTag.Text.Trim();
            modelRoomForTag.RoomName = comboRoom.Text.Trim();


            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.RoomForTags.Add(modelRoomForTag);
                db.SaveChanges();
            }
            loadData();
            clear();

            MessageBox.Show("Room Allocate Successfully");
        }


        public void loadData()
        {

            gridTagforRomm.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                gridTagforRomm.DataSource = db.RoomForTags.ToList<RoomForTag>();
            }

        }

        private void clear()
        {
            comboTag.SelectedIndex = -1;
            comboRoom.SelectedIndex = -1;

            btnRoom.Enabled = false;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modelRoomForTag);
                    if (entry.State == EntityState.Detached)
                    {
                        db.RoomForTags.Attach(modelRoomForTag);
                        db.RoomForTags.Remove(modelRoomForTag);
                        db.SaveChanges();
                        loadData();

                        clear();

                        MessageBox.Show("Room Deleted Successfully");
                    }
                }
            }
        }

        private void gridTagforRomm_DoubleClick(object sender, EventArgs e)
        {
            if (gridTagforRomm.CurrentRow.Index != -1)
            {
                modelRoomForTag.RRTID = Convert.ToInt32(gridTagforRomm.CurrentRow.Cells["RRTID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelRoomForTag = db.RoomForTags.Where(x => x.RRTID == modelRoomForTag.RRTID).FirstOrDefault();


                }

                btnRoom.Enabled = true;
            }
        }
    }
}
