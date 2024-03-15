using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateOwnerDTO
    {
        public string? OwnerName { get; set; }

        public string? OwnerAddress { get; set; }

        public string? OwnerEmail { get; set; }

        public string? OwnerPhone { get; set; }

        public static async Task<Owner> ToOwnerAsync(CreateOwnerDTO createOwnerDTO)
        {
            return new Owner
            {
                OwnerName = createOwnerDTO.OwnerName,
                OwnerAddress = createOwnerDTO.OwnerAddress,
                OwnerEmail = createOwnerDTO.OwnerEmail,
                OwnerPhone = createOwnerDTO.OwnerPhone
            };

        }
    }
}
