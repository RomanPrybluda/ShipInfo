using Microsoft.EntityFrameworkCore;
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

        public static async Task<ShipDTO> ToShipDTOAsync(Ship ship, AppDbContext context)
        {
            var shipDTO = await context.Ships
                .Where(s => s.Id == ship.Id)
                .Select(s => new ShipDTO
                {
                    Id = s.Id,
                    ImoNumber = s.ImoNumber,
                    ShipName = s.ShipName,
                    DateOfBuild = s.DateOfBuild,
                    GrossTonnage = s.GrossTonnage,
                    SummerDeadweight = s.SummerDeadweight,
                    ShipTypeName = context.ShipTypes
                            .FirstOrDefault(st => st.Id == s.ShipTypeId) != null ? context.ShipTypes
                            .First(st => st.Id == s.ShipTypeId).ShipTypeName : null,
                    StatusName = context.Statuses
                            .FirstOrDefault(st => st.Id == s.StatusId) != null ? context.Statuses.First(st => st.Id == s.StatusId).StatusName : null
                })
                .FirstOrDefaultAsync();

            return shipDTO;
        }

    }
}