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
    public partial class GotoAcademic : Form
    {
        public GotoAcademic()
        {
            InitializeComponent();
        }

        private void GotoAcademic_Load(object sender, EventArgs e)
        {

        }

        private void btnAddTag1_Click(object sender, EventArgs e)
        {
            AddTag addtag = new AddTag();
            addtag.Show();
            this.Hide();
        }

       

        private void btnsession_Click(object sender, EventArgs e)
        {
            Session session = new Session();
            session.Show();
            this.Hide();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void home2btn_Click(object sender, EventArgs e)
        {
            Form1 formmm = new Form1();
            formmm.Show();
            this.Hide();
        }
    }
}
