using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateStatusDTO
    {
        public Guid Id { get; set; }

        public string? StatusName { get; set; }

        public static async Task<Status> ToStatusAsync(CreateStatusDTO createStatusDTO)
        {
            return new Status
            {
                Id = createStatusDTO.Id,
                StatusName = createStatusDTO.StatusName

            };

        }
    }
}
