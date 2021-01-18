using MDC.Escudeiro.Domain.Interfaces;
using System;

namespace MDC.Escudeiro
{
    public class ScreenCommandConsole : IScreenCommand
    {
        public string MarkCharacter { get; } = "*";

        public string InputValue(string text)
        {
            WriteWithColor("||", ConsoleColor.White);

            var format = $" {text}";

            WriteWithColor(format, ConsoleColor.DarkGray);

            var value = Console.ReadLine();

            format = $"{format}{value}";

            var cursorLeft = format.Length + value.Length + 2;
            var cursorTop = Console.CursorTop - 1;
            Console.SetCursorPosition(cursorLeft, cursorTop);

            var offset = value.Length + 4;

            WriteWithColor($"{new string(' ', Console.WindowWidth - format.Length - offset)}||", ConsoleColor.White);
            Console.ResetColor();

            return value;
        }

        public void PrintError(string text)
        {
            WriteWithFixedSide(text, ConsoleColor.DarkRed);
        }

        public void PrintInfo(string text)
        {
            WriteWithFixedSide(text, ConsoleColor.DarkGray);
        }

        public void PrintOption(string text, string markCharacter)
        {
            var consoleColor = MarkCharacter == markCharacter ? ConsoleColor.Cyan : ConsoleColor.DarkGray;
            WriteWithFixedSide(string.Format(text, markCharacter), consoleColor);
        }

        public void PrintResult(string text)
        {
            WriteWithFixedSide(text, ConsoleColor.Cyan);
        }

        public void PrintBigText(string text)
        {
            WriteWithFixedSideForBigText(text);
        }

        private static void WriteWithFixedSide(string text, ConsoleColor consoleColor)
        {
            WriteWithColor("||", ConsoleColor.White);

            var format = $" {text}";

            WriteWithColor(format, consoleColor);
            WriteWithColor($"{new string(' ', Console.WindowWidth - format.Length - 4)}||", ConsoleColor.White);
            Console.ResetColor();
        }

        private static void WriteWithColor(string text, ConsoleColor consoleColor)
        {
            ExecuteActionWriteWithColor(() => Console.Write(text), consoleColor);
        }

        private static void ExecuteActionWriteWithColor(Action write, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            write();
            Console.ResetColor();
        }

        private static void WriteWithFixedSideForBigText(string text)
        {
            var words = text.Split(" ");
            var line = string.Empty;

            for (var i = 0; i < words.Length; i++)
            {
                var lengthLine = line.Length + words[i].Length + 8;
                if (lengthLine <= Console.WindowWidth)
                {
                    line += $" {words[i]}";
                }
                if (lengthLine > Console.WindowWidth)
                {
                    WriteWithColor("||", ConsoleColor.White);
                    WriteWithColor(line, ConsoleColor.Cyan);
                    WriteWithColor($"{new string(' ', Console.WindowWidth - line.Length - 4)}||", ConsoleColor.White);

                    line = string.Empty;
                    i--;
                }
                if (i + 1 == words.Length)
                {
                    WriteWithColor("||", ConsoleColor.White);
                    WriteWithColor(line, ConsoleColor.Cyan);
                    WriteWithColor($"{new string(' ', Console.WindowWidth - line.Length - 4)}||", ConsoleColor.White);
                }
            }

            Console.ResetColor();
        }
    }
}