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
    public partial class SuitableRoomForSession : Form
    {
        RoomForS modelroomForS = new RoomForS();
        public SuitableRoomForSession()
        {
            InitializeComponent();
        }

        private void close5btn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void gotohome_Click(object sender, EventArgs e)
        {
            LinkLocation link2 = new LinkLocation();
            link2.Show();
            this.Close();

        }

        private void loadRoom()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    comboroom.DataSource = db.Rooms.ToList();
                    comboroom.ValueMember = "RoomID";
                    comboroom.DisplayMember = "RoomName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void loadsession()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combosession.DataSource = db.SessionNs.ToList();
                    combosession.ValueMember = "SessionId";
                    combosession.DisplayMember = "SessionId";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SuitableRoomForSession_Load(object sender, EventArgs e)
        {
            loadsession();
            loadRoom();

            loadData();

            clear();
            label1.Text = DateTime.Now.ToLongDateString();
            
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            modelroomForS.sesstionID = combosession.Text.Trim();
            modelroomForS.RoomName = comboroom.Text.Trim();



            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.RoomForSes.Add(modelroomForS);
                db.SaveChanges();
            }
            loadData();
            clear();

            MessageBox.Show("Room Allocate Successfully");
        }


        public void loadData()
        {

            gridRoomFSesstion.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                gridRoomFSesstion.DataSource = db.RoomForSes.ToList<RoomForS>();
            }

        }

      private void  clear() {
            comboroom.SelectedIndex = -1;
            combosession.SelectedIndex = -1;

            btnRemovee.Enabled = false;

        }

        private void gridRoomFSesstion_DoubleClick(object sender, EventArgs e)
        {
            if (gridRoomFSesstion.CurrentRow.Index != -1)
            {
                modelroomForS.RRsID = Convert.ToInt32(gridRoomFSesstion.CurrentRow.Cells["RRsID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelroomForS = db.RoomForSes.Where(x => x.RRsID == modelroomForS.RRsID).FirstOrDefault();
                    combosession.Text = modelroomForS.sesstionID;
                    comboroom.Text = modelroomForS.RoomName;
           
                }

                btnRemovee.Enabled = true;
            }
        }

        private void btnRemovee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modelroomForS);
                    if (entry.State == EntityState.Detached)
                    {
                        db.RoomForSes.Attach(modelroomForS);
                        db.RoomForSes.Remove(modelroomForS);
                        db.SaveChanges();
                        loadData();

                        clear();

                        MessageBox.Show("Room Deleted Successfully");
                    }
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
