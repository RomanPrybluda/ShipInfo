using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipByIdDTO
    {
        public Guid Id { get; set; }

        public int ImoNumber { get; set; }

        public string? ShipName { get; set; }

        public string? ShipTypeName { get; set; }

        public DateTime DateOfBuild { get; set; }

        public string? StatusName { get; set; }

        public double GrossTonnage { get; set; }

        public double SummerDeadweight { get; set; }

        public double NetTonnage { get; set; }

        public string? ShipFlag { get; set; }

        public string? CallSign { get; set; }

        public string? ClassSociety { get; set; }

        public string? ShipPowerPlantType { get; set; }

        public string? ShipPropulsorType { get; set; }

        public int MainEngineQuantity { get; set; }

        public string? MainEngine { get; set; }

        public int AuxiliaryEngineQuantity { get; set; }

        public string? AuxiliaryEngine { get; set; }

        public int GeneratorQuantity { get; set; }

        public string? Generator { get; set; }

        public string? ShipBuilder { get; set; }

        public string? Owner { get; set; }

        public string? Operator { get; set; }

        public double OverAllLength { get; set; }

        public double BetweenPerpendicularsLength { get; set; }

        public double Breadth { get; set; }

        public double Depth { get; set; }

        public double SummerDraught { get; set; }

        public double SummerFreeBoard { get; set; }

        public double Lightship { get; set; }

        public double Displacement { get; set; }

        public double VolumeDisplacement { get; set; }

        public static async Task<ShipByIdDTO> ToShipByIdDTOAsync(Ship ship, AppDbContext context)
        {
            var shipHull = await context.ShipHulls.FirstOrDefaultAsync(s => s.Id == ship.ShipHullId);


            var shipByIdDTO = await context.Ships
                .Where(s => s.Id == ship.Id)
                .Select(s => new ShipByIdDTO
                {
                    Id = s.Id,
                    ImoNumber = s.ImoNumber,
                    ShipName = s.ShipName,
                    ShipTypeName = context.ShipTypes
                            .FirstOrDefault(st => st.Id == s.ShipTypeId) != null ? context.ShipTypes
                            .First(st => st.Id == s.ShipTypeId).ShipTypeName : null,
                    DateOfBuild = s.DateOfBuild,
                    StatusName = context.Statuses
                            .FirstOrDefault(st => st.Id == s.StatusId) != null ? context.Statuses
                            .First(st => st.Id == s.StatusId).StatusName : null,
                    GrossTonnage = s.GrossTonnage,
                    SummerDeadweight = s.SummerDeadweight,
                    NetTonnage = s.NetTonnage,
                    ShipFlag = context.ShipFlags
                            .FirstOrDefault(sf => sf.Id == s.ShipFlagId) != null ? context.ShipFlags
                            .First(sf => sf.Id == s.ShipFlagId).ShipFlagName : null,
                    CallSign = s.CallSign,
                    ClassSociety = context.ClassSocieties
                            .FirstOrDefault(cs => cs.Id == s.ClassSocietyId) != null ? context.ClassSocieties
                            .First(cs => cs.Id == s.ClassSocietyId).ClassSocietyName : null,
                    ShipPowerPlantType = context.ShipPowerPlantTypes
                            .FirstOrDefault(sppt => sppt.Id == s.ShipPowerPlantTypeId) != null ? context.ShipPowerPlantTypes
                            .First(sppt => sppt.Id == s.ShipPowerPlantTypeId).ShipPowerPlantTypeName : null,
                    ShipPropulsorType = context.ShipPropulsorTypes
                            .FirstOrDefault(spt => spt.Id == s.ShipPropulsorTypeId) != null ? context.ShipPropulsorTypes
                            .First(spt => spt.Id == s.ShipPropulsorTypeId).ShipPropulsorTypeName : null,
                    MainEngineQuantity = s.MainEngineQuantity,
                    MainEngine = context.MainEngines
                        .FirstOrDefault(me => me.Id == s.MainEngineId) != null ? context.MainEngines
                        .First(me => me.Id == s.MainEngineId).MainEngineType : null,
                    AuxiliaryEngineQuantity = s.AuxiliaryEngineQuantity,
                    AuxiliaryEngine = context.AuxiliaryEngines
                        .FirstOrDefault(ae => ae.Id == s.AuxiliaryEngineId) != null ? context.AuxiliaryEngines
                        .First(ae => ae.Id == s.AuxiliaryEngineId).AuxiliaryEngineType : null,
                    GeneratorQuantity = s.GeneratorQuantity,
                    Generator = context.Generators
                        .FirstOrDefault(g => g.Id == s.GeneratorId) != null ? context.Generators
                        .First(g => g.Id == s.GeneratorId).GeneratorType : null,
                    ShipBuilder = context.ShipBuilders
                            .FirstOrDefault(sb => sb.Id == s.ShipBuilderId) != null ? context.ShipBuilders
                            .First(sb => sb.Id == s.ShipBuilderId).ShipBuilderName : null,
                    Owner = context.Owners
                            .FirstOrDefault(o => o.Id == s.OwnerId) != null ? context.Owners
                            .First(o => o.Id == s.OwnerId).OwnerName : null,
                    Operator = context.Operators
                            .FirstOrDefault(op => op.Id == s.OperatorId) != null ? context.Operators
                            .First(op => op.Id == s.OperatorId).OperatorName : null,

                    OverAllLength = shipHull.OverAllLength,
                    BetweenPerpendicularsLength = shipHull.BetweenPerpendicularsLength,
                    Breadth = shipHull.Breadth,
                    Depth = shipHull.Depth,
                    SummerDraught = shipHull.SummerDraught,
                    SummerFreeBoard = shipHull.SummerFreeBoard,
                    Lightship = shipHull.Lightship,
                    Displacement = shipHull.Displacement,
                    VolumeDisplacement = shipHull.VolumeDisplacement
                })
                .FirstOrDefaultAsync();

            return shipByIdDTO;
        }

    }
}