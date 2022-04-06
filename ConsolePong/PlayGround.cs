using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    public class PlayGround
    {
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
    }
}
