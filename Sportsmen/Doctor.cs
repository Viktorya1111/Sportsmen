using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sportsmen
{
    public class Doctor : IDoctor
    {
        public int startPointY { get; set; }

        public int startPointX { get; set; }
       
        public int X { get; set; }
        public int Y { get; set; }
        public double Speed { get; set; }
        public bool Working { get; set; }

        public Doctor(int startPointY, int X, int Y, double Speed)
        {
            this.startPointY = startPointY;
            this.X = X;
            this.Y = Y;
            this.Speed = Speed;
        }

        public void MovementTo(int x, int y)
        {
            X += Math.Sign(x - X) * (int)(Speed * 10);
            Y += Math.Sign(y - Y) * (int)(Speed * 10);
        }

    }
}
