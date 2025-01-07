using ShipInfo.DAL;

namespace ShipInfo.Domain
{
    public class ClassSocietyInitializer
    {
        private readonly ShipInfoDbContext _context;

        public ClassSocietyInitializer(ShipInfoDbContext context)
        {
            _context = context;
        }

        public void InitializeClassSocieties()
        {
            var classSocietyData = ClassSocietyData();

            foreach (var societyData in classSocietyData)
            {
                var existingSociety = _context.ClassSocieties.FirstOrDefault(cs => cs.ClassSocietyName == societyData.ClassSocietyName);

                if (existingSociety == null)
                {
                    var society = new ClassSociety
                    {
                        ClassSocietyName = societyData.ClassSocietyName,
                        ClassSocietyCode = societyData.ClassSocietyCode,
                        ClassSocietyIsIACS = societyData.IsIACS == "IsIACS"
                    };

                    _context.ClassSocieties.Add(society);

                }
            }

            _context.SaveChanges();
        }

        private (string ClassSocietyName, string ClassSocietyCode, string IsIACS)[] ClassSocietyData()
        {
            return new[]
            {
                ("American Bureau of Shipping", "ABS", "IsIACS"),
                ("Asia Shipping Certification Services", "ASCS", "IsNotIACS"),
                ("Biro Klasifikasi Indonesia", "BKI", "IsNotIACS"),
                ("Bulgarian Register of Shipping", "BRS", "IsNotIACS"),
                ("Bureau Veritas", "BV", "IsIACS"),
                ("China Classification Society", "CCS", "IsIACS"),
                ("Cosmos Marine Bureau Inc", "CMB", "IsNotIACS"),
                ("CR Classification Society", "", "IsNotIACS"),
                ("Croatian Register of Shipping", "CRS", "IsIACS"),
                ("DNV GL AS", "DNV GL AS", "IsIACS"),
                ("Dromon Bureau of Shipping", "DR", "IsNotIACS"),
                ("Foresight ship Classification", "FSCLASS", "IsNotIACS"),
                ("Indian Register of Shipping", "IRS", "IsIACS"),
                ("Intermaritime Certification Services, S.A.", "ICS", "IsNotIACS"),
                ("International Naval Surveys Bureau", "INSB", "IsNotIACS"),
                ("International Register of Shipping", "IS", "IsNotIACS"),
                ("Isthmus Bureau of Shipping", "IB", "IsNotIACS"),
                ("Korean Register", "KR", "IsIACS"),
                ("Lloyd's Register", "LRS", "IsIACS"),
                ("Macosnar Corp", "MC", "IsNotIACS"),
                ("Maritime Lloyd Georgia", "MG", "IsNotIACS"),
                ("Mediterranean Shipping Register", "MSR", "IsNotIACS"),
                ("National Shipping Adjusters Inc.", "NSA", "IsNotIACS"),
                ("Nippon Kaiji Kyokai", "NKK", "IsIACS"),
                ("Other", "Other", "IsNotIACS"),
                ("Overseas Marine Certification Services", "OMCS", "IsNotIACS"),
                ("Panama Maritime Documentation Services", "PMDS", "IsNotIACS"),
                ("Panama Shipping Registrar Inc", "PSR", "IsNotIACS"),
                ("Phoenix Register of Shipping", "PhRS", "IsNotIACS"),
                ("Polish Register of Shipping", "PRS", "IsIACS"),
                ("Qualitas Register of Shipping S.A.", "QRS", "IsNotIACS"),
                ("Registro Italiano Navale", "RINA", "IsIACS"),
                ("Russian Maritime Register of Shipping", "RMRS", "IsNotIACS"),
                ("Shipping Register of Ukraine", "SRU", "IsNotIACS"),
                ("Sing Lloyd", "SL", "IsNotIACS"),
                ("Turk Loydu", "TLV", "IsIACS"),
                ("Union Bureau of Shipping", "UBS", "IsNotIACS"),
                ("United Registration and Classification of Services", "URACOS", "IsNotIACS"),
                ("Universal Maritime Bureau", "UMB", "IsNotIACS"),
                ("Veritas Register of Shipping", "VRS", "IsNotIACS"),
                ("Vietnam Register of Shipping", "VR", "IsNotIACS"),
            };
        }
    }
}