using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Sportsmen
{
    interface IDoctor
    {
        bool Working{get; set;}
        void MovementTo(int x, int y);
    }
}
