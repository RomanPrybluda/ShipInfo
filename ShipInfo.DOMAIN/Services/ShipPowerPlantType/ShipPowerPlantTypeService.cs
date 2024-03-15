using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipPowerPlantTypeService
    {
        private readonly AppDbContext _context;

        public ShipPowerPlantTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShipPowerPlantTypeDTO>> GetShipPowerPlantTypesListAsync()
        {
            var shipPowerPlantTypes = await _context.ShipPowerPlantTypes.ToListAsync();

            if (shipPowerPlantTypes == null || !shipPowerPlantTypes.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Ship Power Plant Types found");

            var shipPowerPlantTypeDTOs = new List<ShipPowerPlantTypeDTO>();

            foreach (var shipPowerPlantType in shipPowerPlantTypes)
            {
                var shipPowerPlantTypeDTO = await ShipPowerPlantTypeDTO.ToShipPowerPlantTypeDTOAsync(shipPowerPlantType);
                shipPowerPlantTypeDTOs.Add(shipPowerPlantTypeDTO);
            }

            return shipPowerPlantTypeDTOs;
        }

        public async Task<ShipPowerPlantTypeDTO> GetShipPowerPlantTypeByIdAsync(Guid id)
        {
            var shipPowerPlantType = await _context.ShipPowerPlantTypes.FindAsync(id);

            if (shipPowerPlantType == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Power Plant Type found with ID {id}");

            var shipPowerPlantTypeDTO = await ShipPowerPlantTypeDTO.ToShipPowerPlantTypeDTOAsync(shipPowerPlantType);

            return shipPowerPlantTypeDTO;
        }

        public async Task<ShipPowerPlantTypeDTO> CreateShipPowerPlantTypeAsync(CreateShipPowerPlantTypeDTO request)
        {
            var existingShipPowerPlantType = await _context.ShipPowerPlantTypes.FirstOrDefaultAsync(st => st.ShipPowerPlantTypeName == request.ShipPowerPlantTypeName);

            if (existingShipPowerPlantType != null)
                throw new CustomException(CustomExceptionType.ShipPowerPlantTypeAlreadyExists, $"Ship Power Plant Type {request.ShipPowerPlantTypeName} already exists.");

            var shipPowerPlantTypeDTO = await CreateShipPowerPlantTypeDTO.ToShipPowerPlantTypeAsync(request);

            _context.ShipPowerPlantTypes.Add(shipPowerPlantTypeDTO);

            await _context.SaveChangesAsync();

            var shipPowerPlantType = await _context.ShipPowerPlantTypes.FindAsync(shipPowerPlantTypeDTO.Id);

            var createdShipPowerPlantType = await ShipPowerPlantTypeDTO.ToShipPowerPlantTypeDTOAsync(shipPowerPlantType);

            return createdShipPowerPlantType;
        }

        public async Task<ShipPowerPlantTypeDTO> UpdateShipPowerPlantTypeAsync(Guid id, UpdateShipPowerPlantTypeDTO request)
        {
            var shipPowerPlantType = await _context.ShipPowerPlantTypes.FindAsync(id);

            if (shipPowerPlantType == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Power Plant Type found with ID {id}");

            request.UpdateShipPowerPlantType(shipPowerPlantType, request);

            await _context.SaveChangesAsync();

            var updatedShipPowerPlantTypeEntity = await _context.ShipPowerPlantTypes.FindAsync(id);

            var updatedShipPowerPlantTypeDTO = await ShipPowerPlantTypeDTO.ToShipPowerPlantTypeDTOAsync(updatedShipPowerPlantTypeEntity);

            return updatedShipPowerPlantTypeDTO;
        }

        public async Task DeleteShipPowerPlantTypeAsync(Guid id)
        {
            var shipPowerPlantType = await _context.ShipPowerPlantTypes.FindAsync(id);

            if (shipPowerPlantType == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Power Plant Type found with ID {id}");

            _context.ShipPowerPlantTypes.Remove(shipPowerPlantType);

            await _context.SaveChangesAsync();
        }
    }
}
