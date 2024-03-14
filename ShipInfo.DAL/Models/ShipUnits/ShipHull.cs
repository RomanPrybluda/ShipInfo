namespace ShipInfo.DAL
{
    public class ShipHull
    {

        public Guid Id { get; set; }

        public double OverAllLength { get; set; }

        public double BetweenPerpendicularsLength { get; set; }

        public double Breadth { get; set; }

        public double Depth { get; set; }

        public double SummerDraught { get; set; }

        public double SummerFreeBoard { get; set; }

        public double Lightship { get; set; }

        public double Displacement { get; set; }

        public double VolumeDisplacement { get; set; }

        public Ship? Ship { get; set; }

    }
}