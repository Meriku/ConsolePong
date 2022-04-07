using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePong
{
    public class PlayGround
    {
        
        public static bool IsDrawing = false;

        public const int Width = 102;
        public const int Height = 28;

        public const int leftstart = 3;
        public const int upstart = 2;

        public static void DrawBorders()
        {
            for (var i = 2; i < Height; i++)
            {
                for (var j = 2; j < Width; j++)
                {
                    if (j == leftstart-1 || j == leftstart || j == Width-2 || j == Width-1 || i == upstart || i == Height-1)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write("█");
                    }      
                }
            }
        }

        public static void Draw(string text, int cordx, int cordy)
        {
            while (IsDrawing)
            {
                Thread.Sleep(1);
            }

            IsDrawing = true;

            Console.SetCursorPosition(cordx, cordy);
            Console.Write(text);

            IsDrawing = false;
        }

        public static void Draw(Coordinate[] coordinates)
        {
            while (IsDrawing)
            {
                Thread.Sleep(1);
            }

            IsDrawing = true;

            foreach (var cord in coordinates)
            {
                Console.SetCursorPosition(cord.X, cord.Y);
                Console.Write("█");
            }

            IsDrawing = false;

        }
        public static void Clear(Coordinate[] coordinates)
        {
            while (IsDrawing)
            {
                Thread.Sleep(1);
            }

            IsDrawing = true;

            foreach (var cord in coordinates)
            {
                Console.SetCursorPosition(cord.X, cord.Y);
                Console.Write(" ");
            }

            IsDrawing = false;

        }

    }
}
