using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateShipBuilderDTO
    {
        public string? ShipBuilderName { get; set; }

        public static async Task<ShipBuilder> ToShipBuilderAsync(CreateShipBuilderDTO createShipBuilderDTO)
        {
            return new ShipBuilder
            {
                ShipBuilderName = createShipBuilderDTO.ShipBuilderName
            };
        }

    }
}