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
    public partial class AddBuildings : Form
    {
        Building modelbuil = new Building();

        public AddBuildings()
        {
            InitializeComponent();
        }

        private void closebtn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home1btn_Click(object sender, EventArgs e)
        {
            LinkLocation link = new LinkLocation();
            link.Show();
            this.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            txtbuilding_name.Text = "";
            txtnum_floors.Text = "";
            txt_num_lab.Text = "";
            txt_num_lecture.Text = "";

        
        }

        private void AddBuildings_Load(object sender, EventArgs e)
        {
            clear();
            lblqq.Text = DateTime.Now.ToLongDateString();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txtbuilding_name.Text == "" ||txtnum_floors.Text == "" ||txt_num_lecture.Text == "" || txt_num_lab.Text == "")
            {

                MessageBox.Show("Fill all details");

            }
            else {

                modelbuil.BuildingName = txtbuilding_name.Text.Trim();//trim is use to remove sapases 
                modelbuil.Num_of_Floors = txtnum_floors.Text.Trim();
                modelbuil.Num_of_Lectu = txt_num_lecture.Text.Trim();
                modelbuil.Num_of_lab = txt_num_lab.Text.Trim();
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    db.Buildings.Add(modelbuil);
                    db.SaveChanges();
                }
                clear();

                MessageBox.Show("Building Added Successfully");

            }
          
           
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            ManageBuildingLocations manage = new ManageBuildingLocations();
            manage.Show();
            this.Hide();
        }
    }
}
