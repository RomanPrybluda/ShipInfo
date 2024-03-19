using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateShipDTO
    {

        public int ImoNumber { get; set; }

        public string? ShipName { get; set; }

        public Guid ShipTypeId { get; set; }

        public Guid ShipFlagId { get; set; }

        public string? CallSign { get; set; }

        public Guid ClassSocietyId { get; set; }

        public DateTime DateOfBuild { get; set; }

        public Guid StatusId { get; set; }

        public double GrossTonnage { get; set; }

        public Guid ShipPowerPlantTypeId { get; set; }

        public Guid ShipPropulsorTypeId { get; set; }

        public Guid MainEngineId { get; set; }

        public Guid AuxiliaryEngineId { get; set; }

        public Guid GeneratorId { get; set; }

        public Guid ShipBuilderId { get; set; }

        public Guid OwnerId { get; set; }

        public Guid OperatorId { get; set; }


        public static Ship CreateShipDTOToShip(CreateShipDTO createShipDTO)
        {
            var ship = new Ship
            {
                ImoNumber = createShipDTO.ImoNumber,
                ShipName = createShipDTO.ShipName,
                DateOfBuild = createShipDTO.DateOfBuild,
                GrossTonnage = createShipDTO.GrossTonnage,
                CallSign = createShipDTO.CallSign,
                ShipTypeId = createShipDTO.ShipTypeId,
                StatusId = createShipDTO.StatusId,
                ShipFlagId = createShipDTO.ShipFlagId,
                ClassSocietyId = createShipDTO.ClassSocietyId,
                ShipPowerPlantTypeId = createShipDTO.ShipPowerPlantTypeId,
                ShipPropulsorTypeId = createShipDTO.ShipPropulsorTypeId,
                MainEngineId = createShipDTO.MainEngineId,
                AuxiliaryEngineId = createShipDTO.AuxiliaryEngineId,
                GeneratorId = createShipDTO.GeneratorId,
                ShipBuilderId = createShipDTO.ShipBuilderId,
                OwnerId = createShipDTO.OwnerId,
                OperatorId = createShipDTO.OperatorId
            };

            return ship;
        }

    }
}