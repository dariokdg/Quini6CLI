using System;
using System.Collections.Generic;
using System.Text;

namespace Quini6CLI.Winners
{
    class Quini6Winners
    {
        public TradicionalPrimeraWinners TPW { get; set; }
        public TradicionalSegundaWinners TSW { get; set; }
        public RevanchaWinners RW { get; set; }
        public SiempreSaleWinners SSW { get; set; }
        public PozoExtraWinners PEW { get; set; }

        public Quini6Winners(TradicionalPrimeraWinners TPW, TradicionalSegundaWinners TSW, RevanchaWinners RW, SiempreSaleWinners SSW, PozoExtraWinners PEW)
        {
            this.TPW = TPW;
            this.TSW = TSW;
            this.RW = RW;
            this.SSW = SSW;
            this.PEW = PEW;
        }
    }
}