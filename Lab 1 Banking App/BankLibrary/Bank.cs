namespace BankLibrary
{
    public class Bank
    {
        public string name;
        public List<AutomatedTellerMachine> machines = new List<AutomatedTellerMachine>();
        public List<Account> accounts = new List<Account>();

        public Account GetAccountByCardNumber(string cardNumber)
        {
            return accounts?.FirstOrDefault(account => account.cardNumberCheker(cardNumber));
        }

        public void AddNewAccount(string _cardNumber, int _pin, string _name, float _money)
        {
            Account newAccount = new Account(_cardNumber, _pin, _name, _money);

            accounts.Add(newAccount);   
        }

        public void AddNewATM(float moneyCount, int id, Bank bank)
        {
            AutomatedTellerMachine machine = new AutomatedTellerMachine(moneyCount, id, bank);

            machines.Add(machine);
        }

        public bool isCardExist(string _cardNumber)
        {
            return accounts?.Any(account => account.cardNumberCheker(_cardNumber)) ?? false;
        }
    }
}
