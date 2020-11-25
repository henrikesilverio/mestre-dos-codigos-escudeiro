using MDC.Escudeiro.Domain.Models;
using System;
using System.Linq;
using System.Text;

namespace MDC.Escudeiro
{
    public class Program
    {
        private static int _numberOptions = 3;
        private static int _selectedOption = 0;
        private static ConsoleColor _selectedOptionColor = ConsoleColor.Cyan;
        private static CommandNode _currentCommandNode;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WindowWidth = 150;
            Console.WindowHeight = 30;
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight);

            _currentCommandNode = BuildTreeCommand();

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

        private static CommandNode BuildTreeCommand()
        {
            var node = new CommandNode
            {
                Action = ActionInitial,
                Parent = null,
                Title = Texts.Saudacoes
            };

            node.Branches = new CommandNode[]
            {
                BuildCommandNodeQuestion(node),
                BuildCommandNodeConsoleExercise(node)
            };

            return node;
        }

        private static CommandNode BuildCommandNodeQuestion(CommandNode parent)
        {
            var node = new CommandNode
            {
                Action = ActionTheoreticalQuestions,
                Branches = new CommandNode[4],
                Parent = parent,
                Title = Texts.IntroducaoTeorica,
                Order = 0
            };

            for (int i = 0; i < 4; i++)
            {
                var branch = new CommandNode
                {
                    Action = ActionAnswers,
                    Parent = node,
                    Order = i
                };

                branch.Title = Texts.ResourceManager.GetString($"0{branch.Order}");
                node.Branches[i] = branch;
            }

            return node;
        }

        private static CommandNode BuildCommandNodeConsoleExercise(CommandNode parent)
        {
            var node = new CommandNode
            {
                Action = ActionConsolePracticalQuestions,
                Branches = new CommandNode[9],
                Parent = parent,
                Title = Texts.IntroducaoConsole,
                Order = 1
            };

            for (int i = 0; i < 9; i++)
            {
                var branch = new CommandNode
                {
                    Action = ActionOptionPracticalQuestions,
                    Parent = node,
                    Order = i
                };

                branch.Title = Texts.ResourceManager.GetString($"1{branch.Order}");
                node.Branches[i] = branch;
                branch.Branches = BuildCommandNodeConsoleExerciseAction(node.Branches[i]);
            }

            return node;
        }

        private static CommandNode[] BuildCommandNodeConsoleExerciseAction(CommandNode parent)
        {
            var exercise = ExerciseFactory.Manufacture(parent.Order);
            return exercise.GetBranches(parent);
        }

        private static void PrintScreen()
        {
            var footerText = Texts.MenuIntroducao;
            var option = _currentCommandNode.Order + 1;
            var title = string.Format(_currentCommandNode.Title, option);

            DividerLine();
            WriteLineWithColor(TextCenter(title), ConsoleColor.Cyan);
            DividerLine();

            if (_currentCommandNode.Branches != null && _currentCommandNode.Branches.Any())
            {
                WriteWithFixedSide(Texts.IntroducaoOpcoes, ConsoleColor.White);
            }

            _currentCommandNode.Action();

            if (_currentCommandNode.Branches == null)
            {
                footerText = Texts.MenuIntroducaoVoltar;
            }
            else if (_currentCommandNode.Parent != null)
            {
                footerText = Texts.MenuIntroducaoEntrarVoltar;
            }

            DividerLine();
            WriteLineWithColor(TextCenter(footerText), ConsoleColor.Cyan);
            DividerLine();
        }

        private static void ActionInitial()
        {
            var optionsReference = new[] { "OpcaoUm", "OpcaoDois", "OpcaoTres" };

            for (int i = 0; i < 3; i++)
            {
                var text = string.Format(Texts.ResourceManager.GetString(optionsReference[i]), SetOption(i));
                WriteWithFixedSide(text, _selectedOptionColor);
            }
        }

        private static void ActionAnswers()
        {
            var answer = Texts.ResourceManager.GetString($"0{_currentCommandNode.Order}0");

            WriteWithFixedSideForAnswer(answer);
        }

        private static void ActionTheoreticalQuestions()
        {
            _numberOptions = 4;

            for (int i = 0; i < 4; i++)
            {
                WriteWithFixedSide(string.Format(Texts.ResourceManager.GetString($"0{i}"), SetOption(i)), _selectedOptionColor);
            }
        }

        private static void ActionConsolePracticalQuestions()
        {
            _numberOptions = 9;

            for (int i = 0; i < 9; i++)
            {
                WriteWithFixedSide(string.Format(Texts.ResourceManager.GetString($"1{i}"), SetOption(i)), _selectedOptionColor);
            }
        }

        private static void ActionOptionPracticalQuestions()
        {
            var branches = _currentCommandNode.Branches;
            _numberOptions = branches.Length;

            for (int i = 0; i < _numberOptions; i++)
            {
                WriteWithFixedSide(string.Format(branches[i].Title, SetOption(i)), _selectedOptionColor);
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

        private static void WriteWithFixedSideForAnswer(string text)
        {
            var words = text.Split(" ");
            var line = string.Empty;

            for (var i = 0; i < words.Length; i++)
            {
                var lengthLine = line.Length + words[i].Length + 4;
                if (lengthLine <= Console.WindowWidth)
                {
                    line += $" {words[i]}";
                }
                if (lengthLine > Console.WindowWidth)
                {
                    WriteWithColor("||", ConsoleColor.White);
                    WriteWithColor(line, ConsoleColor.DarkGray);
                    WriteWithColor($"{new string(' ', Console.WindowWidth - line.Length - 4)}||", ConsoleColor.White);

                    line = string.Empty;
                    i--;
                }
                if (i + 1 == words.Length)
                {
                    WriteWithColor("||", ConsoleColor.White);
                    WriteWithColor(line, ConsoleColor.DarkGray);
                    WriteWithColor($"{new string(' ', Console.WindowWidth - line.Length - 4)}||", ConsoleColor.White);
                }
            }

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