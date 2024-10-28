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
    public partial class History : Form
    {
        public AutomatedTellerMachine currentATM;
        public History()
        {
            InitializeComponent();
        }

        public void Form_Load(AutomatedTellerMachine _currentATM)
        {
            currentATM = _currentATM;
            DisplayTransactions(currentATM.GetTransactionHistory(TransactionPeriod.day));
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DisplayTransactions(List<Transaction> transactions)
        {

            transactionsDataGridView.Rows.Clear();

            foreach (var transaction in transactions)
            {
                string[] row = new string[] {
                    transaction.type.ToString(),
                    transaction.amount.ToString(),
                    transaction.date,
                    transaction.type == TransactionType.Transfer ? "Відправник " +  transaction.cardNumber + "\nОтримувач " + transaction.cardNumber2 : "Номер аккаунта " + transaction.cardNumber
                };
                transactionsDataGridView.Rows.Add(row);
            }
        }

        private void History_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                DisplayTransactions(currentATM.GetTransactionHistory(TransactionPeriod.day));
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                DisplayTransactions(currentATM.GetTransactionHistory(TransactionPeriod.week));
            }
            else
            {
                DisplayTransactions(currentATM.GetTransactionHistory(TransactionPeriod.month));
            }
        }
    }
}
