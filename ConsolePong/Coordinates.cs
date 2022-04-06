using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    public class Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
        {
            X = PlayGround.Width / 2 + x;
            Y = PlayGround.Height / 2 + y;
        }

        public Coordinate Up()
        {
            Y -= 1;
            return this;
        }

        public Coordinate Down()
        {
            Y += 1;
            return this;
        }

        public Coordinate Right()
        {
            X += 2;
            return this;
        }

        public Coordinate Left()
        {
            X -= 2;
            return this;
        }

 
    }
}
