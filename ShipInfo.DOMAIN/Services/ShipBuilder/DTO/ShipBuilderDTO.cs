using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipBuilderDTO
    {
        public Guid Id { get; set; }

        public string? ShipBuilderName { get; set; }

        public static async Task<ShipBuilderDTO> ToShipBuilderDTOAsync(ShipBuilder shipBuilder)
        {
            return new ShipBuilderDTO
            {
                Id = shipBuilder.Id,
                ShipBuilderName = shipBuilder.ShipBuilderName
            };
        }

    }
}