using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipService
    {
        private readonly AppDbContext _context;

        public ShipService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShipDTO>> GetShipsListAsync()
        {
            var ships = await _context.Ships
                .AsNoTracking()
                .Select(ship => new ShipDTO
                {
                    Id = ship.Id,
                    ImoNumber = ship.ImoNumber,
                    ShipName = ship.ShipName,
                    ShipTypeName = _context.ShipTypes.FirstOrDefault(st => st.Id == ship.ShipTypeId) != null
                                    ? _context.ShipTypes.FirstOrDefault(st => st.Id == ship.ShipTypeId).ShipTypeName
                                    : null,
                    DateOfBuild = ship.DateOfBuild,
                    StatusName = _context.Statuses.FirstOrDefault(st => st.Id == ship.StatusId) != null
                                    ? _context.Statuses.FirstOrDefault(st => st.Id == ship.StatusId).StatusName
                                    : null,
                    GrossTonnage = ship.GrossTonnage,
                    SummerDeadweight = ship.SummerDeadweight,
                    ShipFlagName = _context.ShipFlags.FirstOrDefault(sf => sf.Id == ship.ShipFlagId) != null
                                    ? _context.ShipFlags.FirstOrDefault(sf => sf.Id == ship.ShipFlagId).ShipFlagName
                                    : null,
                })
                .ToListAsync();

            if (ships == null)
                throw new CustomException(CustomExceptionType.NotFound, "No ships");

            return ships;
        }

        public async Task<ShipByIdDTO> GetShipByIdAsync(Guid id)
        {
            var shipById = await _context.Ships
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(ship => new ShipByIdDTO
                {
                    Id = ship.Id,
                    ImoNumber = ship.ImoNumber,
                    ShipName = ship.ShipName,
                    ShipTypeName = _context.ShipTypes.FirstOrDefault(st => st.Id == ship.ShipTypeId) != null
                                    ? _context.ShipTypes.FirstOrDefault(st => st.Id == ship.ShipTypeId).ShipTypeName
                                    : null,
                    DateOfBuild = ship.DateOfBuild,
                    StatusName = _context.Statuses.FirstOrDefault(st => st.Id == ship.StatusId) != null
                                    ? _context.Statuses.FirstOrDefault(st => st.Id == ship.StatusId).StatusName
                                    : null,
                    GrossTonnage = ship.GrossTonnage,
                    SummerDeadweight = ship.SummerDeadweight,
                    ShipFlagName = _context.ShipFlags.FirstOrDefault(sf => sf.Id == ship.ShipFlagId) != null
                                    ? _context.ShipFlags.FirstOrDefault(sf => sf.Id == ship.ShipFlagId).ShipFlagName
                                    : null,
                    NetTonnage = ship.NetTonnage,
                    CallSign = ship.CallSign,
                    ClassSociety = _context.ClassSocieties.FirstOrDefault(cs => cs.Id == ship.ClassSocietyId) != null
                                    ? _context.ClassSocieties.FirstOrDefault(cs => cs.Id == ship.ClassSocietyId).ClassSocietyName
                                    : null,
                    ShipPowerPlantType = _context.ShipPowerPlantTypes.FirstOrDefault(sp => sp.Id == ship.ShipPowerPlantTypeId) != null
                                    ? _context.ShipPowerPlantTypes.FirstOrDefault(sp => sp.Id == ship.ShipPowerPlantTypeId).ShipPowerPlantTypeName
                                    : null,
                    ShipPropulsorType = _context.ShipPropulsorTypes.FirstOrDefault(sp => sp.Id == ship.ShipPropulsorTypeId) != null
                                    ? _context.ShipPropulsorTypes.FirstOrDefault(sp => sp.Id == ship.ShipPropulsorTypeId).ShipPropulsorTypeName
                                    : null,
                    MainEngineQuantity = ship.MainEngineQuantity,
                    MainEngine = _context.MainEngines.FirstOrDefault(me => me.Id == ship.MainEngineId) != null
                                    ? _context.MainEngines.FirstOrDefault(me => me.Id == ship.MainEngineId).MainEngineType
                                    : null,
                    AuxiliaryEngineQuantity = ship.AuxiliaryEngineQuantity,
                    AuxiliaryEngine = _context.AuxiliaryEngines.FirstOrDefault(ae => ae.Id == ship.AuxiliaryEngineId) != null
                                    ? _context.AuxiliaryEngines.FirstOrDefault(ae => ae.Id == ship.AuxiliaryEngineId).AuxiliaryEngineType
                                    : null,
                    GeneratorQuantity = ship.GeneratorQuantity,
                    Generator = _context.Generators.FirstOrDefault(gen => gen.Id == ship.GeneratorId) != null
                                    ? _context.Generators.FirstOrDefault(gen => gen.Id == ship.GeneratorId).GeneratorType
                                    : null,
                    ShipBuilder = _context.ShipBuilders.FirstOrDefault(sb => sb.Id == ship.ShipBuilderId) != null
                                    ? _context.ShipBuilders.FirstOrDefault(sb => sb.Id == ship.ShipBuilderId).ShipBuilderName
                                    : null,
                    Owner = _context.Owners.FirstOrDefault(own => own.Id == ship.OwnerId) != null
                                    ? _context.Owners.FirstOrDefault(own => own.Id == ship.OwnerId).OwnerName
                                    : null,
                    Operator = _context.Operators.FirstOrDefault(op => op.Id == ship.OperatorId) != null
                                    ? _context.Operators.FirstOrDefault(op => op.Id == ship.OperatorId).OperatorName
                                    : null,
                    OverAllLength = ship.OverAllLength,
                    BetweenPerpendicularsLength = ship.BetweenPerpendicularsLength,
                    Breadth = ship.Breadth,
                    Depth = ship.Depth,
                    SummerDraught = ship.SummerDraught,
                    SummerFreeBoard = ship.SummerFreeBoard,
                    Lightship = ship.Lightship,
                    Displacement = ship.Displacement,
                    VolumeDisplacement = ship.VolumeDisplacement,
                })
                .FirstOrDefaultAsync();


            if (shipById == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No shipById with ID {id}");

            return shipById;
        }

        public async Task<ShipDTO> CreateShipAsync(CreateShipDTO request)
        {

            var shipByImoNumber = await _context.Ships.FirstOrDefaultAsync(ship => ship.ImoNumber == request.ImoNumber);

            if (shipByImoNumber != null)
                throw new CustomException(CustomExceptionType.ShipAlreadyExist, $"Ship with IMO number {request.ImoNumber} already exists.");

            var shipTypeById = await _context.ShipTypes.FindAsync(request.ShipTypeId);

            if (shipTypeById == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Type found with ID {request.ShipTypeId}");

            var statusById = await _context.Statuses.FindAsync(request.StatusId);

            if (statusById == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Status found with ID {request.StatusId}");

            var ship = CreateShipDTO.CreateShipDTOToShip(request);

            _context.Ships.Add(ship);

            await _context.SaveChangesAsync();

            var createdShip = await _context.Ships.FindAsync(ship.Id);

            var shipDTO = ShipDTO.ShipToShipDTO(createdShip, _context);

            return shipDTO;
        }


        public async Task<ShipByIdDTO> UpdateShipAsync(Guid id, UpdateShipDTO request)
        {
            var ship = await _context.Ships.FindAsync(id);

            if (ship == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No shipById with ID {id}.");

            if (await _context.Ships.FirstOrDefaultAsync(x => x.ImoNumber == request.ImoNumber) != null)
                throw new CustomException(CustomExceptionType.ShipAlreadyExist, $"Ship with this IMO number {request.ImoNumber} already exists.");

            var shipType = await _context.ShipTypes.FindAsync(request.ShipTypeId);

            if (shipType == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Type found with ID {request.ShipTypeId}");

            var status = await _context.Statuses.FindAsync(request.StatusId);

            if (status == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Status found with ID {request.StatusId}");

            request.UpdateShip(ship, request);

            await _context.SaveChangesAsync();

            var updatedShipDTO = ShipByIdDTO.ToShipByIdDTOAsync(ship, _context);

            return updatedShipDTO;
        }

        public async Task DeleteShipAsync(Guid id)
        {
            var ship = await _context.Ships.FindAsync(id);

            if (ship is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No shipById with {id} id");

            _context.Ships.Remove(ship);
            await _context.SaveChangesAsync();
        }

    }
}
