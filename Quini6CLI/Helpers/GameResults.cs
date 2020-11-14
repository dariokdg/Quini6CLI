namespace Quini6CLI.Helpers
{
    class GameResults
    {
        public GameTypeResult GTRTP { get; set; }
        public GameTypeResult GTRTS { get; set; }
        public GameTypeResult GTRR { get; set; }
        public GameTypeResult GTRSS { get; set; }
        public GameTypeResult GTRPE { get; set; }

        public GameResults(GameTypeResult GTRTP, GameTypeResult GTRTS, GameTypeResult GTRR, GameTypeResult GTRSS, GameTypeResult GTRPE)
        {
            this.GTRTP = GTRTP;
            this.GTRTS = GTRTS;
            this.GTRR = GTRR;
            this.GTRSS = GTRSS;
            this.GTRPE = GTRPE;
        }
    }
}