using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    internal class Program
    {
        static void Main(string[] args)
        {    
            Console.SetWindowSize(PlayGround.Width, PlayGround.Height);
            Console.SetBufferSize(PlayGround.Width, PlayGround.Height);
            Console.CursorVisible = false;

            Player player1 = new Player("WASD");
            Player player2 = new Player();
            Ball ball = new Ball();

            int opponent = MainMenu.AskAboutOpponent();
            
            switch (opponent)
            {
                case 1:
                    player2 = new Player("Arrows");
                    ball = new Ball(player1, player2);
                    break;
                case 2:
                    int diffuculty = MainMenu.AskAboutDifficulty();
                    player2 = new Player("Computer", diffuculty);
                    ball = new Ball(player1, player2);
                    player2.ball = ball;
                    break;
            }

            PlayGround.Draw("Press any key to start the Game!", PlayGround.Width / 2 - 14, 12);
            Console.ReadKey();
            Console.Clear();

            PlayGround.DrawBorders();
            ball.StartMoving();
            player1.StartPlaying();
            player2.StartPlaying();

        }    
    }
}
