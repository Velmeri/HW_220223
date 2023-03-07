using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_220223
{
    public class ATM
    {
        private CreditCard _card;

        public void InsertCard(CreditCard card)
        {
            _card = card;
        }

        public void RemoveCard()
        {
            _card = null;
        }

        public void EnterPIN(int pin)
        {
            if (_card == null)
            {
                Console.WriteLine("Please insert your credit card first");
                return;
            }

            if (pin == _card.PIN)
            {
                Console.WriteLine("PIN is correct");
            }
            else
            {
                Console.WriteLine("Incorrect PIN, please try again");
            }
        }

        public void CheckBalance()
        {
            if (_card == null)
            {
                Console.WriteLine("Please insert your credit card first");
                return;
            }

            Console.WriteLine($"Your current balance is {_card.Balance}");
        }

        public void WithdrawMoney(Money amount)
        {
            if (_card == null)
            {
                Console.WriteLine("Please insert your credit card first");
                return;
            }

            if (amount != _card.Balance)
            {
                Console.WriteLine("Cannot withdraw money in a different currency than the balance");
                return;
            }

            if (amount > _card.Balance)
            {
                Console.WriteLine("Insufficient funds");
                return;
            }

            _card.Balance -= amount;

            Console.WriteLine($"Successfully withdrew {amount} from your account");
            Console.WriteLine($"Your new balance is {_card.Balance}");
        }

        public void DepositMoney(Money amount)
        {
            if (_card == null)
            {
                Console.WriteLine("Please insert your credit card first");
                return;
            }

            if (amount != _card.Balance)
            {
                Console.WriteLine("Cannot deposit money in a different currency than the balance");
                return;
            }

            _card.Balance += amount;

            Console.WriteLine($"Successfully deposited {amount} to your account");
            Console.WriteLine($"Your new balance is {_card.Balance}");
        }
    }
}