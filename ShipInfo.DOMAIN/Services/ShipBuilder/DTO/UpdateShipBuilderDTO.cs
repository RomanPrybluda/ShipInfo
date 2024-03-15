using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateShipBuilderDTO
    {
        public string? ShipBuilderName { get; set; }

        public void UpdateShipBuilder(ShipBuilder shipBuilder, UpdateShipBuilderDTO updateShipBuilderDTO)
        {
            shipBuilder.ShipBuilderName = updateShipBuilderDTO.ShipBuilderName;
        }

    }
}