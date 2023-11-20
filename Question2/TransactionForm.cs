using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentForm {
    public partial class TransactionForm : Form {
        public TransactionForm() {
            InitializeComponent();
        }

        private void TransactionForm_Load(object sender, EventArgs e) {
            groupBox1.Text = LoginForm.accountDetails[LoginForm.loggedInUser].account_num.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            try {
                if (!rdButtonWithdraw.Checked && !rdBtnDeposit.Checked) {
                    MessageBox.Show("You Must select a Method!");
                    return;
                }
                if (txtAmount.Text == "") {
                    MessageBox.Show("Enter Amount!");
                    return;
                }

                int amount = int.Parse(txtAmount.Text);
                DialogResult x = MessageBox.Show("Do you confirm your transaction?", "Confirmation", MessageBoxButtons.YesNo);
                if (x == DialogResult.Yes) {
                    if (rdBtnDeposit.Checked) {
                        LoginForm.accountDetails[LoginForm.loggedInUser].amount += amount;
                    }
                    if (rdButtonWithdraw.Checked) {
                        LoginForm.accountDetails[LoginForm.loggedInUser].amount -= amount;
                    }
                }


            }
            catch (Exception ex) {

            }
        }
    }
}
