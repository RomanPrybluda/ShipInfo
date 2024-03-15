using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateOwnerDTO
    {
        public string? OwnerName { get; set; }

        public string? OwnerAddress { get; set; }

        public string? OwnerEmail { get; set; }

        public string? OwnerPhone { get; set; }

        public void UpdateOwner(Owner owner, UpdateOwnerDTO updateOwnerDTO)
        {
            owner.OwnerName = updateOwnerDTO.OwnerName;
            owner.OwnerAddress = updateOwnerDTO.OwnerAddress;
            owner.OwnerEmail = updateOwnerDTO.OwnerEmail;
            owner.OwnerPhone = updateOwnerDTO.OwnerPhone;
        }
    }
}
