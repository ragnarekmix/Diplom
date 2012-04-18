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
            Count++;
            Number = Count;
        }
        public static Double P { get; set; }  // Ват
        public static Double G { get; set; }  // дБ
        public static Double Lf { get; set; } // дБ
        public Boolean Orphan { get; set; }
        public double Carier { get; set; }    // дБ
        public double CIN { get; set; } // S/(I+N)
        public GSM_Base Parent { get; set; } // Родительская станция
        public List<GSM_Base> BadParent { get; set; } // Родительская станция, на которой абонент был задавлен помехами от CDMA
        public int Number { get; set; } // Порядковый номер станции
        public static int Count { get; set; } // Счетчик созданных станций


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
                    if (Distance((Point)this, (Point)gsmBase) < Distance((Point)this, (Point)Parent) && !BadParent.Contains(gsmBase))
                    {
                        Parent = gsmBase;
                    }
                }
            }
        }

        public void SetCarier()
        {
            double p = ToDB(GSM_Abon.P);
            double l = (92.5 + 20 * Math.Log10(GSM_Base.Fdl / 1000 * Distance((Point)this, (Point)this.Parent) / 1000));
            this.Carier = p + GSM_Abon.G - GSM_Abon.Lf - l - GSM_Base.Lf + GSM_Base.G;
        }

        public void TryToConnect()
        {
            double C = this.Carier;
            double Cvt = ToVat(C) * Math.Pow(10, 9);
            double Isum = this.Parent.Isum;
            double Isumvt = ToVat(Isum) * Math.Pow(10, 9);
            double N = ToDB(Point.N) + 30;
            double Nvt = ToVat(N) * Math.Pow(10, 9);
            if (Isum == 0)
            {
                double CINvt = ToVat(C) / (ToVat(N));
                this.CIN = ToDB(ToVat(C) / (ToVat(N)));
            }
            else
            {
                double CINvt = ToVat(C) / (ToVat(Isum) + ToVat(N));
                this.CIN = ToDB(ToVat(C) / (ToVat(Isum) + ToVat(N)));
            }

            if (this.CIN <= 9)
            {
                this.BadParent.Add(this.Parent); // не удалось подключиться, добавление базовой в список плохих базовых
            }
            else
            {
                this.Orphan = false; // Подключение
            }
        }
    }
}
