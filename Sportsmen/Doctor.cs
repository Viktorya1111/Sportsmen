using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sportsmen
{
    class Doctor : IDoctor
    {
        public int startPointY { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Speed { get; set; }
        public bool Working { get; set; }
        public Sportsman sportsman {get; set;}
        public void Movement()
        {
            Y -= (int)(Speed * 10);
        }

        public void RunBack()
        {
            Y += (int)(Speed * 10);
        }
    }
}
