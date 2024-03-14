namespace ShipInfo.DAL
{
    public class Operator
    {
        public Guid Id { get; set; }

        public string? OperatorName { get; set; }

        public string? OperatorAddress { get; set; }

        public string? OperatorEmail { get; set; }

        public string? OperatorPhone { get; set; }

        public ICollection<Ship>? Ships { get; set; }

    }
}