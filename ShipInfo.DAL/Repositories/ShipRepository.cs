using Microsoft.EntityFrameworkCore;
using ShipInfo.Domain;
using ShipInfo.Domain.Abstractions;
using ShipInfo.Domain.Services.Ship.DTO;

namespace ShipInfo.DAL
{
    public class ShipRepository : IShipRepository
    {
        private readonly ShipInfoDbContext _context;

        public ShipRepository(ShipInfoDbContext context)
        {
            _context = context;
        }

        public async Task<ShipShortDetails> GetShipByIMONumberAsync(int imoNumber)
        {
            var ship = await _context.Ships.FirstAsync(s => s.ImoNumber == imoNumber);

            var shipType = await _context.ShipTypes
                                        .Where(st => st.Id == ship.ShipTypeId)
                                        .Select(st => st.ShipTypeName)
                                        .FirstOrDefaultAsync();

            var shipFlag = await _context.ShipFlags
                                        .Where(sf => sf.Id == ship.ShipFlagId)
                                        .Select(sf => sf.ShipFlagName)
                                        .FirstOrDefaultAsync();

            var shipShortDetails = new ShipShortDetails
            {
                Id = ship.Id,
                ImoNumber = ship.ImoNumber,
                ShipName = ship.ShipName,
                DateOfBuild = ship.DateOfBuild,
                GrossTonnage = ship.GrossTonnage,
                ShipTypeName = shipType ?? string.Empty,
                ShipFlagName = shipFlag ?? string.Empty,
            };

            return shipShortDetails;
        }

        public async Task<ShipShortDetails> GetShipByNameAsync(string shipName)
        {
            var ship = await _context.Ships.FirstAsync(s => s.ShipName == shipName);

            var shipType = await _context.ShipTypes
                                        .Where(st => st.Id == ship.ShipTypeId)
                                        .Select(st => st.ShipTypeName)
                                        .FirstOrDefaultAsync();

            var shipFlag = await _context.ShipFlags
                                        .Where(sf => sf.Id == ship.ShipFlagId)
                                        .Select(sf => sf.ShipFlagName)
                                        .FirstOrDefaultAsync();

            var shipShortDetails = new ShipShortDetails
            {
                Id = ship.Id,
                ImoNumber = ship.ImoNumber,
                ShipName = ship.ShipName,
                DateOfBuild = ship.DateOfBuild,
                GrossTonnage = ship.GrossTonnage,
                ShipTypeName = shipType ?? string.Empty,
                ShipFlagName = shipFlag ?? string.Empty,
            };

            return shipShortDetails;
        }

        public async Task<ShipAllDetails> GetShipByIdAsync(Guid shipId)
        {
            var ship = await _context.Ships.FirstAsync(s => s.Id == shipId);

            var shipType = await _context.ShipTypes
                            .Where(st => st.Id == ship.ShipTypeId)
                            .Select(st => st.ShipTypeName)
                            .FirstOrDefaultAsync();

            var shipFlag = await _context.ShipFlags
                            .Where(sf => sf.Id == ship.ShipFlagId)
                            .Select(sf => sf.ShipFlagName)
                            .FirstOrDefaultAsync();

            var shipStatus = await _context.Statuses
                            .Where(sf => sf.Id == ship.StatusId)
                            .Select(sf => sf.StatusName)
                            .FirstOrDefaultAsync();

            var shipClassSociety = await _context.ClassSocieties
                            .Where(sf => sf.Id == ship.ClassSocietyId)
                            .Select(sf => sf.ClassSocietyName)
                            .FirstOrDefaultAsync();

            var shipPropulsorType = await _context.ShipPropulsorTypes
                            .Where(sf => sf.Id == ship.ShipPropulsorTypeId)
                            .Select(sf => sf.ShipPropulsorTypeName)
                            .FirstOrDefaultAsync();

            var shipShipPowerPlantType = await _context.ShipPowerPlantTypes
                            .Where(sf => sf.Id == ship.ShipPowerPlantTypeId)
                            .Select(sf => sf.ShipPowerPlantTypeName)
                            .FirstOrDefaultAsync();

            var shipMainEngine = await _context.MainEngines
                            .Where(sf => sf.Id == ship.MainEngineId)
                            .Select(sf => sf.MainEngineType)
                            .FirstOrDefaultAsync();

            var shipAuxiliaryEngine = await _context.AuxiliaryEngines
                            .Where(sf => sf.Id == ship.AuxiliaryEngineId)
                            .Select(sf => sf.AuxiliaryEngineType)
                            .FirstOrDefaultAsync();

            var shipGenerator = await _context.Generators
                            .Where(sf => sf.Id == ship.GeneratorId)
                            .Select(sf => sf.GeneratorType)
                            .FirstOrDefaultAsync();

            var shipShipBuilder = await _context.ShipBuilders
                            .Where(sf => sf.Id == ship.ShipBuilderId)
                            .Select(sf => sf.ShipBuilderName)
                            .FirstOrDefaultAsync();

            var shipOwner = await _context.Owners
                            .Where(sf => sf.Id == ship.OwnerId)
                            .Select(sf => sf.OwnerName)
                            .FirstOrDefaultAsync();

            var shipOperator = await _context.Operators
                            .Where(sf => sf.Id == ship.OperatorId)
                            .Select(sf => sf.OperatorName)
                            .FirstOrDefaultAsync();


            var shipAllDetails = new ShipAllDetails
            {
                Id = ship.Id,
                ImoNumber = ship.ImoNumber,
                ShipName = ship.ShipName,
                OverAllLength = ship.OverAllLength,
                BetweenPerpendicularsLength = ship.BetweenPerpendicularsLength,
                Breadth = ship.Breadth,
                Depth = ship.Depth,
                SummerDraught = ship.SummerDraught,
                SummerFreeBoard = ship.SummerFreeBoard,
                Lightship = ship.Lightship,
                Displacement = ship.Displacement,
                VolumeDisplacement = ship.VolumeDisplacement,
                ShipTypeName = shipType ?? string.Empty,
                DateOfBuild = ship.DateOfBuild,
                StatusName = shipStatus ?? string.Empty,
                GrossTonnage = ship.GrossTonnage,
                SummerDeadweight = ship.SummerDeadweight,
                NetTonnage = ship.NetTonnage,
                ShipFlag = shipFlag ?? string.Empty,
                CallSign = ship.CallSign,
                ClassSociety = shipClassSociety ?? string.Empty,
                ShipPowerPlantType = shipShipPowerPlantType ?? string.Empty,
                ShipPropulsorType = shipPropulsorType ?? string.Empty,
                MainEngineQuantity = ship.MainEngineQuantity,
                MainEngine = shipMainEngine ?? string.Empty,
                AuxiliaryEngineQuantity = ship.AuxiliaryEngineQuantity,
                AuxiliaryEngine = shipAuxiliaryEngine ?? string.Empty,
                GeneratorQuantity = ship.GeneratorQuantity,
                Generator = shipGenerator ?? string.Empty,
                ShipBuilder = shipShipBuilder ?? string.Empty,
                Owner = shipOwner ?? string.Empty,
                Operator = shipOperator ?? string.Empty,
            };

            return shipAllDetails;

        }

        public async Task<PaginatedList> GetShipsByParamsAsync(ShipSearchCriteria criteria, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<ShipShortDetails> CreateShipAsync(CreateShipDTO ship)
        {
            throw new NotImplementedException();
        }

        public Task<ShipShortDetails> UpdateShipAsync(UpdateShipDTO ship)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteShipAsync(Guid shipId)
        {
            throw new NotImplementedException();
        }
    }
}
