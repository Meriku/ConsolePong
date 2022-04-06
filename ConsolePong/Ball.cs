using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePong
{
    public class Ball
    {
        Coordinate[] coordinates = { new Coordinate(0,0), new Coordinate(-1,0) };
        Random rnd = new Random();
        Angle angle = new Angle();

        public void StartMoving()
        {
            angle.SetRndAngle();

            Thread thread = new Thread(new ThreadStart(Move));
            thread.Start();
        }

        private void Move()
        {
            while (true)
            {
                if (IsHorizontalBorderNear())
                {
                    angle.HorizontalMirror();
                }
                if (IsVerticalBorderNear())
                {
                    angle.VerticalMirror();
                }

                Clear();

                switch (angle.ToInt())
                {
                    case 45:
                        coordinates.MoveRightUp();
                        break;
                    case 135:
                        coordinates.MoveLeftUp();                   
                        break;
                    case 225:
                        coordinates.MoveLeftDown();
                        break;
                    case 315:
                        coordinates.MoveRightDown();
                        break;
                }

                Draw();
                Thread.Sleep(200);
            }
        }


        public void Draw()
        {
            //test
            Console.SetCursorPosition(0, 0);
            Console.Write($"[{coordinates[0].X}, {coordinates[0].Y}]");
            //test

            foreach (var cord in coordinates)
            {
                Console.SetCursorPosition(cord.X, cord.Y);
                Console.Write("█");
            }         
        }

        public void Clear()
        {
            foreach (var cord in coordinates)
            {
                Console.SetCursorPosition(cord.X, cord.Y);
                Console.Write(" ");
            }
        }

        public bool IsHorizontalBorderNear()
        {
            foreach (var cord in coordinates)
            {
                if (cord.Y <= PlayGround.upstart)
                { // Верхняя граница
                    return true;
                }
                if (cord.Y >= PlayGround.Height - PlayGround.upstart-1)
                { // Нижняя граница
                    return true;
                }
            }          
            return false;
        }


        public bool IsVerticalBorderNear()
        {
            foreach (var cord in coordinates)
            {
                if (cord.X <= PlayGround.leftstart+2)
                { // Граница слева
                    return true;
                }
                if (cord.X >= PlayGround.Width - PlayGround.leftstart)
                { // Граница справа
                    return true;
                }
            }
            return false;
        }
    }
}
