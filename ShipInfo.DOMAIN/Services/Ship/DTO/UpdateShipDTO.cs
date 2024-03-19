using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateShipDTO
    {
        public int ImoNumber { get; set; }

        public string? ShipName { get; set; }

        public Guid ShipTypeId { get; set; }

        public DateTime DateOfBuild { get; set; }

        public Guid StatusId { get; set; }

        public double GrossTonnage { get; set; }

        public double SummerDeadweight { get; set; }

        public double NetTonnage { get; set; }

        public Guid ShipFlagId { get; set; }

        public string? CallSign { get; set; }

        public Guid ClassSocietyId { get; set; }

        public Guid ShipPowerPlantTypeId { get; set; }

        public Guid ShipPropulsorTypeId { get; set; }

        public int MainEngineQuantity { get; set; }

        public Guid MainEngineId { get; set; }

        public int AuxiliaryEngineQuantity { get; set; }

        public Guid AuxiliaryEngineId { get; set; }

        public int GeneratorQuantity { get; set; }

        public Guid GeneratorId { get; set; }

        public Guid ShipBuilderId { get; set; }

        public Guid OwnerId { get; set; }

        public Guid OperatorId { get; set; }

        public double OverAllLength { get; set; }

        public double BetweenPerpendicularsLength { get; set; }

        public double Breadth { get; set; }

        public double Depth { get; set; }

        public double SummerDraught { get; set; }

        public double SummerFreeBoard { get; set; }

        public double Lightship { get; set; }

        public double Displacement { get; set; }

        public double VolumeDisplacement { get; set; }

        public void UpdateShip(Ship ship, UpdateShipDTO updateShipDTO)
        {
            ship.ImoNumber = updateShipDTO.ImoNumber;
            ship.ShipName = updateShipDTO.ShipName;
            ship.DateOfBuild = updateShipDTO.DateOfBuild;
            ship.GrossTonnage = updateShipDTO.GrossTonnage;
            ship.CallSign = updateShipDTO.CallSign;
            ship.ShipTypeId = updateShipDTO.ShipTypeId;
            ship.StatusId = updateShipDTO.StatusId;
            ship.ShipFlagId = updateShipDTO.ShipFlagId;
            ship.ClassSocietyId = updateShipDTO.ClassSocietyId;
            ship.ShipPowerPlantTypeId = updateShipDTO.ShipPowerPlantTypeId;
            ship.ShipPropulsorTypeId = updateShipDTO.ShipPropulsorTypeId;
            ship.MainEngineId = updateShipDTO.MainEngineId;
            ship.AuxiliaryEngineId = updateShipDTO.AuxiliaryEngineId;
            ship.GeneratorId = updateShipDTO.GeneratorId;
            ship.ShipBuilderId = updateShipDTO.ShipBuilderId;
            ship.OwnerId = updateShipDTO.OwnerId;
            ship.OperatorId = updateShipDTO.OperatorId;
            ship.SummerDeadweight = updateShipDTO.SummerDeadweight;
            ship.NetTonnage = updateShipDTO.NetTonnage;
            ship.OverAllLength = updateShipDTO.OverAllLength;
            ship.BetweenPerpendicularsLength = updateShipDTO.BetweenPerpendicularsLength;
            ship.Breadth = updateShipDTO.Breadth;
            ship.Depth = updateShipDTO.Depth;
            ship.SummerDraught = updateShipDTO.SummerDraught;
            ship.SummerFreeBoard = updateShipDTO.SummerFreeBoard;
            ship.Lightship = updateShipDTO.Lightship;
            ship.Displacement = updateShipDTO.Displacement;
            ship.VolumeDisplacement = updateShipDTO.VolumeDisplacement;
            ship.GeneratorQuantity = updateShipDTO.GeneratorQuantity;
            ship.AuxiliaryEngineQuantity = updateShipDTO.AuxiliaryEngineQuantity;
            ship.MainEngineQuantity = updateShipDTO.MainEngineQuantity;

        }

    }
}