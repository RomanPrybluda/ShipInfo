namespace ShipInfo.DOMAIN
{
    public class UpdateShipDTO
    {
        public Guid Id { get; set; }

        public int ImoNumber { get; set; }

        public string? ShipName { get; set; }

        public Guid ShipTypeId { get; set; }

        public DateTime DateOfBuild { get; set; }

        public Guid StatusId { get; set; }

        public double GrossTonnage { get; set; }

        public double SummerDeadweight { get; set; }

    }
}