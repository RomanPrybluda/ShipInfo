using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class CreateClassSocietyDTO
    {

        public string? ClassSocietyName { get; set; }

        public string? ClassSocietyCode { get; set; }

        public bool ClassSocietyIsIACS { get; set; }

        public static async Task<ClassSociety> ToClassSocietyAsync(CreateClassSocietyDTO classSociety)
        {
            return new ClassSociety
            {
                ClassSocietyName = classSociety.ClassSocietyName,
                ClassSocietyCode = classSociety.ClassSocietyCode,
                ClassSocietyIsIACS = classSociety.ClassSocietyIsIACS,
            };

        }
    }
}
