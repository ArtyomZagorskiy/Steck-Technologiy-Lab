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
    public partial class TransitionForm2 : Form
    {
        public AutomatedTellerMachine machine;
        public TransitionForm2()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            if (machine != null)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                label2.Text = "Баланс: " + machine.currentAccount.money.ToString();
            }
        }

        private void TransitionForm2_Load(object sender, EventArgs e)
        {

        }

        private void makeTransactionButton_Click(object sender, EventArgs e)
        {
            if (machine.currentAccount == null) return;

            float money = float.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture);
            int pin = int.Parse(textBox2.Text);
            string reciever = textBox3.Text;
            if(!machine.bank.isCardExist(reciever)) MessageBox.Show("Помилка", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);


            if ( money > 0 && money <= machine.currentAccount.money && machine.currentAccount.pinChecker(pin))
            {
                
                machine.TransferOperation(money, pin, reciever);
                
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
    }
}
