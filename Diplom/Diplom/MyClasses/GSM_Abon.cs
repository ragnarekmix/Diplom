using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom.MyClasses
{
    class GSM_Abon : Point
    {
        public GSM_Abon(int y, int x)
            : base(y, x)
        {
            Orphan = true;
            BadParent = new List<GSM_Base>();
        }
        public static Double P { get; set; }  // Ват
        public static Double G { get; set; }  // дБ
        public static Double Lf { get; set; } // дБ
        public Boolean Orphan { get; set; }
        public double Carier { get; set; }    // дБ
        public GSM_Base Parent { get; set; } // Родительская станция
        public List<GSM_Base> BadParent { get; set; } // Родительская станция, на которой абонент был задавлен помехами от CDMA



        public void FindParent(List<GSM_Base> bases)
        {
            if (BadParent.Count != bases.Count)
            {
                Random rand = new Random();
                do
                {
                    Parent = bases[rand.Next(0, bases.Count)];
                } while (BadParent.Contains(Parent));

                foreach (GSM_Base gsmBase in bases)
                {
                    if (Distance((Point)this, (Point)gsmBase) < Distance((Point)this, (Point)Parent) && BadParent.Contains(gsmBase) != true)
                    {
                        Parent = gsmBase;
                    }
                }
            }
        }

        public void SetCarier()
        {
            double p = ToDB(GSM_Abon.P);
            double l = (92.5 + 20*Math.Log10(GSM_Base.Fdl/1000*Distance((Point) this, (Point) this.Parent)/1000));
            this.Carier = p  + GSM_Abon.G - GSM_Abon.Lf - l - GSM_Base.Lf + GSM_Base.G;
        }

        public void TryToConnect()
        {
            double C = this.Carier;
            double Isum = this.Parent.Isum;
            double N = ToDB(Point.N) + 30;
            double SIN = C - Isum - N;
            if (SIN <= 9)
            {
                this.Orphan = false; // Подключение
            }
            else
            {
                this.BadParent.Add(this.Parent); // не удалось подключиться, добавления базовой в список плохих базовых
            }
        }
    }
}
