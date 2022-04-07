using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    public static class Helper
    {
        public static Coordinate[] MoveUp(this Coordinate[] coordinates)
        {
            foreach (var cord in coordinates)
            {
                cord.Y -= 1;
            }

            return coordinates;
        }

        public static Coordinate[] MoveDown(this Coordinate[] coordinates)
        {
            foreach (var cord in coordinates)
            {
                cord.Y += 1;
            }

            return coordinates;
        }

        public static Coordinate[] MoveRightUp(this Coordinate[] coordinates)
        {
            foreach (var cord in coordinates)
            {
                cord.X += 2;
                cord.Y -= 1;
            }

            return coordinates;
        }

        public static Coordinate[] MoveRightDown(this Coordinate[] coordinates)
        {
            foreach (var cord in coordinates)
            {
                cord.X += 2;
                cord.Y += 1;
            }

            return coordinates;
        }

        public static Coordinate[] MoveLeftUp(this Coordinate[] coordinates)
        {
            foreach (var cord in coordinates)
            {
                cord.X -= 2;
                cord.Y -= 1;
            }

            return coordinates;
        }

        public static Coordinate[] MoveLeftDown(this Coordinate[] coordinates)
        {
            foreach (var cord in coordinates)
            {
                cord.X -= 2;
                cord.Y += 1;
            }

            return coordinates;
        }



    }
}
