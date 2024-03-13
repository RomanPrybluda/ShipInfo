using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipHullInitializer
    {
        private readonly AppDbContext _context;
        private static readonly Random _random = new Random();

        private readonly int needsShipsQuantity = Constants.NeedsShipsQuantity;

        public ShipHullInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeShipHulls()
        {
            var existingShipHullCount = _context.ShipHulls.Count();

            if (existingShipHullCount >= needsShipsQuantity)
                return;

            double kOverAllLength = 1.044188;
            double kBreadth = 0.177301456;
            double kDepth = 0.542467452;
            double kSummerDraught = 0.72;
            double kLightship = 10.23;
            double kVolumeDisplacement = 0.626169;
            double seaWaterDensity = 1.025;

            for (int i = existingShipHullCount; i < needsShipsQuantity; i++)
            {
                var BetweenPerpendicularsLength = _random.Next(86, 181);
                var OverAllLength = BetweenPerpendicularsLength * kOverAllLength;
                var Breadth = BetweenPerpendicularsLength * kBreadth;
                var Depth = Breadth * kDepth;
                var SummerDraught = Depth * kSummerDraught;
                var SummerFreeBoard = (Depth - SummerDraught) * 1000 + 40;
                var Lightship = BetweenPerpendicularsLength * Breadth * Depth / kLightship;
                var VolumeDisplacement = BetweenPerpendicularsLength * Breadth * Depth / kVolumeDisplacement;
                var Displacement = VolumeDisplacement * seaWaterDensity;

                var shipHull = new ShipHull
                {
                    BetweenPerpendicularsLength = BetweenPerpendicularsLength,
                    OverAllLength = OverAllLength,
                    Breadth = Breadth,
                    Depth = Depth,
                    SummerDraught = SummerDraught,
                    SummerFreeBoard = SummerFreeBoard,
                    Lightship = Lightship,
                    VolumeDisplacement = VolumeDisplacement,
                    Displacement = Displacement
                };

                _context.ShipHulls.Add(shipHull);
            }

            _context.SaveChanges();
        }
    }
}