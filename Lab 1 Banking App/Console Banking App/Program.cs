
using System;
using BankLibrary;

public  class Program
{
    public static void Main(string[] args)
    {
        Bank bank = new Bank();
        AutomatedTellerMachine currentATM = new AutomatedTellerMachine(100000f, 124, bank);
        Source source = new Source();

        bank.AddNewAccount("1111222233334444", 1234, "John", 12000);
        bank.AddNewAccount("2222333344445555", 5555, "Steven", 350);
        bank.AddNewAccount("2222888877776666", 0000, "Bob", 1500000);

        for (;;)
        {
            
            if (currentATM.currentAccount == null)
            {
                Console.WriteLine("Ви не авторизованi!");
                Console.WriteLine("Ведiть номер картки: ");
                string cardNumber = Console.ReadLine();
                if(bank.isCardExist(cardNumber))
                {
                    currentATM.currentAccount = bank.GetAccountByCardNumber(cardNumber);    
                }
                else
                {
                    Console.WriteLine("Помилка!");
                    continue;
                }
            }
            switch (source.Menu())
            {
                case 0:
                    source.SetError();
                    break;
                case 1:
                    Console.WriteLine("На балансi " + currentATM.currentAccount.money + " деняг!\n");
                    break;
                case 2:
                    if(currentATM.transactions.Count == 0)
                    {
                        Console.WriteLine("Транзакцiй немає:(");
                        continue;
                    }
                    Console.WriteLine("За який перiод транзакцiї(день, тиждень, мiсяць): ");
                    string period = Console.ReadLine(); 
                    if(period == "день")
                    {
                        source.DriteAllTransactions(currentATM.GetTransactionHistory(TransactionPeriod.day));
                    }   
                    else if(period == "тиждень")
                    {
                        source.DriteAllTransactions(currentATM.GetTransactionHistory(TransactionPeriod.week));
                    }
                    else if(period == "мiсяць")
                    {
                        source.DriteAllTransactions(currentATM.GetTransactionHistory(TransactionPeriod.month));

                    }
                    else
                    {
                        source.SetError();
                    }
                    break;
                case 3:
                    Console.WriteLine("Найближчий банкомат у 45ти метрiв.\n");
                    break;
                case 4:
                    for(; ; )
                    {
                        Console.WriteLine("Якщо хочете закінчити операцію введіть - стоп");
                        Console.WriteLine("Введіть сумму: ");
                        string moneyToTake = Console.ReadLine();
                        if (moneyToTake == "стоп") break;

                        Console.WriteLine("Введіть пін: ");
                        string pinString = Console.ReadLine();
                        if (pinString == "стоп") break;

                        float money = float.Parse(moneyToTake, System.Globalization.CultureInfo.InvariantCulture);
                        int pin = int.Parse(pinString);
                        if ((money > 0 && money <= currentATM.currentAccount.money && money <= currentATM.moneyCount) && currentATM.currentAccount.pinChecker(pin))
                        {
                            currentATM.WithdrawOperation(money, pin);
                            Console.WriteLine("Операція завершена!) На балансі: " + currentATM.currentAccount.money.ToString() + " деняг!\n");
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Помилка!!!\n");                        
                        }
                    }
                    break;
                case 5:
                    for (; ; )
                    {
                        Console.WriteLine("Якщо хочете закінчити операцію введіть - стоп\n");
                        Console.WriteLine("Введіть сумму: ");
                        string moneyToPut = Console.ReadLine();
                        if (moneyToPut == "стоп") break;

                        Console.WriteLine("Введіть пін: ");
                        string pinString = Console.ReadLine();
                        if (pinString == "стоп") break;

                        float money = float.Parse(moneyToPut, System.Globalization.CultureInfo.InvariantCulture);
                        int pin = int.Parse(pinString);
                        if (money > 0 && currentATM.currentAccount.pinChecker(pin))
                        {
                            currentATM.TopUpOperation(money, pin);
                            Console.WriteLine("Операція завершена!) На балансі: " + currentATM.currentAccount.money.ToString() + " деняг!\n");
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Помилка!!!");
                        }
                    }
                    break;
                case 6:
                    for (; ; )
                    {
                        Console.WriteLine("Якщо хочете закінчити операцію введіть - стоп\n");

                        Console.WriteLine("Введіть сумму: ");
                        string moneyToPut = Console.ReadLine();
                        if (moneyToPut == "стоп") break;

                        Console.WriteLine("Введіть номер картки отримувача: ");
                        string reciever = Console.ReadLine();
                        if (reciever == "стоп") break;

                        Console.WriteLine("Введіть пін: ");
                        string pinString = Console.ReadLine();
                        if (pinString == "стоп") break;

                        float money = float.Parse(moneyToPut, System.Globalization.CultureInfo.InvariantCulture);
                        int pin = int.Parse(pinString);
                        if (money > 0 && currentATM.currentAccount.pinChecker(pin) && bank.isCardExist(reciever))
                        {
                            currentATM.TransferOperation(money, pin, reciever);
                            Console.WriteLine("Операція завершена!) На балансі: " + currentATM.currentAccount.money.ToString() + " деняг!\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Помилка!!!");
                        }
                    }
                    break;
                case 7:
                    currentATM.currentAccount = null;
                    Console.WriteLine("Ви вийшли з аккаунту.");
                    break;
            }
        }
    }
}

public class Source
{
    public int Menu()
    {
        int number;

        Console.WriteLine("1. Переглянути баланс.");
        Console.WriteLine("2. Iсторiя транзацiй.");
        Console.WriteLine("3. Найближчий банкомат.");
        Console.WriteLine("4. Зняття готiвки.");
        Console.WriteLine("5. Зарахування коштiв.");
        Console.WriteLine("6. Транфер.");
        Console.WriteLine("7. Вихiд.");
        Console.Write("\nОберiть пункт меню: ");


        if (int.TryParse(Console.ReadLine(), out number) && number > 0 && number <= 7)
        {
            return number;
        }
        else
        {
            return 0;
        }
    }

    public void SetError()
    {
        Console.WriteLine("ERROR!!");
    }

    public void DriteAllTransactions(List<Transaction> transactions)
    {
        foreach (var transaction in transactions)
        {
            string info = "Тип " + transaction.type.ToString() + " Сума " + transaction.amount.ToString() + " Дата " + transaction.date + " Додаткова iнформацiя " + (transaction.type == TransactionType.Transfer ? "Вiдправник " +  transaction.cardNumber + "\nОтримувач " + transaction.cardNumber2 : "Номер аккаунта " + transaction.cardNumber);
            Console.WriteLine(info + "\n");
        }
    }
}


