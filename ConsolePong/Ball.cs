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
        Angle angle = new Angle();

        Player player1;
        Player player2;

        public Ball (Player pl1, Player pl2)
        {
            player1 = pl1;
            player2 = pl2;
        }

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
                    PlayGround.Clear(coordinates);
                    coordinates[0] = new Coordinate(0, 0);
                    coordinates[1] = new Coordinate(-1, 0);
                }              
                if (IsLeftPlayerNear() || IsRightPlayerNear())
                {
                    angle.VerticalMirror();
                }

                PlayGround.Clear(coordinates);

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

                PlayGround.Draw(coordinates);

                Thread.Sleep(200);
            }
        }

        private bool IsHorizontalBorderNear()
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

        private bool IsVerticalBorderNear()
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

        private bool IsLeftPlayerNear()
        {
            if (coordinates[0].X == 13)
            {
                foreach (var cord in coordinates)
                {
                    var playercord = player1.GetCord();

                    foreach (var plcord in playercord)
                    {
                        if (cord.X - 1 == plcord.X && cord.Y == plcord.Y)
                        {
                            return true;
                        }
                    }

                }
            }
     
            return false;
        }

        private bool IsRightPlayerNear()
        {
            if (coordinates[0].X == 91)
            {
                foreach (var cord in coordinates)
                {
                    var playercord = player2.GetCord();

                    foreach (var plcord in playercord)
                    {
                        if (cord.X + 1 == plcord.X && cord.Y == plcord.Y)
                        {
                            return true;
                        }
                    }

                }
            }

            return false;
        }

        public bool IsMovingRight()
        {
            if (angle.ToInt() == 45 || angle.ToInt() == 315)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Coordinate GetCord()
        {
            return coordinates[0];
        }
    }
}
