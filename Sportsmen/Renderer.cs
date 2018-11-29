using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Sportsmen
{
    public class Renderer
    {
        public static void RenderCompetition(Graphics g, Competition c)
        {
            Pen blackPen = new Pen(Color.Black);
            g.DrawLine(blackPen, c.start, c.finish);
            foreach (Sportsman spt in c.Sportsmens)
            {
                g.FillEllipse(Brushes.Blue, spt.X, spt.Y, 15, 15);
                g.DrawString(Convert.ToString(spt.Num), new Font("Times New Roman", 20, FontStyle.Regular), new SolidBrush(Color.Black), spt.X + 5, spt.Y - 5);

                if (spt.Place != 0)
                {
                    if (spt.Place == 1)
                        g.FillEllipse(Brushes.Yellow, spt.X, spt.Y, 10, 10);
                    if (spt.Place == 2)
                        g.FillEllipse(Brushes.Silver, spt.X, spt.Y, 10, 10);
                    if (spt.Place == 3)
                        g.FillEllipse(Brushes.Brown, spt.X, spt.Y, 10, 10);

                }

            }

            if (c.doc.Working)
               g.FillEllipse(Brushes.Red, c.doc.X, c.doc.Y, 15, 15);

        }
    }
}
