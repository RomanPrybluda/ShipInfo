using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipInitializer
    {

        private readonly AppDbContext _context;
        private readonly ShipData _shipData;
        private static readonly Random _random = new Random();

        private readonly int needsShipsQuantity = Constants.NeedsShipsQuantity;

        readonly int callSingLenth = 5;
        readonly int separateMainEnginePower = 1000;
        int mainEngineQuantity;
        readonly int mainEngineQuantityOne = 1;
        readonly int mainEngineQuantityTwo = 2;
        readonly int auxiliaryEngineQuantity = 3;
        readonly int generatorQuantity = 3;
        readonly double kGrossTonnage = 3.024076387;
        readonly double kNetTonnage = 0.916476439;
        double kOverAllLength = 1.044188;
        double kBreadth = 0.177301456;
        double kDepth = 0.542467452;
        double kSummerDraught = 0.72;
        double kLightship = 10.23;
        double kVolumeDisplacement = 0.626169;
        double seaWaterDensity = 1.025;

        public ShipInitializer(AppDbContext context)
        {
            _context = context;
            _shipData = new ShipData(context);
        }

        public void InitializeShips()
        {
            var existingShipCount = _context.Ships.Count();

            if (existingShipCount < needsShipsQuantity)
            {
                for (int i = 0; i < (needsShipsQuantity - existingShipCount); i++)
                {
                    int imoNumber;
                    do
                    {
                        imoNumber = _shipData.GetImoNumber();
                    }
                    while (_context.Ships.Any(ship => ship.ImoNumber == imoNumber));

                    var BetweenPerpendicularsLength = _random.Next(86, 181);
                    var OverAllLength = BetweenPerpendicularsLength * kOverAllLength;
                    var Breadth = BetweenPerpendicularsLength * kBreadth;
                    var Depth = Breadth * kDepth;
                    var SummerDraught = Depth * kSummerDraught;
                    var SummerFreeBoard = (Depth - SummerDraught) * 1000 + 40;
                    var Lightship = BetweenPerpendicularsLength * Breadth * Depth / kLightship;
                    var VolumeDisplacement = BetweenPerpendicularsLength * Breadth * Depth / kVolumeDisplacement;
                    var Displacement = VolumeDisplacement * seaWaterDensity;

                    var shipName = _shipData.GetShipName(ShipData.ShipNames);
                    var dateOfBuild = ShipData.GenerateRandomDate();
                    var statusId = _shipData.GetRandomStatusId(ShipData.ShipStatuses);
                    var shipTypeId = _shipData.GetRandomShipTypeId(ShipData.ShipTypes);
                    var sallSign = _shipData.GenerateRandomCallSign(callSingLenth);
                    var shipPowerPlantTypeId = _shipData.GetShipPowerPlantTypeId(ShipData.powerPlantTypeName);
                    var shipPropulsorTypeId = _shipData.GetShipPropulsorTypeId(ShipData.powerPropulsorTypeName);
                    var mainEngine = _shipData.GetRandomEntity(_context.MainEngines);

                    if (mainEngine.MaxMainEnginePower < separateMainEnginePower)
                        mainEngineQuantity = mainEngineQuantityOne;
                    else
                        mainEngineQuantity = mainEngineQuantityTwo;

                    var shipFlagId = _shipData.GetRandomEntity(_context.ShipFlags).Id;
                    var classSocietyId = _shipData.GetRandomEntity(_context.ClassSocieties).Id;
                    var operatorId = _shipData.GetRandomEntity(_context.Operators).Id;
                    var ownerId = _shipData.GetRandomEntity(_context.Owners).Id;
                    var shipBuilderId = _shipData.GetRandomEntity(_context.ShipBuilders).Id;
                    var mainEngineId = _shipData.GetRandomEntity(_context.MainEngines).Id;
                    var auxiliaryEngineId = _shipData.GetRandomEntity(_context.AuxiliaryEngines).Id;
                    var generatorId = _shipData.GetRandomEntity(_context.Generators).Id;

                    var ship = new Ship
                    {
                        ImoNumber = imoNumber,
                        ShipName = shipName,
                        DateOfBuild = dateOfBuild,
                        CallSign = sallSign,
                        StatusId = statusId,
                        ShipTypeId = shipTypeId,
                        ShipPowerPlantTypeId = shipPowerPlantTypeId,
                        ShipPropulsorTypeId = shipPropulsorTypeId,
                        SummerDeadweight = Displacement - Lightship,
                        GrossTonnage = kGrossTonnage * Displacement,
                        NetTonnage = kNetTonnage * kGrossTonnage * Displacement,
                        MainEngineQuantity = mainEngineQuantity,
                        AuxiliaryEngineQuantity = auxiliaryEngineQuantity,
                        GeneratorQuantity = generatorQuantity,
                        ShipFlagId = shipFlagId,
                        ClassSocietyId = classSocietyId,
                        MainEngineId = mainEngineId,
                        AuxiliaryEngineId = auxiliaryEngineId,
                        GeneratorId = generatorId,
                        ShipBuilderId = shipBuilderId,
                        OperatorId = operatorId,
                        OwnerId = ownerId,
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

                    _context.Ships.Add(ship);
                    _context.SaveChanges();
                }
            }
        }


    }
}