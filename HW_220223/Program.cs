using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static HW_220223.Program;

namespace HW_220223
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine(CultureInfo.CurrentCulture);

            Dictionary<string, Dictionary<string, string>> localizations = new Dictionary<string, Dictionary<string, string>>
            {
                { "en-US", new Dictionary<string, string>
                    {
                    { "Choice of localization", "Choice of localization" },
                    { "Create a credit card", "Create a credit card" },
                    { "Credit card number request", "Please enter your credit card number" },
                    { "PIN code request", "Enter the pin code from your card" },
                    { "W", "W -> UP" },
                    { "S", "S -> DOWN" },
                    { "ENTER", "ENTER -> ENTER" }
                    }
                },
                { "ru-RU", new Dictionary<string, string>
                    {
                    { "Choice of localization", "Выбор локализации" },
                    { "Create a credit card", "Создать кредитную карту" },
                    { "Number request", "Пожалуйста, введите номер вашей кредитной карты" },
                    { "PIN code request", "Введите пин код от вашей карты" },
                    { "W", "W -> ВВЕРХ" },
                    { "S", "S -> ВНИЗ" },
                    { "ENTER", "ENTER -> ВВОД" }
                    }
                },
                { "uk-UA", new Dictionary<string, string>
                    {
                    { "Choice of localization", "Вибір локалізації" },
                    { "Create a credit card", "Створіти кредитну картку" },
                    { "Number request", "Будь ласка, введіть номер вашої кредитної картки" },
                    { "PIN code request", "Введіть пін код карти" },
                    { "W", "W -> ВВЕРХ" },
                    { "S", "S -> ВНИЗ" },
                    { "ENTER", "ENTER -> ВВЕДЕННЯ" }
                    }
                }
            };
            Console.WriteLine(localizations["en-US"]["PIN code request"]);
            Console.WriteLine(localizations["ru-RU"]["PIN code request"]);

            Localization ATMLocalization = new Localization(localizations);

            ATM atm = new ATM();

            UserInterface UI = new UserInterface(ATMLocalization, atm, "uk-UA");

            UI.Run();

            Console.ReadKey();
        }
    }
}
