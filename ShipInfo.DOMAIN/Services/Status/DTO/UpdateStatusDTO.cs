using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateStatusDTO
    {

        public string? StatusName { get; set; }

        public void UpdateStatus(Status status, UpdateStatusDTO updateStatusDTO)
        {
            status.StatusName = updateStatusDTO.StatusName;
        }

    }
}