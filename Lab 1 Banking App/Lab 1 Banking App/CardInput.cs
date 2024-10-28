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
    public partial class CardInput : Form
    {
        public Bank bank;
        public GetCardAccount cardHandler;
        public CardInput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cardNumber = textBox1.Text;
            if(bank.isCardExist(cardNumber))
            {
                cardHandler(cardNumber);
            }
            else
            {
                MessageBox.Show("Такої катрки не існує", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
