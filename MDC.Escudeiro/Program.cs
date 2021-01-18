using MDC.Escudeiro.Domain.Models;
using MDC.Escudeiro.Exercicio.Builders;
using System;
using System.Linq;
using System.Text;

namespace MDC.Escudeiro
{
    public class Program
    {
        private static int _numberOptions;
        private static int _selectedOption = 0;
        private static ConsoleColor _selectedOptionColor = ConsoleColor.Cyan;
        private static CommandNode _currentCommandNode;
        private static readonly ScreenCommandConsole _screenCommand = new ScreenCommandConsole();

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WindowWidth = 150;
            Console.WindowHeight = 30;
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);

            _currentCommandNode = new ExerciseTreeBuilder(_screenCommand).Build();

            PrintScreen();

            var key = Console.ReadKey().Key;
            while (key != ConsoleKey.Escape)
            {
                ExecuteCommand(key);
                key = Console.ReadKey().Key;
            }
        }

        private static void ExecuteCommand(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow && _currentCommandNode.Branches != null)
            {
                SelectOption(ConsoleKey.UpArrow);

                Console.Clear();
                PrintScreen();
            }
            else if (key == ConsoleKey.DownArrow && _currentCommandNode.Branches != null)
            {
                SelectOption(ConsoleKey.DownArrow);

                Console.Clear();
                PrintScreen();
            }
            else if (key == ConsoleKey.Backspace && _currentCommandNode.Parent != null)
            {
                _selectedOption = _currentCommandNode.Order;
                _currentCommandNode = _currentCommandNode.Parent;

                Console.Clear();
                PrintScreen();
            }
            else if (key == ConsoleKey.Enter && _currentCommandNode.Branches != null)
            {
                _currentCommandNode = _currentCommandNode.Branches[_selectedOption];
                _selectedOption = 0;

                Console.Clear();
                PrintScreen();
            }
        }

        private static void PrintScreen()
        {
            var footerText = Text.MenuIntroducao;
            var option = _currentCommandNode.Order + 1;
            var title = string.Format(_currentCommandNode.Title, option);

            DividerLine();
            WriteLineWithColor(TextCenter(title), ConsoleColor.Cyan);
            DividerLine();

            if (_currentCommandNode.Branches != null && _currentCommandNode.Branches.Any())
            {
                WriteWithFixedSide(Text.IntroducaoOpcoes, ConsoleColor.White);
                ActionBranchTitle();
            }

            if (_currentCommandNode.Action != null)
            {
                _currentCommandNode.Action();
            }

            if (_currentCommandNode.Branches == null)
            {
                footerText = Text.MenuIntroducaoVoltar;
            }
            else if (_currentCommandNode.Parent != null)
            {
                footerText = Text.MenuIntroducaoEntrarVoltar;
            }

            DividerLine();
            WriteLineWithColor(TextCenter(footerText), ConsoleColor.Cyan);
            DividerLine();
        }

        private static void ActionBranchTitle()
        {
            var branches = _currentCommandNode.Branches;
            _numberOptions = branches.Length;

            foreach (var branch in branches)
            {
                WriteWithFixedSide(string.Format(branch.Title, SetOption(branch.Order)), _selectedOptionColor);
            }
        }

        private static string SetOption(int option)
        {
            if (_selectedOption % _numberOptions == option)
            {
                _selectedOptionColor = ConsoleColor.Cyan;
                return "*";
            }

            _selectedOptionColor = ConsoleColor.DarkGray;
            return " ";
        }

        private static void SelectOption(ConsoleKey consoleKey)
        {
            if (consoleKey == ConsoleKey.UpArrow && _selectedOption > 0)
            {
                _selectedOption--;
            }
            if (consoleKey == ConsoleKey.DownArrow && _selectedOption < _numberOptions - 1)
            {
                _selectedOption++;
            }
        }

        private static string TextCenter(string text)
        {
            var aligned = $"{(Console.WindowWidth / 2) + (text.Length / 2)}";
            return string.Format("{0," + aligned + "}", text);
        }

        private static void WriteWithFixedSide(string text, ConsoleColor textColor = ConsoleColor.DarkGray)
        {
            WriteWithColor("||", ConsoleColor.White);

            var format = $" {text}";

            WriteWithColor(format, textColor);
            WriteWithColor($"{new string(' ', Console.WindowWidth - format.Length - 4)}||", ConsoleColor.White);
            Console.ResetColor();
        }

        private static void WriteWithColor(string text, ConsoleColor consoleColor)
        {
            ExecuteActionWriteWithColor(() => Console.Write(text), consoleColor);
        }

        private static void WriteLineWithColor(string text, ConsoleColor consoleColor)
        {
            ExecuteActionWriteWithColor(() => Console.WriteLine(text), consoleColor);
        }

        private static void ExecuteActionWriteWithColor(Action write, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            write();
            Console.ResetColor();
        }

        private static void DividerLine()
        {
            WriteWithColor(new string('=', Console.WindowWidth), ConsoleColor.White);
            Console.ResetColor();
        }
    }
}