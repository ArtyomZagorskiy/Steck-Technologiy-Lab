namespace BankLibrary
{
    public class Bank
    {
        public string name;
        public List<AutomatedTellerMachine> machines = new List<AutomatedTellerMachine>();
        public List<Account> accounts = new List<Account>();
        
        public Account GetAccountByCardNumber(string cardNumber)
        {
            if (accounts == null)
                return null;
            
            for(int i = 0; i < accounts.Count; i++)
            {
                if(accounts[i].cardNumberCheker(cardNumber))
                {
                    return accounts[i];
                }
            }

            return null;
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
            for(int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].cardNumberCheker(_cardNumber))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
