using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    internal class MainMenu
    {
        public static int AskAboutOpponent()
        {
            PlayGround.DrawBorders();

            PlayGround.Draw("Welcome to PingPongGame 2022!", PlayGround.Width / 2 - 14, 6);
            PlayGround.Draw("Choose your opponent:", PlayGround.Width / 2 - 14, 8);
            PlayGround.Draw("1 - Another Player", PlayGround.Width / 2 - 14, 10);
            PlayGround.Draw("2 - Computer", PlayGround.Width / 2 - 14, 11);
            Console.SetCursorPosition(PlayGround.Width / 2 - 14, 13);

            int answer;
            while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 2)
            {
                Console.SetCursorPosition(PlayGround.Width / 2 - 14, 12);
                Console.WriteLine("Please enter a valid answer - 1, 2");
                Console.SetCursorPosition(PlayGround.Width / 2 - 14, 13);
                Console.Write("\t\t\t");
                Console.SetCursorPosition(PlayGround.Width / 2 - 14, 13);
            }

            if (answer == 1)
            {
                Console.Clear();
                PlayGround.DrawBorders();

                PlayGround.Draw("Welcome to PingPongGame 2022!", PlayGround.Width / 2 - 14, 6);
                PlayGround.Draw("You chose to play with another player", PlayGround.Width / 2 - 14, 8);
                PlayGround.Draw("Player 1 control - WASD keys", PlayGround.Width / 2 - 14, 9);
                PlayGround.Draw("Player 2 control - Arrow keys", PlayGround.Width / 2 - 14, 10);

            }

            return answer;

        }

        public static int AskAboutDifficulty()
        {
            // First Window
            Console.Clear();
            PlayGround.DrawBorders();

            PlayGround.Draw("Welcome to PingPongGame 2022!", PlayGround.Width / 2 - 14, 6);
            PlayGround.Draw("Choose difficulty level:", PlayGround.Width / 2 - 14, 8);
            Console.ForegroundColor = ConsoleColor.Green;
            PlayGround.Draw("1 - Easy", PlayGround.Width / 2 - 14, 10);
            Console.ForegroundColor = ConsoleColor.White;
            PlayGround.Draw("2 - Standard", PlayGround.Width / 2 - 14, 11);
            Console.ForegroundColor = ConsoleColor.Red;
            PlayGround.Draw("3 - Hard", PlayGround.Width / 2 - 14, 12);

            Console.ForegroundColor = ConsoleColor.White;

            int level;
            Console.SetCursorPosition(PlayGround.Width / 2 - 14, 14);
            while (!int.TryParse(Console.ReadLine(), out level) || level < 1 || level > 3)
            {
                Console.SetCursorPosition(PlayGround.Width / 2 - 14, 13);
                Console.WriteLine("Please enter a valid answer - 1, 2, 3");
                Console.SetCursorPosition(PlayGround.Width / 2 - 14, 14);
                Console.Write("\t\t\t");
                Console.SetCursorPosition(PlayGround.Width / 2 - 14, 14);
            }

            // Second Window
            Console.Clear();
            PlayGround.DrawBorders();

            PlayGround.Draw("Welcome to PingPongGame 2022!", PlayGround.Width / 2 - 14, 6);
            PlayGround.Draw("You choose ", PlayGround.Width / 2 - 14, 8);

            switch (level)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Easy");
                    break;
                case 2:
                    Console.Write("Standard");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Hard");
                    break;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" level");

            return level;
        }

    }
}
