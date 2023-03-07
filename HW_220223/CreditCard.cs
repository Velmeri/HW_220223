using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_220223
{
    public class CreditCard
    {
        public string Number { get; }
        public int PIN { get; }
        public DateTime ExpiryDate { get; }
        public int CVC { get; }
        public Money Balance { get; set; }

        public CreditCard(string number, int pin, DateTime expiryDate, int cvc, Money balance)
        {
            Number = number;
            PIN = pin;
            ExpiryDate = expiryDate;
            CVC = cvc;
            Balance = balance;
        }
    }
}
