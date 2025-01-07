namespace ShipInfo.Domain
{
    public class ShipShortDetails
    {
        public Guid Id { get; set; }

        public int ImoNumber { get; set; }

        public string ShipName { get; set; } = string.Empty;

        public double GrossTonnage { get; set; }

        public string ShipTypeName { get; set; } = string.Empty;

        public DateTime DateOfBuild { get; set; }

        public string ShipFlagName { get; set; } = string.Empty;

    }
}