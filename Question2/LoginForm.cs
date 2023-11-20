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
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();
        }

        public static List<AccountDetail> accountDetails;
        public static int loggedInUser = -1;


        public int GetAccount(string num, string pass) {
            for (int i = 0; i < accountDetails.Count; i++) {
                if (accountDetails[i].account_num == num && accountDetails[i].password == pass)
                    return i;
            }
            return -1;
        }

        private void Accounts_Load(object sender, EventArgs e) {
            accountDetails = new List<AccountDetail> {
                new AccountDetail {account_num = "101", password = "123", amount = 5000 },
                new AccountDetail {account_num = "102", password = "123", amount = 6000 },
                new AccountDetail {account_num = "103", password = "123", amount = 7000 },
                new AccountDetail {account_num = "104", password = "123", amount = 8000 },
            };
        }

        private void button1_Click(object sender, EventArgs e) {
            loggedInUser = GetAccount(txtAccNum.Text, txtPass.Text);    
            if (loggedInUser != -1) {
                TransactionForm t = new TransactionForm();
                t.Show();
            } else {
                MessageBox.Show("INVLAID LOGIN!");
            }
        }
    }
}
