using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class UpdateOperatorDTO
    {
        public string? OperatorName { get; set; }

        public string? OperatorAddress { get; set; }

        public string? OperatorEmail { get; set; }

        public string? OperatorPhone { get; set; }

        public void UpdateOperator(Operator shipOperator, UpdateOperatorDTO updateOperator)
        {
            shipOperator.OperatorName = updateOperator.OperatorName;
            shipOperator.OperatorAddress = updateOperator.OperatorAddress;
            shipOperator.OperatorEmail = updateOperator.OperatorEmail;
            shipOperator.OperatorPhone = updateOperator.OperatorPhone;
        }
    }
}
