using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_table.Amasa1
{
    public partial class linlTimeSlot : Form
    {
        public linlTimeSlot()
        {
            InitializeComponent();
        }

        private void home5btn_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void lectStst_btn_Click(object sender, EventArgs e)
        {
            WorkingDay workingDay = new WorkingDay();
            workingDay.Show();
            this.Hide();
        }

        private void subject_stat_btn_Click(object sender, EventArgs e)
        {
            AddTimeSlots addTimeSlots = new AddTimeSlots();
            addTimeSlots.Show();
            this.Hide();
        }

        private void btnaddlocation_Click(object sender, EventArgs e)
        {
            AddLocation add = new AddLocation();
            add.Show();
            this.Hide();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NotAvailableTime notAvailable = new NotAvailableTime();
            notAvailable.Show();
            this.Hide();
        }
    }
}
