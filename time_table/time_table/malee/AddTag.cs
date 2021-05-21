using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_table.malee
{
    public partial class AddTag : Form
    {
        AddTag11 addTagmodel = new AddTag11();
        public AddTag()
        {
            InitializeComponent();
        }

        private void btnSaveAddtag_Click(object sender, EventArgs e)
        {
            addTagmodel.TagName = txtTagName.Text.Trim();
            addTagmodel.TagCode = txtTagCode.Text.Trim();
            addTagmodel.RelatedTag = txtRelatedTag.Text.Trim();

            //remove the spaces (Trim function)
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.AddTag11.Add(addTagmodel);
                db.SaveChanges();

            }

            Clear();
            MessageBox.Show("Submitted Successfully");


        }

        void Clear()
        {
            txtTagName.Text = txtTagCode.Text = txtRelatedTag.Text = "";

        }

        private void btnClearAddtag_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void AddTag_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            ManageTags manage = new ManageTags();
            manage.Show();
            this.Hide();
        }

        private void home2btn_Click(object sender, EventArgs e)
        {
            GotoAcademic ac = new GotoAcademic();
            ac.Show();
            this.Hide();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
