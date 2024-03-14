namespace ShipInfo.DAL
{
    public class Ship
    {
        public Guid Id { get; set; }

        public int ImoNumber { get; set; }

        public string? ShipName { get; set; }

        public Guid ShipTypeId { get; set; }

        public ShipType? ShipType { get; set; }

        public Guid ShipFlagId { get; set; }

        public ShipFlag? ShipFlag { get; set; }

        public string? CallSign { get; set; }

        public Guid ClassSocietyId { get; set; }

        public ClassSociety? ClassSociety { get; set; }

        public DateTime DateOfBuild { get; set; }

        public Guid StatusId { get; set; }

        public Status? Status { get; set; }

        public double GrossTonnage { get; set; }

        public double NetTonnage { get; set; }

        public double SummerDeadweight { get; set; }

        public Guid ShipPowerPlantTypeId { get; set; }

        public ShipPowerPlantType? ShipPowerPlantType { get; set; }

        public Guid ShipPropulsorTypeId { get; set; }

        public ShipPropulsorType? ShipPropulsorType { get; set; }

        public int MainEngineQuantity { get; set; }

        public Guid MainEngineId { get; set; }

        public MainEngine? MainEngine { get; set; }

        public int AuxiliaryEngineQuantity { get; set; }

        public Guid AuxiliaryEngineId { get; set; }

        public AuxiliaryEngine? AuxiliaryEngine { get; set; }

        public int GeneratorQuantity { get; set; }

        public Guid GeneratorId { get; set; }

        public Generator? Generator { get; set; }

        public Guid ShipBuilderId { get; set; }

        public ShipBuilder? ShipBuilder { get; set; }

        public Guid OwnerId { get; set; }

        public Owner? Owner { get; set; }

        public Guid OperatorId { get; set; }

        public Operator? Operator { get; set; }

        public Guid ShipHullId { get; set; }

        public ShipHull? ShipHull { get; set; }

    }
}