using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsPractice {
    public partial class EmployeeForm : Form {
        public EmployeeForm() {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK) {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            DateTime empDob = dtDob.Value;
            double age = DateTime.Now.Subtract(empDob).TotalDays / 365;
            if (age < 18) {
                MessageBox.Show("In-Eligible");
                return;
            }
            dataGridView1.Rows.Add(openFileDialog1.FileName, txtID.Text, txtName.Text, dtDOJ.Value.ToShortDateString(), dtDob.Value.ToShortDateString());
        }
    }
}
