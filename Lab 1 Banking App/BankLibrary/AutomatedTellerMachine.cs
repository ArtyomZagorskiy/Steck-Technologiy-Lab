namespace BankLibrary
{
    public class AutomatedTellerMachine 
    {
        public float moneyCount;
        public int id;
        public Bank bank;
        public Account currentAccount;
        public List<Transaction> transactions = new List<Transaction> ();

        public AutomatedTellerMachine(float moneyCount, int id, Bank bank)
        {
            this.moneyCount = moneyCount;
            this.id = id;
            this.bank = bank;
        }

        public float getCurrentBallance()
        {
            if (currentAccount != null)
                return currentAccount.money;
            
            return -1;
        }

        public void WithdrawOperation(float amount, int pin)
        {
            if (currentAccount != null && currentAccount.pinChecker(pin) && amount <= moneyCount)
                currentAccount.Withdraw(amount);
            AddNewTransaction(amount, TransactionType.Withdraw);

        }

        public void TopUpOperation(float amount, int pin)
        {
            if (currentAccount != null && currentAccount.pinChecker(pin))
                currentAccount.Topup(amount);
                AddNewTransaction(amount, TransactionType.TopUp);

        }

        public void TransferOperation(float amount, int pin, string recieverCardNumber)
        {
            if (currentAccount != null && currentAccount.pinChecker(pin) && amount > 0)
            {
                currentAccount.Withdraw(amount);
                bank.GetAccountByCardNumber(recieverCardNumber).Topup(amount);
                AddNewTransaction(amount, TransactionType.Transfer, recieverCardNumber);
            }
        }

        public List<Transaction> GetTransactionHistory(TransactionPeriod period)
        {
            List<Transaction> filteredTransactions = new List<Transaction>();

            DateTime now = DateTime.Now; 
            string dateFormat = "dd/MM/yyyy HH:mm:ss";

            foreach (var transaction in transactions)
            {
                DateTime transactionDate;

                if (DateTime.TryParseExact(transaction.date, dateFormat, null, System.Globalization.DateTimeStyles.None, out transactionDate))
                {
                    switch (period)
                    {
                        case TransactionPeriod.day:
                            if (transactionDate.Day == now.Day)
                            {
                                filteredTransactions.Add(transaction);
                            }
                            break;

                        case TransactionPeriod.week:
                            var currentWeekStart = now.AddDays(-(int)now.DayOfWeek);
                            var currentWeekEnd = currentWeekStart.AddDays(7);

                            if (transactionDate >= currentWeekStart && transactionDate < currentWeekEnd)
                            {
                                filteredTransactions.Add(transaction);
                            }
                            break;

                        case TransactionPeriod.month:
                            if (transactionDate.Year == now.Year && transactionDate.Month == now.Month)
                            {
                                filteredTransactions.Add(transaction);
                            }
                            break;
                    }
                }
            }

            return filteredTransactions;
        }

        public void AddNewTransaction(float _amount, TransactionType _type, string cardNumber2 = "")
        {
            Transaction tr = new Transaction();
            tr.amount = _amount;
            tr.type = _type;
            tr.cardNumber = currentAccount.cardNumber;

            DateTime lastTransactionDate = transactions.Count > 0
                ? DateTime.ParseExact(transactions.Last().date, "dd/MM/yyyy HH:mm:ss", null)
                : DateTime.Now;

            
            Random rand = new Random();
            int randomHours = rand.Next(1, 12); 
            int randomMinutes = rand.Next(0, 60);

            DateTime newTransactionDate = lastTransactionDate;
            if (transactions.Count > 0)
            { 
                newTransactionDate = lastTransactionDate.AddHours(randomHours).AddMinutes(randomMinutes);//.AddDays(randomDays)
            } 


            tr.date = newTransactionDate.ToString("dd/MM/yyyy HH:mm:ss");

            switch (_type)
            {
                case TransactionType.Withdraw:
                    tr.cardNumber = currentAccount.cardNumber;
                    break;
                case TransactionType.Transfer:
                    tr.cardNumber = currentAccount.cardNumber;
                    tr.cardNumber2 = cardNumber2;
                    break;
                case TransactionType.TopUp:
                    tr.cardNumber = currentAccount.cardNumber;
                    break;
            }

            transactions.Add(tr);
        }

    }

    public class Transaction
    {
        public float amount;
        public TransactionType type;
        public string date;
        public string cardNumber;
        public string cardNumber2;
    }

    public enum TransactionType
    {
        Withdraw,
        Transfer,
        TopUp
    }

    public enum TransactionPeriod
    {
        day,
        week,
        month
    }
}
