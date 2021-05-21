using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_table.Location
{
    public partial class AddRooms : Form
    {
        Room modelRoom = new Room();
        private String Roomtype;
        public AddRooms()
        {
            InitializeComponent();
        }

        private void closebtn3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home2btn_Click(object sender, EventArgs e)
        {
            LinkLocation listL = new LinkLocation();
            listL.Show();
            this.Close();

        }

        private void AddRooms_Load(object sender, EventArgs e)
        {
            try
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    comboBuilding.DataSource = db.Buildings.ToList();
                    comboBuilding.ValueMember = "BuildingID";
                    comboBuilding.DisplayMember = "BuildingName";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


            label4.Text = DateTime.Now.ToLongDateString();

        }



        public void clear()
        {
            comboBuilding.SelectedIndex=-1;
            txtRoomname.Text = "";
            txtcapasity.Text = "";
            radioLec.Checked = false;
            RadioLab.Checked = false;

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnRoomSave_Click(object sender, EventArgs e)
        {

            if (comboBuilding.Text == "" && txtRoomname.Text == "" || txtcapasity.Text == "")

            {
                MessageBox.Show("Fill all details");
            }
            else {
                modelRoom.BuildingName = comboBuilding.Text.Trim();
                modelRoom.RoomName = txtRoomname.Text.Trim();
                modelRoom.RoomType = Roomtype;
                modelRoom.Capacity = txtcapasity.Text.Trim();

                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    db.Rooms.Add(modelRoom);
                    db.SaveChanges();
                }
                clear();

                MessageBox.Show("Room Added Successfully");

            }
              
        }

        private void radioLec_CheckedChanged(object sender, EventArgs e)
        {
            Roomtype = "LectureHall";
        }

        private void RadioLab_CheckedChanged(object sender, EventArgs e)
        {
            
                Roomtype = "Laboratory";
        }

        private void RoomManage_Click(object sender, EventArgs e)
        {
            ManageRoom manag =new  ManageRoom();
            manag.Show();
            this.Hide();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
