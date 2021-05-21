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

namespace time_table.malee
{
    public partial class ManageTags : Form
    {

        AddTag11 modelTag1 = new AddTag11();
        public ManageTags()
        {
            InitializeComponent();
        }




        void show_data_Gridview()
        {
            gridVTag.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                gridVTag.DataSource = db.AddTag11.ToList<AddTag11>();
            }


        }

        private void ManageTags_Load(object sender, EventArgs e)
        {
            show_data_Gridview();
        }

        private void gridVTag_DoubleClick(object sender, EventArgs e)
        {
            if (gridVTag.CurrentRow.Index != -1)
            {
                modelTag1.TagID = Convert.ToInt32(gridVTag.CurrentRow.Cells["TagID"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    modelTag1 = db.AddTag11.Where(x => x.TagID == modelTag1.TagID).FirstOrDefault();

                    txtTagName.Text = modelTag1.TagName;
                    txtTagCode.Text = modelTag1.TagCode;
                    txtRelatedTag.Text = modelTag1.RelatedTag;

                }

                btnDeleteTag.Enabled = true;
            }
        }

        void clear()
        {

            txtTagName.Text = "";
            txtTagCode.Text = "";
            txtRelatedTag.Text = "";
            btnDeleteTag.Enabled = false;
            modelTag1.TagID = 0;
        }

        private void btnClearTag_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnDeleteTag_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(modelTag1);
                    if (entry.State == EntityState.Detached)
                    {
                        db.AddTag11.Attach(modelTag1);
                        db.AddTag11.Remove(modelTag1);
                        db.SaveChanges();

                        show_data_Gridview();

                        clear();

                        MessageBox.Show("Submitted Successfully");
                    }
                }


            }
        }

        private void btnUpdateTag_Click(object sender, EventArgs e)
        {
            modelTag1.TagName = txtTagName.Text.Trim();
            modelTag1.TagCode = txtTagCode.Text.Trim();
            modelTag1.RelatedTag = txtRelatedTag.Text.Trim();
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                if (modelTag1.TagID == 0)
                {
                }
                else
                {
                    db.Entry(modelTag1).State = EntityState.Modified;
                    db.SaveChanges();
                }

                clear();
                show_data_Gridview();
                MessageBox.Show("Submitted Successfully");
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home2btn_Click(object sender, EventArgs e)
        {
            AddTag add = new AddTag();
            add.Show();
            this.Close();
        }
    }
}
