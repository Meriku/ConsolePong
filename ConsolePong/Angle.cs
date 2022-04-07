using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePong
{
    public class Angle
    {
        private int angle;
        private int degrees; 

        public Angle()
        {
            angle = 0;
            degrees = 0;
        }
        public void SetRndAngle()
        {
            var rnd = new Random();

            degrees = rnd.Next(0, 361);

            if (degrees < 90)
            {
                angle = 45;
            }
            if (degrees < 180 && degrees >= 90)
            {
                angle = 135;
            }
            if (degrees < 270 && degrees >= 180)
            {
                angle = 225;
            }
            if (degrees < 360 && degrees >= 270)
            {
                angle = 315;
            }
        }
        public void HorizontalMirror()
        {
            switch (angle)
            {
                case 45:
                    angle = 315;
                    break;
                case 135:
                    angle = 225;
                    break;
                case 225:
                    angle = 135;
                    break;
                case 315:
                    angle = 45;
                    break;
            }
        }   
        public void VerticalMirror()
        {
            switch (angle)
            {
                case 45:
                    angle = 135;
                    break;
                case 135:
                    angle = 45;
                    break;
                case 225:
                    angle = 315;
                    break;
                case 315:
                    angle = 225;
                    break;
            }
        }
        public int ToInt()
        {
            return angle;
        }
    }
}
