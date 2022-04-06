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

            PlayGround.DrawBorders();

            var ball = new Ball();

            ball.StartMoving();







            Console.ReadLine();


        }
    }
}
