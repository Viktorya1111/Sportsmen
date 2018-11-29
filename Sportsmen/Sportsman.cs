using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;




namespace Sportsmen
{
    public class Sportsman
    {
        public int Num { get; set; }
        public int Place { get; set; }
        public bool Injury { get; set; }
        public double InjuryRate { get; set; }
        public double Speed { get; set; }
        public int X { get; set; }
        public int Y { get; set; }



        public Sportsman(int num, int place, bool injury, double injuryRate, double speed, int x, int y)
        {
            Num = num;
            Place = place;
            Injury = injury;
            InjuryRate = injuryRate;
            Speed = speed;
            X = x;
            Y = y;
        }

        public void Movement()
        {
            if (Injury)
                return;
            X += (int)(Speed*10);
            Random rnd = new Random();
            double k = rnd.NextDouble();
            if (k <= InjuryRate)
            {
                Injury = true;
            }
        }
    }
}
