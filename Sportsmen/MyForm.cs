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
        object place = new object();
        bool mov = false;
        List<Sportsman> s = new List<Sportsman>();
        List<Doctor> d = new List<Doctor>();
        List<Thread> t = new List<Thread>();
        Graphics g;
        Competition c;

        public MyForm()
        {
            InitializeComponent();
            p1.X = 5;
            p1.Y = 5;
            p2.X = 400;
            p2.Y = 5;
            InputStart();
            j = 0;
            g = CreateGraphics();
            c = new Competition(p1, p2);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            int[] num = new int[i];
            for (; j < s.Count; j++)
            {
                Thread t1 = new Thread(new ParameterizedThreadStart(Movements));
                s[j].GetInjury += SpawnDoctor;
                t.Add(t1);
                t[j].Start(s[j]);
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
        }

        private void MyForm_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black);
            g.DrawLine(blackPen, p1, p2);
            foreach (Sportsman spt in s)
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
            d.ForEach(doctor =>
            {
                if (doctor.Working)
                    g.FillEllipse(Brushes.Red, doctor.X, doctor.Y, 15, 15);
            });            
        }

        void SpawnDoctor(Sportsman sportsman)
        {
            Doctor doctor = new Doctor();
            doctor.Speed = 0.3f;
            doctor.X = sportsman.X;
            doctor.Y = 300;
            doctor.startPointY = 300;
            doctor.sportsman = sportsman;
            d.Add(doctor);
            Thread t1 = new Thread(new ParameterizedThreadStart(Doctor));
            t1.Start(doctor);
        }

        void Doctor(object doctor)
        {
            Doctor doc = (Doctor)doctor;
            doc.Working = true;
            while (doc.Y >= doc.sportsman.Y)
            {
                doc.Movement();
                Thread.Sleep(10);
                Invalidate();
            }
            lock (doc.sportsman)
            {
                Thread.Sleep(1500);
                doc.sportsman.Injury = false;
            }

            while (doc.Y <= doc.startPointY)
            {
                doc.RunBack();
                Thread.Sleep(10);
                Invalidate();
            }

            lock (d)
            {
                d.Remove(doc);
            }
        }

        void Movements(object obj)
        {
            Sportsman s = (Sportsman)obj;

            while (s.X <= p2.X)
            {
                if (!s.Injury)
                {
                    s.Movement();
                    Thread.Sleep(10);
                    Invalidate();
                }  
            }
            lock (place)
            {
                s.Place = n;
                n++;
            }
        }

        public void InputStart()
        {
            Sportsman s1 = new Sportsman();
            Sportsman s2 = new Sportsman();
            s1.Y = p1.Y;
            s1.X = p1.X;
            s1.InjuryRate = 0.003;
            s1.Place = 0;
            s1.Speed = 0.1;
            s1.Num = 1;
            s.Add(s1);
            s2.Y = p1.Y + 20;
            s2.X = p1.X;
            s2.InjuryRate = 0.023;
            s2.Place = 0;
            s2.Speed = 0.7;
            s2.Num = 2;
            s.Add(s2);
        }

        private void Input_Click(object sender, EventArgs e)
        {
            i++;
            Sportsman s1 = new Sportsman();
            s1.Y = p1.Y + (i-1) * 20;
            s1.X = p1.X;
            s1.InjuryRate = Convert.ToDouble(injury.Text);
            s1.Place = 0;
            s1.Speed = Convert.ToDouble(speed.Text);
            s1.Num = i;
            s.Add(s1);
        }
    }
}
