using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace Sportsmen
{
    public class Competition
    {
        public Point start;
        public Point finish;
        object place = new object();

        public bool finishRace;

        private int currentPlace;
        private int CurrentPlace
        {
            get { return currentPlace; }
            set
            {
                if (value == Sportsmens.Count) finishRace = true;
                currentPlace = value;
            }
        }
        public List<Sportsman> Sportsmens { get; set; }
        public Doctor doc1;
        public Doctor doc2;

        public Competition(Point Start, Point Finish)
        {
            start = Start;
            finish = Finish;
            Sportsmens = new List<Sportsman>();
            currentPlace = 1;
        }

        public void Start()
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < Sportsmens.Count; i++)
            {
                Thread t1 = new Thread(new ParameterizedThreadStart(SportsmenMove));
                threads.Add(t1);
                threads[i].Start(Sportsmens[i]);
            }
            Thread doctor1 = new Thread(new ParameterizedThreadStart(DoctorWorking));
            Thread doctor2 = new Thread(new ParameterizedThreadStart(DoctorWorking));
            doctor1.Start(doc1);
            doctor2.Start(doc2);
        }

        private void SportsmenMove(object sportsman)
        {
            Sportsman s = (Sportsman)sportsman;

            while (s.X <= finish.X)
            {
                if (!s.Injury)
                {
                    s.Movement();
                    Thread.Sleep(10);
                }
            }
            lock (place)
            {
                s.Place = (int)currentPlace;
                currentPlace++;
            }
        }


        private void DoctorWorking(object docs)
        {
            Doctor doc = (Doctor)docs;
            while (!finishRace)
            {
                Sportsmens.ForEach(s =>
                {
                    if (s.Injury && Monitor.TryEnter(s))
                    {
                        lock (s)
                        {
                                doc.Working = true;
                                int x = Math.Abs(doc.X - s.X);
                                int y = Math.Abs(doc.Y - s.Y);

                                while (Math.Abs(doc.X - s.X) >= 0.5 || Math.Abs(doc.Y - s.Y) >= 0.5)
                                {
                                    doc.MovementTo(s.X, s.Y);
                                    Thread.Sleep(10);
                                }
                                Thread.Sleep(1500);
                                s.Injury = false;
                        }
                    }
                });
                if (doc.Y < doc.startPointY)
                {
                    doc.MovementTo(doc.startPointX, doc.startPointY);
                    Thread.Sleep(10);
                }
                else {
                    doc.Working = false;
                    Thread.Sleep(500);
                }
            }
        }
    }
}
