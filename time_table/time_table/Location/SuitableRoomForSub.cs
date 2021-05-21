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
    public partial class SuitableRoomForSub : Form
    {
        SubForRoom modelSFsub = new SubForRoom();

        public SuitableRoomForSub()
        {
            InitializeComponent();
        }

        private void close7btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gotohome1btn_Click(object sender, EventArgs e)
        {
            LinkLocation link3 = new LinkLocation();
            link3.Show();
            this.Close();

        }

        private void loadSubj() {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    comboLoadSub.DataSource = db.Subject1.ToList();
                    comboLoadSub.ValueMember = "SID";
                    comboLoadSub.DisplayMember = "Subject_Name";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void loadRoom() {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    comboLoadRoom.DataSource = db.Rooms.ToList();
                    comboLoadRoom.ValueMember = "RoomID";
                    comboLoadRoom.DisplayMember = "RoomName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SuitableRoomForSub_Load(object sender, EventArgs e)
        {
            loadSubj();
            clear();
            loadRoom();
         
            label1.Text = DateTime.Now.ToLongDateString();
        }

        private void clear() {
            comboLoadSub.SelectedIndex = -1;
            comboLoadRoom.SelectedIndex = -1;

            btnRemove.Enabled = false;

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modelSFsub);
                    if (entry.State == EntityState.Detached)
                    {
                        db.SubForRooms.Attach(modelSFsub);
                        db.SubForRooms.Remove(modelSFsub);
                        db.SaveChanges();
                        loadData();

                        clear();

                        MessageBox.Show("Room Deleted Successfully");
                    }
                }
            }
        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            modelSFsub.subR = comboLoadSub.Text.Trim();
            modelSFsub.roomR = comboLoadRoom.Text.Trim();
  

            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.SubForRooms.Add(modelSFsub);
                db.SaveChanges();
            }
            loadData();
            clear();
         
            MessageBox.Show("Room Allocate Successfully");

           
        }


        public void loadData()
        {

            GridSuitablRforSub.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                GridSuitablRforSub.DataSource = db.SubForRooms.ToList<SubForRoom>();
            }
            
        }

        private void GridSuitablRforSub_DoubleClick(object sender, EventArgs e)
        {
            if (GridSuitablRforSub.CurrentRow.Index != -1)
            {
                modelSFsub.Ssub = Convert.ToInt32(GridSuitablRforSub.CurrentRow.Cells["Ssub"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelSFsub = db.SubForRooms.Where(x => x.Ssub == modelSFsub.Ssub).FirstOrDefault();
                    comboLoadSub.DisplayMember = modelSFsub.subR;
                    comboLoadRoom.DisplayMember = modelSFsub.roomR;
                   
                }

                btnRemove.Enabled = true;
            }
        }
    }

}
