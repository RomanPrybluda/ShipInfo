using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ClassSocietyDTO
    {
        public Guid Id { get; set; }

        public string? ClassSocietyName { get; set; }

        public string? ClassSocietyCode { get; set; }

        public bool ClassSocietyIsIACS { get; set; }

        public static async Task<ClassSocietyDTO> ToClassSocietyDTOAsync(ClassSociety classSociety)
        {
            return new ClassSocietyDTO
            {
                Id = classSociety.Id,
                ClassSocietyName = classSociety.ClassSocietyName,
                ClassSocietyCode = classSociety.ClassSocietyCode,
                ClassSocietyIsIACS = classSociety.ClassSocietyIsIACS,
            };

        }

    }
}
