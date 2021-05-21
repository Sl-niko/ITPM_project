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
    
    public partial class ManageBuildingLocations : Form
    {
        Building Modelbuil = new Building();
        public ManageBuildingLocations()
        {
            InitializeComponent();
            
        }

        private void closebtn6_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void show_data_GridView()
        {
            DgvBuilding.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                DgvBuilding.DataSource = db.Buildings.ToList<Building>();
            }
        }

        private void ManageBuildingLocations_Load(object sender, EventArgs e)
        {
            clear();
            show_data_GridView();

            label1.Text = DateTime.Now.ToLongDateString();
        }

        private void DgvBuilding_DoubleClick(object sender, EventArgs e)
        {
            if (DgvBuilding.CurrentRow.Index != -1)
            {
                Modelbuil.BuildingID = Convert.ToInt32(DgvBuilding.CurrentRow.Cells["BuildingID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    Modelbuil = db.Buildings.Where(x => x.BuildingID == Modelbuil.BuildingID).FirstOrDefault();
                    txtMbuildingName.Text = Modelbuil.BuildingName;
                    txtMnumLect.Text = Modelbuil.Num_of_Lectu;
                    txtMnumFloor.Text = Modelbuil.Num_of_Floors;
                    txtMnumLab.Text = Modelbuil.Num_of_lab;
                }

                btnDelete.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Modelbuil.BuildingName = txtMbuildingName.Text.Trim();//trim is use to remove sapases 
            Modelbuil.Num_of_Floors = txtMnumFloor.Text.Trim();
            Modelbuil.Num_of_Lectu = txtMnumLect.Text.Trim();
            Modelbuil.Num_of_lab = txtMnumLab.Text.Trim();
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                if (Modelbuil.BuildingID == 0)
                {

                }
                else {
                    db.Entry(Modelbuil).State = EntityState.Modified;
                    db.SaveChanges();

                }

                clear();
                show_data_GridView();

                MessageBox.Show("Building Updated Successfully");

            }
            
        }


        void clear()
        {
            txtMbuildingName.Text = "";
            txtMnumLect.Text = "";
            txtMnumFloor.Text = "";
            txtMnumLab.Text ="";
            btnDelete.Enabled = false;
            Modelbuil.BuildingID = 0;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(Modelbuil);
                    if (entry.State == EntityState.Detached)
                    {
                        db.Buildings.Attach(Modelbuil);
                        db.Buildings.Remove(Modelbuil);
                        db.SaveChanges();
                        show_data_GridView();

                        clear();

                        MessageBox.Show("Building Deleted Successfully");
                    }
                }
            }
        }

        private void home4btn_Click(object sender, EventArgs e)
        {
            AddBuildings add = new AddBuildings();
            add.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
