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
    public partial class SuitableRoomForLecturer : Form
    {
        RoomForLrctu modelroomForLec = new RoomForLrctu();
        public SuitableRoomForLecturer()
        {
            InitializeComponent();
        }

        private void close4btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home9btn_Click(object sender, EventArgs e)
        {
            LinkLocation link1 = new LinkLocation();
            link1.Show();
            this.Close();

        }

        private void loadRoom()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    comboRoomname.DataSource = db.Rooms.ToList();
                    comboRoomname.ValueMember = "RoomID";
                    comboRoomname.DisplayMember = "RoomName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void loadLect()
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    comboLectName.DataSource = db.Lectures.ToList();
                    comboLectName.ValueMember = "LecID";
                    comboLectName.DisplayMember = "LectureName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SuitableRoomForLecturer_Load(object sender, EventArgs e)
        {
            loadLect();
            loadData();
            loadRoom();

            clear();

            label1.Text = DateTime.Now.ToLongDateString();
            
        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            modelroomForLec.lecturName = comboLectName.Text.Trim();
            modelroomForLec.RoomName = comboRoomname.Text.Trim();


            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.RoomForLrctus.Add(modelroomForLec);
                db.SaveChanges();
            }
            loadData();
            clear();

            MessageBox.Show("Room Allocate Successfully");
        }



        public void loadData()
        {

            gridRoom_Lec.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                gridRoom_Lec.DataSource = db.RoomForLrctus.ToList<RoomForLrctu>();
            }

        }


        private void clear() {
            comboLectName.SelectedIndex = -1;
            comboRoomname.SelectedIndex = -1;

            btnRemove.Enabled = false;

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void gridRoom_Lec_DoubleClick(object sender, EventArgs e)
        {
            if (gridRoom_Lec.CurrentRow.Index != -1)
            {
                modelroomForLec.RFLID = Convert.ToInt32(gridRoom_Lec.CurrentRow.Cells["RFLID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelroomForLec = db.RoomForLrctus.Where(x => x.RFLID == modelroomForLec.RFLID).FirstOrDefault();
                   

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
                    var entry = db.Entry(modelroomForLec);
                    if (entry.State == EntityState.Detached)
                    {
                        db.RoomForLrctus.Attach(modelroomForLec);
                        db.RoomForLrctus.Remove(modelroomForLec);
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
