using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankLibrary;

namespace Lab_1_Banking_App
{
    public partial class TransactionForm : Form
    {
        public AutomatedTellerMachine machine;
        public bool withdraw = true;
        public TransactionForm()
        {
            InitializeComponent();
        }

        public void Initialize(bool _withdraw)
        {
            if (machine != null)
            {
                withdraw = _withdraw;
                if(withdraw)
                {
                    labelTitle.Text = "Зняти готівку";
                    labelTitle.Location = new System.Drawing.Point(91, 31);
                    label1.Text = "Скільки хочете зняти:";
                }
                else
                {
                    labelTitle.Text = "Зарахувати готівку";
                    labelTitle.Location = new System.Drawing.Point(52, 31);
                    label1.Text = "Скільки хочете зарахувати:";
                }
                textBox1.Text = "";
                textBox2.Text = "";
                label2.Text = "Баланс: " + machine.currentAccount.money.ToString();
            }
        }

        private void makeTransactionButton_Click(object sender, EventArgs e)
        {
            if (machine.currentAccount == null) return;

            float money = float.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
            int pin = int.Parse(textBox2.Text);
            if ((withdraw && money > 0 && money <= machine.currentAccount.money && money <= machine.moneyCount) || (!withdraw && money > 0) && machine.currentAccount.pinChecker(pin))
            {
                if(withdraw)
                {
                    machine.WithdrawOperation(money, pin);
                }
                else
                {
                    machine.TopUpOperation(money, pin);
                }
                MessageBox.Show("Операція завершена!) На балансі: " + machine.currentAccount.money.ToString() + "деняг!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Помилка", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
