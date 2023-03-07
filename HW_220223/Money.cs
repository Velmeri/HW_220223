using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_220223
{
    public abstract class Money
    {
        protected decimal value;
        protected decimal exchangeRate;

        public Money(decimal value, decimal exchangeRate)
        {
            this.value = value;
            this.exchangeRate = exchangeRate;
        }

        public abstract string GetCurrency();

        public decimal GetValue()
        {
            return value;
        }

        public decimal GetExchangeRate()
        {
            return exchangeRate;
        }

        public decimal ConvertTo(Money other)
        {
            if (this.GetCurrency() == other.GetCurrency())
            {
                return this.GetValue();
            }
            else if (this.GetCurrency() == "UAH" && other.GetCurrency() == "USD")
            {
                return this.GetValue() / this.GetExchangeRate();
            }
            else if (this.GetCurrency() == "USD" && other.GetCurrency() == "UAH")
            {
                return this.GetValue() * this.GetExchangeRate();
            }
            else
            {
                throw new Exception($"Unsupported currency conversion: {this.GetCurrency()} to {other.GetCurrency()}");
            }
        }

        public static Money operator +(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
                throw new ArgumentException("Cannot add money of different currencies");

            Money result = (Money)Activator.CreateInstance(a.GetType());
            result.value = a.value + b.value;
            result.value = a.value + b.value;
            return result;
        }

        public static Money operator -(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
                throw new ArgumentException("Cannot subtract money of different currencies");

            Money result = (Money)Activator.CreateInstance(a.GetType());
            result.value = a.value - b.value;
            return result;
        }

        public static Money operator *(Money a, decimal b)
        {
            Money result = (Money)Activator.CreateInstance(a.GetType());
            result.value = a.value * b;
            return result;
        }

        public static Money operator /(Money a, decimal b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide money by zero");

            Money result = (Money)Activator.CreateInstance(a.GetType());
            result.value = a.value / b;
            return result;
        }

        public static bool operator ==(Money a, Money b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            if (a.GetType() != b.GetType()) return false;
            return a.value == b.value;
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public static bool operator <(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
                throw new ArgumentException("Cannot compare money of different currencies");

            return a.value < b.value;
        }

        public static bool operator >(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
                throw new ArgumentException("Cannot compare money of different currencies");

            return a.value > b.value;
        }

        public static bool operator <=(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
                throw new ArgumentException("Cannot compare money of different currencies");

            return a.value <= b.value;
        }

        public static bool operator >=(Money a, Money b)
        {
            if (a.GetType() != b.GetType())
                throw new ArgumentException("Cannot compare money of different currencies");

            return a.value >= b.value;
        }
    }

    public class USD : Money
    {
        public USD(decimal value, decimal exchangeRate) : base(value, exchangeRate)
        {
        }

        public override string GetCurrency()
        {
            return "USD";
        }
    }

    public class UAH : Money
    {
        public UAH(decimal value, decimal exchangeRate) : base(value, exchangeRate)
        {
        }

        public override string GetCurrency()
        {
            return "UAH";
        }
    }
}
