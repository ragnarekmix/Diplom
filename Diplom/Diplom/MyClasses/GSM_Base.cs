using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diplom;

namespace Diplom.MyClasses
{
    class GSM_Base : Point
    {
        public GSM_Base(int y, int x)
            : base(y, x)
        {
            Number = Count;
            Count++;
        }
        public static Double Ful { get; set; } // МГц
        public static Double Fdl { get; set; } // МГц
        public static Double P { get; set; }   // Ват
        public static Double G { get; set; }   // дБ
        public static Double Lf { get; set; }  // дБ
        public double Isum { get; set; }       // дБ
        public int Number { get; set; } // Порядковый номер станции
        private static int Count { get; set; } // Счетчик созданных станций

        public void SetIsum(List<CDMA_Base> cdma)
        {
            double sum = 0;
            foreach (CDMA_Base cdmaBase in cdma)
            {
                double P = ToDB(CDMA_Base.P) + 30;
                double D = Distance((Point)this, (Point)cdmaBase) / 1000;
                double L = (92.5 + 20 * Math.Log10(CDMA_Base.Ful / 1000 * D));
                double IRF = GetIRF();
                double I = P + CDMA_Base.G - CDMA_Base.Lf - L - GSM_Base.Lf + GSM_Base.G + IRF;
                //double I = ToDB(CDMA_Base.P) + CDMA_Base.G - CDMA_Base.Lf - (92.5 + 20 * Math.Log10(CDMA_Base.Ful / 1000 * Distance((Point)this, (Point)cdmaBase) / 1000)) - GSM_Base.Lf + GSM_Base.G - GetIRF();
                sum = sum + I;
            }
            this.Isum = sum;
        }

        public static double GetIRF()
        {
            double DF = Math.Abs(CDMA_Base.Ful - GSM_Base.Fdl) / 1.25;
            double irf = 0;
            if (DF >= 0.5 & DF <= 1)
            {
                irf = (50 * DF - 25) + 10 * Math.Log10(1.25 / 0.271);
            }
            if (DF > 1 & DF <= 2)
            {
                irf = (20 * DF + 5) + 10 * Math.Log10(1.25 / 0.271);
            }
            if (DF > 2)
            {
                irf = (15 * DF + 15) + 10 * Math.Log10(1.25 / 0.271);
            }
            return irf;
        }


    }
}
