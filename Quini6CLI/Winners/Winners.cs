using Quini6CLI.Interfaces;

namespace Quini6CLI.Winners
{
    class Quini6Winners
    {
        public IWinner TPFPW { get; set; }
        public IWinner TPSPW { get; set; }
        public IWinner TPTPW { get; set; }
        public IWinner TSFPW { get; set; }
        public IWinner TSSPW { get; set; }
        public IWinner TSTPW { get; set; }
        public IWinner RW { get; set; }
        public IWinner SSW { get; set; }
        public IWinner PEW { get; set; }

        public Quini6Winners(
            IWinner TPFPW,
            IWinner TPSPW,
            IWinner TPTPW,
            IWinner TSFPW,
            IWinner TSSPW,
            IWinner TSTPW,
            IWinner RW,
            IWinner SSW,
            IWinner PEW)
        {
            this.TPFPW = TPFPW;
            this.TPSPW = TPSPW;
            this.TPTPW = TPTPW;
            this.TSFPW = TSFPW;
            this.TSSPW = TSSPW;
            this.TSTPW = TSTPW;
            this.RW = RW;
            this.SSW = SSW;
            this.PEW = PEW;
        }
    }
}