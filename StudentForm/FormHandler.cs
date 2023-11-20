namespace StudentForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        List<Student> students = new List<Student>();

        private void btnAddToList_Click(object sender, EventArgs e) {
            string regNo = txtReg.Text;
            string name = txtName.Text;
            DateTime dob = dtDob.Value;
            double age = DateTime.Now.Subtract(dob).TotalDays / 365;
            string path = openFileDialog1.FileName;
            string degree = cmbxDegree.SelectedItem.ToString();
            string interdegree = "";
            if (rdBtnICS.Checked) {
                interdegree = "ICS";
            }
            else if (rdBtnPreEng.Checked) {
                interdegree = "Pre-Eng";
            }
            else {
                interdegree = "Pre-Med";
            }
            bool aidRequired = chkNeedScholarship.Checked;
            double obtMarks = double.Parse(txtObtained.Text);
            int total = int.Parse(txtTotal.Text);
            double percentage = (obtMarks / total) * 100;

            Student s = new Student() {
                RegNo = regNo,
                Name = name,
                DOB = dob,
                Age = age,
                ImagePath = path,
                Degree = degree,
                InterDegree = interdegree,
                AidRequired = aidRequired,
                Percentage = percentage,

            };
            students.Add(s);
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK) {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnShowData_Click(object sender, EventArgs e) {
            foreach (Student item in students) {
                dataGridView1.Rows.Add(item.RegNo, item.Name, item.Degree, item.DOB.ToShortDateString(), item.Age, item.Percentage, item.InterDegree, (item.AidRequired ? "Yes" : "No"), item.ImagePath);
            }
        }
    }
}
