using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Sportsmen
{
    public partial class MyForm : Form
    {
        delegate void Message(Graphics g, Color color);
        Point p1, p2;
        int i = 2, j = 0, n = 1;
        Graphics g;
        Competition c;
        public MyForm()
        {
            InitializeComponent();
            p1.X = 5;
            p1.Y = 5;
            p2.X = 400;
            p2.Y = 5;
            j = 0;
            g = CreateGraphics();
            c = new Competition(p1, p2);
            c.doc1 = new Doctor(200, p1.X, 200, 0.1);
            c.doc2 = new Doctor(200, p1.X, 200, 0.1);
            InputStart();

        }

        private void Start_Click(object sender, EventArgs e)
        {
            c.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void MyForm_Paint(object sender, PaintEventArgs e)
        {
            Renderer.RenderCompetition(g, c);
        }


        public void InputStart()
        {
            Sportsman s1 = new Sportsman(1, 0, false, 0.003, 0.1, c.start.X, c.start.Y);
            Sportsman s2 = new Sportsman(2, 0, false, 0.023, 0.7, c.start.X, c.start.Y + 20);
            Sportsman s3 = new Sportsman(3, 0, false, 0.034, 0.8, c.start.X, c.start.Y + 40);
            Sportsman s4 = new Sportsman(4, 0, false, 0.009, 0.5, c.start.X, c.start.Y + 60);
            c.Sportsmens.Add(s1);
            c.Sportsmens.Add(s2);
            c.Sportsmens.Add(s3);
            c.Sportsmens.Add(s4);
        }

        private void Input_Click(object sender, EventArgs e)
        {
            int count = c.Sportsmens.Count;
            Sportsman s1 = new Sportsman(count + 1, 0, false, Convert.ToDouble(injury.Text), Convert.ToDouble(speed.Text), p1.X, p1.Y + (count) * 20);
            c.Sportsmens.Add(s1);
        }
    }
}
