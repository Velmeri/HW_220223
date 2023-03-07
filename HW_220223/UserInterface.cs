using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW_220223
{
    public class UserInterface
    {
        private readonly ILocalization _localization;
        private readonly ATM _atm;
        private int _selectedOption;
        private string _culture;

        public UserInterface(ILocalization localization, ATM atm, string culture)
        {
            _localization = localization;
            _atm = atm;
            _selectedOption = 0;
            _culture = culture;
        }

        static private int Screen (ConsoleKeyInfo keyInfo, string[] options)
        {
            int choice = 0;
            while (true)
            {
                for (int i = 0; i < options.Length; i++)
                {
                    Console.Write('\t');
                    if (choice == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(_localization.GetText(options[i], _culture));
                        Console.ResetColor();
                    }
                    else Console.WriteLine(_localization.GetText(options[i], _culture));
                }
                Console.WriteLine(
                "\n\t" +
                _localization.GetText("W", _culture) + "\n\t" +
                _localization.GetText("S", _culture) + " \n\t" +
                _localization.GetText("ENTER", _culture));

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        choice--;
                        if (choice < 0) choice = 0;
                        break;
                    case ConsoleKey.S:
                        if (choice > options.Length - 2) choice = options.Length - 2;
                        choice++;
                        break;
                    case ConsoleKey.Enter:
                        return choice;
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        public void Run()
        {
            ConsoleKeyInfo keyInfo;
            Console.TreatControlCAsInput = true;
            string[] options =
            {
                "Choice of localization",
                "Create a credit card",
                "Insert card",
                "Check account",
                "Withdraw money",
                "Top up the account"
            };
            int choice = 0;

            while (true)
            {
                Console.WriteLine();
                for (int i = 0; i < options.Length; i++)
                {
                    Console.Write('\t');
                    if (choice == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(_localization.GetText(options[i], _culture));
                        Console.ResetColor();
                    }
                    else Console.WriteLine(_localization.GetText(options[i], _culture));
                }
                Console.WriteLine(
                    "\n\t" + 
                    _localization.GetText("W", _culture) + "\n\t" + 
                    _localization.GetText("S", _culture) + " \n\t" +
                    _localization.GetText("ENTER", _culture));

                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        choice--;
                        if (choice < 0) choice = 0;
                        break;
                    case ConsoleKey.S:
                        if (choice > options.Length - 2) choice = options.Length - 2;
                        choice++;
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine("EEEE");
                        Console.ReadKey(true);
                        switch (choice)
                        {
                            case 0:
                                string[] localizations = { "en-US", "ru-RU", "uk-UK" };
                                Screen(keyInfo, localizations);
                                break;
                        }
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}
