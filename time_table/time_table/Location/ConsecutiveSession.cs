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
    public partial class ConsecutiveSession : Form
    {
        RoomFConsecSessi modelconsec = new RoomFConsecSessi();
        
        public ConsecutiveSession()
        {
            InitializeComponent();
        }

        private void closebtn4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home3btn_Click(object sender, EventArgs e)
        {
            LinkLocation linkll = new LinkLocation();
            linkll.Show();
            this.Close();
        }


        private void loadRoom()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    comboName.DataSource = db.Rooms.ToList();
                    comboName.ValueMember = "RoomID";
                    comboName.DisplayMember = "RoomName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void loadsesstion()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    combosesse1.DataSource = db.SessionNs.ToList();
                    combosesse1.ValueMember = "SessionId";
                    combosesse1.DisplayMember = "SessionId";


                    cobosess2.DataSource = db.SessionNs.ToList();
                    cobosess2.ValueMember = "SessionId";
                    cobosess2.DisplayMember = "SessionId";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            modelconsec.Session1 = combosesse1.Text.Trim();
            modelconsec.Session2 = cobosess2.Text.Trim();
            modelconsec.RoomName = comboName.Text.Trim();


            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.RoomFConsecSessis.Add(modelconsec);
                db.SaveChanges();
            }
            loadData();
            clear();

            MessageBox.Show("Room Allocate Successfully");
        }


        public void loadData()
        {

            gridRoomfConsec.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                gridRoomfConsec.DataSource = db.RoomFConsecSessis.ToList<RoomFConsecSessi>();
            }

        }


        private void clear()
        {
            combosesse1.SelectedIndex = -1;
            cobosess2.SelectedIndex = -1;
            comboName.SelectedIndex = -1;

            btnRemove.Enabled = false;

        }

        private void ConsecutiveSession_Load(object sender, EventArgs e)
        {
      
            loadData();
            loadsesstion();
            loadRoom();
            clear();

            label1.Text = DateTime.Now.ToLongDateString();
        }

        private void gridRoomfConsec_DoubleClick(object sender, EventArgs e)
        {
            if (gridRoomfConsec.CurrentRow.Index != -1)
            {
                modelconsec.RFseId = Convert.ToInt32(gridRoomfConsec.CurrentRow.Cells["RFseId"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelconsec = db.RoomFConsecSessis.Where(x => x.RFseId == modelconsec.RFseId).FirstOrDefault();


                }

                btnRemove.Enabled = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modelconsec);
                    if (entry.State == EntityState.Detached)
                    {
                        db.RoomFConsecSessis.Attach(modelconsec);
                        db.RoomFConsecSessis.Remove(modelconsec);
                        db.SaveChanges();
                        loadData();

                        clear();

                        MessageBox.Show("Room Deleted Successfully");
                    }
                }
            }
        }
    }
}
