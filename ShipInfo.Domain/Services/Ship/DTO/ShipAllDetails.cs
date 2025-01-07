namespace ShipInfo.Domain
{
    public class ShipAllDetails
    {
        public Guid Id { get; set; }

        public int ImoNumber { get; set; }

        public string ShipName { get; set; } = string.Empty;

        public string ShipTypeName { get; set; } = string.Empty;

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

    }
}