using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class OperatorDTO
    {
        public Guid Id { get; set; }

        public string? OperatorName { get; set; }

        public string? OperatorAddress { get; set; }

        public string? OperatorEmail { get; set; }

        public string? OperatorPhone { get; set; }

        public static async Task<OperatorDTO> ToOperatorDTOAsync(Operator shipOperator)
        {
            return new OperatorDTO
            {
                Id = shipOperator.Id,
                OperatorName = shipOperator.OperatorName,
                OperatorAddress = shipOperator.OperatorAddress,
                OperatorEmail = shipOperator.OperatorEmail,
                OperatorPhone = shipOperator.OperatorPhone
            };

        }
    }
}
