using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class OwnerDTO
    {
        public Guid Id { get; set; }

        public string? OwnerName { get; set; }

        public string? OwnerAddress { get; set; }

        public string? OwnerEmail { get; set; }

        public string? OwnerPhone { get; set; }

        public static async Task<OwnerDTO> ToOwnerDTOAsync(Owner owner)
        {
            return new OwnerDTO
            {
                Id = owner.Id,
                OwnerName = owner.OwnerName,
                OwnerAddress = owner.OwnerAddress,
                OwnerEmail = owner.OwnerEmail,
                OwnerPhone = owner.OwnerPhone
            };

        }
    }

}