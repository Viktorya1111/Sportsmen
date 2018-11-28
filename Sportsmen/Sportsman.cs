using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;




namespace Sportsmen
{
    public delegate void OnInjury(Sportsman sportsmen);
    public class Sportsman
    {
        public event OnInjury GetInjury;
        public int Num { get; set; }
        public int Place { get; set; }
        public bool Injury { get; set; }
        public double InjuryRate { get; set; }
        public double Speed { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


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
                GetInjury(this);
            }
        }
    }
}
