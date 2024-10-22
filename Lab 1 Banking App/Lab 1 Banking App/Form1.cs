using BankLibrary;

namespace Lab_1_Banking_App
{
    public delegate void GetCardAccount(string cardNumber);
    public partial class Form1 : Form
    {
        public Bank bank = new Bank();
        public AutomatedTellerMachine currentATM;

        public CardInput cardInputForm = new CardInput();
        public TransactionForm transactionForm = new TransactionForm();
        public TransitionForm2 transactionForm2 = new TransitionForm2();
        public History historyForm = new History();
        public Form1()
        {
            bank.AddNewATM(1200000f, 124, bank);
            currentATM = bank.machines[0];

            bank.AddNewAccount("1111222233334444", 1234, "John", 12000);
            bank.AddNewAccount("2222333344445555", 5555, "Steven", 350);
            bank.AddNewAccount("2222888877776666", 0000, "Bob", 1500000);
            cardInputForm.bank = bank;
            cardInputForm.cardHandler = SetCurrentAccountToATM;

            InitializeComponent();

            if (currentATM.currentAccount == null)
            {
                SetActiveMainMenu(false);
                SetActivePutTheCardScreen(true);
                cardInputForm.Show();
            }


        }

        private void watchBalancebutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("На карті " + currentATM.currentAccount.getCurrentMoneyNumber() + " деняг!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nearestATMButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Найближчий банкомат у 45ти метрів", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SetActiveMainMenu(bool active)
        {
            this.watchBalancebutton.Visible = active;
            this.transactionHistorybutton.Visible = active;
            this.nearestATMButton.Visible = active;
            this.withdrawButton.Visible = active;
            this.putMoneybutton.Visible = active;
            this.makeTransactionbutton.Visible = active;
            this.signOutButton.Visible = active;
        }

        public void SetActivePutTheCardScreen(bool active)
        {
            this.label1.Visible = active;
        }

        public void SetCurrentAccountToATM(string cardNumber)
        {
            currentATM.currentAccount = bank.GetAccountByCardNumber(cardNumber);
            SetActiveMainMenu(true);
            SetActivePutTheCardScreen(false);
            cardInputForm.Hide();
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            currentATM.currentAccount = null;
            SetActiveMainMenu(false);
            SetActivePutTheCardScreen(true);
            cardInputForm.Show();
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            transactionForm.machine = currentATM;
            transactionForm.Initialize(true);
            transactionForm.Show();
        }

        private void putMoneybutton_Click(object sender, EventArgs e)
        {
            transactionForm.machine = currentATM;
            transactionForm.Initialize(false);
            transactionForm.Show();
        }

        private void makeTransactionbutton_Click(object sender, EventArgs e)
        {
            transactionForm2.machine = currentATM;
            transactionForm2.Initialize();
            transactionForm2.Show();
        }

        private void transactionHistorybutton_Click(object sender, EventArgs e)
        {
            historyForm.Form_Load(currentATM);
            historyForm.Show();
        }
    }
}