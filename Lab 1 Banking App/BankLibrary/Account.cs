namespace BankLibrary
{
    public class Account
    {
        public string cardNumber;
        public int pin;
        public string name;
        public float money;

        public Account(string _cardNumber,int _pin, string _name, float _money)
        {
            cardNumber = _cardNumber;
            pin = _pin;
            name = _name;
            money = _money;
        }

        public void Withdraw(float amount)
        {
            if(money >= amount)
            {
                money -= amount;
            }
        }

        public void Topup(float amount)
        {
            if (amount > 0)
            {
                money += amount;
            }
        }

        public float getCurrentMoneyNumber()
        {
            return money;
        }

        public void setMoneyNumber(float newAmount)
        {
            money = newAmount;
        }

        public bool pinChecker(int _pin)
        {
            return pin == _pin;
        }

        public bool cardNumberCheker(string _cardNumber)
        {
            return cardNumber == _cardNumber;
        }

        
    }
}
