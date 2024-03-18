using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateStatusDTO
    {

        public string? StatusName { get; set; }

        public static async Task<Status> ToStatusAsync(CreateStatusDTO createStatusDTO)
        {
            return new Status
            {
                StatusName = createStatusDTO.StatusName
            };

        }

    }
}