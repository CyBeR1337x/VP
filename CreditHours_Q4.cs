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
    public partial class CreditHours : Form {
        public CreditHours() {
            InitializeComponent();
        }

        int totalCredits = 0;
        List<CheckBox> checkBoxes;

        private void CreditHours_Load(object sender, EventArgs e) {
            checkBoxes = new List<CheckBox>() {
                chkPF,
                chkOOP,
                chkProject,
                chkDS,
                chkJava,
                chkPST,
                chkFA,
                chkTA,
                chkDB,
                chkDLD,
                chkCoal,
                chkDSA
            };
        }

        public void disableChecks() {
            for (int i = 0; i < checkBoxes.Count; i++)
                if (!checkBoxes[i].Checked)
                    checkBoxes[i].Enabled = false;
        }
        public void enableChecks() {
            for (int i = 0; i < checkBoxes.Count; i++)
                if (!checkBoxes[i].Checked)
                    checkBoxes[i].Enabled = true;
        }

        public void handleCheckBox(CheckBox chkBox, int cr) {
            if (chkBox.Checked) {
                if (totalCredits + cr <= 21)
                    totalCredits += cr;
                else
                    chkBox.Enabled = false;

                if (totalCredits >= 21)
                    disableChecks();
            }
            else {
                totalCredits -= cr;
                enableChecks();
            }

            lblCredits.Text = "Total Credits: " + totalCredits.ToString();
        }

        private void chkPF_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkPF, 4);
        }

        private void chkOOP_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkOOP, 4);
        }

        private void chkDS_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkDS, 3);
        }

        private void chkJava_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkJava, 4);
        }

        private void chkCoal_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkCoal, 4);
        }

        private void chkDB_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkDB, 4);
        }

        private void chkDSA_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkDSA, 4);
        }

        private void chkPST_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkPST, 1);
        }

        private void chkFA_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkFA, 3);
        }

        private void chkTA_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkTA, 3);
        }

        private void chkProject_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkProject, 6);
        }

        private void chkDLD_CheckedChanged(object sender, EventArgs e) {
            handleCheckBox(chkDLD, 3);
        }
    }
}
