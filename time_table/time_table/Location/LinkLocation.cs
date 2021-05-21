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
    public partial class LinkLocation : Form
    {
        public LinkLocation()
        {
            InitializeComponent();
        }

        private void RegisterBuilding_Click(object sender, EventArgs e)
        {
            AddBuildings addBuildinng = new AddBuildings();
            addBuildinng.Show();
            this.Close();

        }

        private void gotoHome_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            home.Show();
            this.Close();

        }

        private void closebtn1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterRoombtn_Click(object sender, EventArgs e)
        {
            AddRooms addRooms = new AddRooms();
            addRooms.Show();
            this.Close();

        }

        private void consecutive_btn_Click(object sender, EventArgs e)
        {
            ConsecutiveSession consecutive = new ConsecutiveSession();
            consecutive.Show();
            this.Close();
        }

        private void suitableRforSub_btn_Click(object sender, EventArgs e)
        {
            SuitableRoomForSub suitableRoomForSub = new SuitableRoomForSub(); ;
            suitableRoomForSub.Show();
            this.Close();

        }

        private void suitableRforTag_btn_Click(object sender, EventArgs e)
        {
            SuitableRoomForTag suitableRoomForTag = new SuitableRoomForTag();
            suitableRoomForTag.Show();
            this.Close();
        }

        private void SuitableRforLecture_btn_Click(object sender, EventArgs e)
        {
            SuitableRoomForLecturer suitableRoomForLecturer = new SuitableRoomForLecturer();
            suitableRoomForLecturer.Show();
            this.Close();
        }

        private void SuitableRforGroup_btn_Click(object sender, EventArgs e)
        {
            SuitableRoomForGroup suitableRoom = new SuitableRoomForGroup();
            suitableRoom.Show();
            this.Close();
        }

        private void SuitableRforSession_btn_Click(object sender, EventArgs e)
        {
            SuitableRoomForSession suitableRoomForSession = new SuitableRoomForSession();
            suitableRoomForSession.Show();
            this.Close();
        }

        private void LinkLocation_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
        }
    }
}
