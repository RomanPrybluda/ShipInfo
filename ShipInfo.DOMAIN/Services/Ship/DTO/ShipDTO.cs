using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipDTO
    {
        public Guid Id { get; set; }

        public int ImoNumber { get; set; }

        public string? ShipName { get; set; }

        public string? ShipTypeName { get; set; }

        public DateTime DateOfBuild { get; set; }

        public string? StatusName { get; set; }

        public double GrossTonnage { get; set; }

        public double SummerDeadweight { get; set; }

        public string? ShipFlagName { get; set; }

        public static ShipDTO ShipToShipDTO(Ship ship, AppDbContext context)
        {

            return new ShipDTO
            {
                Id = ship.Id,
                ImoNumber = ship.ImoNumber,
                ShipName = ship.ShipName,
                DateOfBuild = ship.DateOfBuild,
                GrossTonnage = ship.GrossTonnage,
                SummerDeadweight = ship.SummerDeadweight,
                ShipTypeName = context.ShipTypes.FirstOrDefault(st => st.Id == ship.ShipTypeId)?.ShipTypeName,
                StatusName = context.Statuses.FirstOrDefault(st => st.Id == ship.StatusId)?.StatusName,
                ShipFlagName = context.ShipFlags.FirstOrDefault(st => st.Id == ship.ShipFlagId)?.ShipFlagName
            };


        }

    }
}