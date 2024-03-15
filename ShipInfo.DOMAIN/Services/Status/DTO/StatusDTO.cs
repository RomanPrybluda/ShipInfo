using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class StatusDTO
    {
        public Guid Id { get; set; }

        public string? StatusName { get; set; }

        public static async Task<StatusDTO> ToStatusDTOAsync(Status status)
        {
            return new StatusDTO
            {
                Id = status.Id,
                StatusName = status.StatusName

            };

        }
    }
}
