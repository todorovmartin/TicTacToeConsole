using System;
using System.Text.RegularExpressions;

namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

            Board(arr);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int lastChoice = 0;
                if (i % 2 == 0) // 'x' or 'o'
                {
                    Console.WriteLine("Choose where to place X (1-9)");
                    int choice;
                    string input = Console.ReadLine();
                    bool success = Int32.TryParse(input, out choice);

                    if (!success || choice < 1 || choice > 9)
                    {
                        Console.WriteLine(Messages.wrongInput);
                        i--;
                        continue;
                    }

                    //int choice = Int32.Parse(Console.ReadLine());
                    if (arr[choice] == 'x' || arr[choice] == 'o')
                    {
                        Console.WriteLine(Messages.squareTaken);
                        i--;
                        continue;
                    }
                    arr[choice] = 'x';
                    lastChoice = choice;
                }
                else
                {
                    Console.WriteLine("Choose where to place O (1-9)");

                    int choice;
                    string input = Console.ReadLine();
                    bool success = Int32.TryParse(input, out choice);

                    if (!success || choice < 1 || choice > 9)
                    {
                        Console.WriteLine(Messages.wrongInput);
                        i--;
                        continue;
                    }

                    //int choice = Int32.Parse(Console.ReadLine());
                    if (arr[choice] == 'x' || arr[choice] == 'o')
                    {
                        Console.WriteLine(Messages.squareTaken);
                        i--;
                        continue;
                    }
                    arr[choice] = 'o';
                    lastChoice = choice;
                }                
                Board(arr);
                if (CheckForWinner(arr))
                {
                    Console.WriteLine(Messages.winner, arr[lastChoice]);
                    break;
                }
            }
            Console.WriteLine(Messages.draw);
        }

        private static void Board(char[] arr)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        private static bool CheckForWinner(char[] arr)
        {
            if (arr[1] == arr[2] && arr[2] == arr[3] && arr[3] != ' ') { return true; }
            if (arr[4] == arr[5] && arr[5] == arr[6] && arr[6] != ' ') { return true; }
            if (arr[7] == arr[8] && arr[8] == arr[9] && arr[9] != ' ') { return true; }

            if (arr[1] == arr[4] && arr[4] == arr[7] && arr[7] != ' ') { return true; }
            if (arr[2] == arr[5] && arr[5] == arr[8] && arr[8] != ' ') { return true; }
            if (arr[3] == arr[6] && arr[6] == arr[9] && arr[9] != ' ') { return true; }

            if (arr[1] == arr[5] && arr[5] == arr[9] && arr[9] != ' ') { return true; }
            if (arr[3] == arr[5] && arr[5] == arr[7] && arr[7] != ' ') { return true; }

            return false;

        }

        private static bool CheckIf1to9(string input)
        {
            Regex regex = new Regex("^[1-9]$");

            if (regex.IsMatch(input))
            {
                return true;
            }
            return false;
        }
    }
}
