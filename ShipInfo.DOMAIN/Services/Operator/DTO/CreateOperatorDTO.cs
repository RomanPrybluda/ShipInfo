using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateOperatorDTO
    {
        public string? OperatorName { get; set; }

        public string? OperatorAddress { get; set; }

        public string? OperatorEmail { get; set; }

        public string? OperatorPhone { get; set; }

        public static async Task<Operator> ToOperatorAsync(CreateOperatorDTO createOperator)
        {
            return new Operator
            {
                OperatorName = createOperator.OperatorName,
                OperatorAddress = createOperator.OperatorAddress,
                OperatorEmail = createOperator.OperatorEmail,
                OperatorPhone = createOperator.OperatorPhone
            };
        }
    }

}
