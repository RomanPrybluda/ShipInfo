namespace ShipInfo.Domain.Entities
{
    public class ClassSociety
    {
        public Guid Id { get; set; }

        public string? ClassSocietyName { get; set; }

        public string? ClassSocietyCode { get; set; }

        public bool ClassSocietyIsIACS { get; set; }

        public ICollection<Ship>? Ships { get; set; }

    }
}