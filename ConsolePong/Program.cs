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
            //TODO: Score; difficulty levels; choosing opponents (another player or computer);

            Console.SetWindowSize(PlayGround.Width, PlayGround.Height);
            Console.SetBufferSize(PlayGround.Width, PlayGround.Height);
            Console.CursorVisible = false;

            PlayGround.DrawBorders();       

            var player1 = new Player("WASD");

            var player2 = new Player("Arrows");

            var player3 = new Player("Computer");

            var ball = new Ball(player1, player3);

            player3.ball = ball;

            ball.StartMoving();
            player1.StartPlaying();
            player3.StartPlaying();

        }
    }
}
