using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipByIdDTO
    {
        public Guid Id { get; set; }

        public int ImoNumber { get; set; }

        public string? ShipName { get; set; }

        public string? ShipTypeName { get; set; }

        public DateTime DateOfBuild { get; set; }

        public string? StatusName { get; set; }

        public double GrossTonnage { get; set; }

        public double SummerDeadweight { get; set; }

        public double NetTonnage { get; set; }

        public string? ShipFlag { get; set; }

        public string? CallSign { get; set; }

        public string? ClassSociety { get; set; }

        public string? ShipPowerPlantType { get; set; }

        public string? ShipPropulsorType { get; set; }

        public int MainEngineQuantity { get; set; }

        public string? MainEngine { get; set; }

        public int AuxiliaryEngineQuantity { get; set; }

        public string? AuxiliaryEngine { get; set; }

        public int GeneratorQuantity { get; set; }

        public string? Generator { get; set; }

        public string? ShipBuilder { get; set; }

        public string? Owner { get; set; }

        public string? Operator { get; set; }

        public double OverAllLength { get; set; }

        public double BetweenPerpendicularsLength { get; set; }

        public double Breadth { get; set; }

        public double Depth { get; set; }

        public double SummerDraught { get; set; }

        public double SummerFreeBoard { get; set; }

        public double Lightship { get; set; }

        public double Displacement { get; set; }

        public double VolumeDisplacement { get; set; }

        public static ShipByIdDTO ToShipByIdDTOAsync(Ship ship, AppDbContext context)
        {

            return new ShipByIdDTO
            {
                Id = ship.Id,
                ImoNumber = ship.ImoNumber,
                ShipName = ship.ShipName,
                OverAllLength = ship.OverAllLength,
                BetweenPerpendicularsLength = ship.BetweenPerpendicularsLength,
                Breadth = ship.Breadth,
                Depth = ship.Depth,
                SummerDraught = ship.SummerDraught,
                SummerFreeBoard = ship.SummerFreeBoard,
                Lightship = ship.Lightship,
                Displacement = ship.Displacement,
                VolumeDisplacement = ship.VolumeDisplacement,
                ShipTypeName = context.ShipTypes
                                .FirstOrDefault(st => st.Id == ship.ShipTypeId)?.ShipTypeName,
                DateOfBuild = ship.DateOfBuild,
                StatusName = context.Statuses
                                .FirstOrDefault(st => st.Id == ship.StatusId)?.StatusName,
                GrossTonnage = ship.GrossTonnage,
                SummerDeadweight = ship.SummerDeadweight,
                NetTonnage = ship.NetTonnage,
                ShipFlag = context.ShipFlags
                                .FirstOrDefault(sf => sf.Id == ship.ShipFlagId)?.ShipFlagName,
                CallSign = ship.CallSign,
                ClassSociety = context.ClassSocieties
                                .FirstOrDefault(cs => cs.Id == ship.ClassSocietyId)?.ClassSocietyName,
                ShipPowerPlantType = context.ShipPowerPlantTypes
                                .FirstOrDefault(sppt => sppt.Id == ship.ShipPowerPlantTypeId)?.ShipPowerPlantTypeName,
                ShipPropulsorType = context.ShipPropulsorTypes
                                .FirstOrDefault(spt => spt.Id == ship.ShipPropulsorTypeId)?.ShipPropulsorTypeName,
                MainEngineQuantity = ship.MainEngineQuantity,
                MainEngine = context.MainEngines
                                .FirstOrDefault(me => me.Id == ship.MainEngineId)?.MainEngineType,
                AuxiliaryEngineQuantity = ship.AuxiliaryEngineQuantity,
                AuxiliaryEngine = context.AuxiliaryEngines
                                .FirstOrDefault(ae => ae.Id == ship.AuxiliaryEngineId)?.AuxiliaryEngineType,
                GeneratorQuantity = ship.GeneratorQuantity,
                Generator = context.Generators
                                .FirstOrDefault(g => g.Id == ship.GeneratorId)?.GeneratorType,
                ShipBuilder = context.ShipBuilders
                                .FirstOrDefault(sb => sb.Id == ship.ShipBuilderId)?.ShipBuilderName,
                Owner = context.Owners
                                .FirstOrDefault(o => o.Id == ship.OwnerId)?.OwnerName,
                Operator = context.Operators
                                .FirstOrDefault(op => op.Id == ship.OperatorId)?.OperatorName
            };

        }

    }
}