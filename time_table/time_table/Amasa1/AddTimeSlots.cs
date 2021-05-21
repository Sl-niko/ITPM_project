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

namespace time_table.Amasa1
{
    public partial class AddTimeSlots : Form
    {

        add_time_slot model = new add_time_slot();
        public AddTimeSlots()
        {
            InitializeComponent();
        }

        private void ATS_save_Click(object sender, EventArgs e)
        {



            model.Batch_id = combo_batchID.SelectedItem.ToString();
            model.date = guna2DateTimePicker1.Value;
            model.time_slot = combo_timeslots.SelectedItem.ToString();
            model.start_time_hrs = combo_start_hrs.SelectedItem.ToString();
            model.end_time_hrs = combo_end_hrs.SelectedItem.ToString();



            using (EFDBEntities1 db = new EFDBEntities1())
            {
                db.add_time_slot.Add(model);

                db.SaveChanges();
            }

            loadData();
            MessageBox.Show(" Added Successfully");
        }

        public void test() {

            txtTest.Text = guna2DateTimePicker1.Value.ToString() ;

        }
        private void ATS_update_Click(object sender, EventArgs e)
        {
            model.Batch_id = combo_batchID.SelectedItem.ToString();
            model.date = guna2DateTimePicker1.Value;
            model.time_slot = combo_timeslots.SelectedItem.ToString();
            model.start_time_hrs = combo_start_hrs.SelectedItem.ToString();
            model.end_time_hrs = combo_end_hrs.SelectedItem.ToString();

            

            using (EFDBEntities1 db = new EFDBEntities1())
            {
                if (model.Lec_id == 0)
                {

                }
                else
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();

                }

                clear();
                loadData();

                MessageBox.Show("Room Updated Successfully");

            }
        }

        public void loadData()
        {

            guna2DataGridView1_MTS.AutoGenerateColumns = false;
            using (EFDBEntities1 db = new EFDBEntities1())
            {
                guna2DataGridView1_MTS.DataSource = db.add_time_slot.ToList<add_time_slot>();
            }
        }

        private void AddTimeSlots_Load(object sender, EventArgs e)
        {
            loadData();

            clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();

            test();
        }

        void clear()
        {
            combo_batchID.SelectedIndex = -1;
            combo_start_hrs.SelectedIndex = -1;
            combo_end_hrs.SelectedIndex = -1;
            combo_timeslots.SelectedIndex = -1;
            ATS_delete.Enabled = false;
          

        }

        private void ATS_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "OPtion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    var entry = db.Entry(model);
                    if (entry.State == EntityState.Detached)
                    {
                        db.add_time_slot.Attach(model);
                        db.add_time_slot.Remove(model);
                        db.SaveChanges();
                        loadData();

                        clear();

                        MessageBox.Show("Building Deleted Successfully");
                    }
                }
            }
        }

        private void closebtn2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DataGridView1_MTS_DoubleClick(object sender, EventArgs e)
        {
            if (guna2DataGridView1_MTS.CurrentRow.Index != -1)
            {
                model.Lec_id = Convert.ToInt32(guna2DataGridView1_MTS.CurrentRow.Cells["Lec_id"].Value);
                using (EFDBEntities1 db = new EFDBEntities1())
                {
                    model = db.add_time_slot.Where(x => x.Lec_id == model.Lec_id).FirstOrDefault();
                    combo_batchID.Text = model.Batch_id;
                    combo_start_hrs.Text = model.start_time_hrs;
                    combo_end_hrs.Text = model.end_time_hrs;
                    combo_timeslots.Text = model.time_slot;

                    guna2DateTimePicker1.Text = model.date.ToString();
       
                }

                ATS_delete.Enabled = true;
            }
        }

        private void home1btn_Click(object sender, EventArgs e)
        {
            linlTimeSlot linlTimeSl = new linlTimeSlot();
            linlTimeSl.Show();
            this.Hide();
        }
    }
}
