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
    public partial class SuitableRoomForGroup : Form
    {
        RoomForGrSub ModelroomForGrSub = new RoomForGrSub();
        public SuitableRoomForGroup()
        {
            InitializeComponent();
        }

        private void close2btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home8btn_Click(object sender, EventArgs e)
        {
            LinkLocation location = new LinkLocation();
            location.Show();
            this.Close();

        }

        private void loadStdGr()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combostdGr.DataSource = db.Academic1.ToList();
                    combostdGr.ValueMember = "Studid";
                    combostdGr.DisplayMember = "GroupId11";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void loadStdSubGr()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combosubGr.DataSource = db.Academic1.ToList();
                    combosubGr.ValueMember = "Studid";
                    combosubGr.DisplayMember = "SubGroupId11";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ModelroomForGrSub.stdG = combostdGr.Text.Trim();
            ModelroomForGrSub.stdsubG = combosubGr.Text.Trim();
            ModelroomForGrSub.roomNam = comboRoom.Text.Trim();


            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.RoomForGrSubs.Add(ModelroomForGrSub);
                db.SaveChanges();
            }
            loadData();
            clear();

            MessageBox.Show("Room Allocate Successfully");

        }

        private void SuitableRoomForGroup_Load(object sender, EventArgs e)
        {
            loadStdSubGr();
            loadStdGr();
            loadRoom();

            label1.Text = DateTime.Now.ToLongDateString();
            clear();
        }

        public void loadData()
        {

            GridroomForGroupSub.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                GridroomForGroupSub.DataSource = db.RoomForGrSubs.ToList<RoomForGrSub>();
            }

        }

        public void clear() {
            combostdGr.SelectedIndex = -1;
            combosubGr.SelectedIndex = -1;
            comboRoom.SelectedIndex = -1;
            Removebtn.Enabled = false;
        }

        private void GridroomForGroupSub_DoubleClick(object sender, EventArgs e)
        {
            if (GridroomForGroupSub.CurrentRow.Index != -1)
            {
                ModelroomForGrSub.RsubGID = Convert.ToInt32(GridroomForGroupSub.CurrentRow.Cells["RsubGID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    ModelroomForGrSub = db.RoomForGrSubs.Where(x => x.RsubGID == ModelroomForGrSub.RsubGID).FirstOrDefault();
                    combostdGr.Text = ModelroomForGrSub.stdG;
                    combosubGr.Text = ModelroomForGrSub.stdsubG;
                    comboRoom.Text = ModelroomForGrSub.roomNam;
                }

                Removebtn.Enabled = true;
            }
        }

        private void Removebtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(ModelroomForGrSub);
                    if (entry.State == EntityState.Detached)
                    {
                        db.RoomForGrSubs.Attach(ModelroomForGrSub);
                        db.RoomForGrSubs.Remove(ModelroomForGrSub);
                        db.SaveChanges();
                        loadData();

                        clear();

                        MessageBox.Show("Room Deleted Successfully");
                    }
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
