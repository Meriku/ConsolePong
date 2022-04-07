using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePong
{
    public class Player
    {
        private int Score = 0;
        private int PlayerType;
        private int DifficultyLevel = 1; // 1 - Easy; 2 - Standard; 3 - Hard
        private Coordinate[] coordinates = new Coordinate[10];
        Random rnd = new Random();

        public Ball ball { private get; set; }
        
        public Player()
        {

        }
        public Player (string type)
        {
            if (type.ToLower().Equals("wasd"))
            {
                PlayerType = 1;          
                var index = 0;
                for (var i = -2; i < 3; i++)
                {                  
                    for (var j = 0; j < 2; j++)
                    {
                        coordinates[index] = new Coordinate(-40-j, i);
                        index++;
                    }                 
                }
            }
            if (type.ToLower().Equals("arrows"))
            {
                PlayerType = 2;
                var index = 0;
                for (var i = -2; i < 3; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        coordinates[index] = new Coordinate(41 + j, i);
                        index++;
                    }
                }
            }     
        }
        public Player(string type, int difflevel)
        {
            if (type.ToLower().Equals("computer"))
            {
                PlayerType = 3;
                DifficultyLevel = difflevel;
                var index = 0;
                for (var i = -2; i < 3; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        coordinates[index] = new Coordinate(41 + j, i);
                        index++;
                    }
                }               
            }
        }
        public void StartPlaying()
        {
            PlayGround.Draw(coordinates);

            if (PlayerType == 3)
            {
                PlayGround.Draw($"Score: {Score}", 94, 0);
                Thread thread = new Thread(new ThreadStart(AIMoving));
                thread.Start();
            }
            else if (PlayerType == 2)
            {
                PlayGround.Draw($"Score: {Score}", 94, 0);
                Thread thread = new Thread(new ThreadStart(Move));
                thread.Start();
            }
            else
            {
                PlayGround.Draw($"Score: {Score}", 2, 0);
                Thread thread = new Thread(new ThreadStart(Move));
                thread.Start();
            }
           
        }
        public void Move()
        {
            while (true)
            {
                ConsoleKeyInfo PressedKey = Console.ReadKey(true);

                PlayGround.Clear(coordinates);

                if (PressedKey.Key.Equals(ConsoleKey.W) && PlayerType == 1 && !IsNearUpBorded())
                {
                    coordinates.MoveUp();
                }
                if (PressedKey.Key.Equals(ConsoleKey.S) && PlayerType == 1 && !IsNearDownBorded())
                {
                    coordinates.MoveDown();
                }
                if (PressedKey.Key.Equals(ConsoleKey.UpArrow) && PlayerType == 2 && !IsNearUpBorded())
                {
                    coordinates.MoveUp();
                }
                if (PressedKey.Key.Equals(ConsoleKey.DownArrow) && PlayerType == 2 && !IsNearDownBorded())
                {
                    coordinates.MoveDown();
                }

                PlayGround.Draw(coordinates);
            }
        }
        public void AIMoving()
        {
            while (true)
            {
                if (ball.IsMovingRight())
                {
                    PlayGround.Clear(coordinates);

                    if (ball.GetCord().Y > coordinates[5].Y && !IsNearDownBorded())
                    {
                        coordinates.MoveDown();
                    }
                    if (ball.GetCord().Y < coordinates[5].Y && !IsNearUpBorded())
                    {
                        coordinates.MoveUp();
                    }

                    PlayGround.Draw(coordinates);
                }                     

                switch (DifficultyLevel)
                {
                    case 1:
                        Thread.Sleep(rnd.Next(150, 300));
                        break;
                    case 2:
                        Thread.Sleep(rnd.Next(100, 250));
                        break;
                    case 3:
                        Thread.Sleep(rnd.Next(50, 100));
                        break;
                }
                
            }    
        }
        public bool IsNearUpBorded()
        {
            foreach (var cord in coordinates)
            {
                if (cord.Y <= PlayGround.upstart)
                { // Верхняя граница
                    return true;
                }
            }
            return false;
        }
        public bool IsNearDownBorded()
        {
            foreach (var cord in coordinates)
            {
                if (cord.Y >= PlayGround.Height - PlayGround.upstart - 1)
                { // Нижняя граница
                    return true;
                }
            }
            return false;
        }
        public void ScoreUp()
        {
            Score++;

            if (PlayerType == 1)
            {
                PlayGround.Draw($"Score: {Score}", 2, 0);
            }
            else
            {
                if (Score < 10)
                {
                    PlayGround.Draw($"Score: {Score}", 94, 0);
                }
                else
                {
                    PlayGround.Draw($"Score: {Score}", 93, 0);
                }            
            }
        }
        public Coordinate[] GetCord()
        {
            return coordinates;
        }
    }
}
