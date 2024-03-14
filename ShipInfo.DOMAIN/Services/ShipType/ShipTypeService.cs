using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipTypeService
    {
        private readonly AppDbContext _context;

        public ShipTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShipTypeDTO>> GetShipTypesListAsync()
        {
            var shipTypes = await _context.ShipTypes.ToListAsync();

            if (shipTypes == null || !shipTypes.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Ship Types found");

            var shipTypeDTOs = new List<ShipTypeDTO>();

            foreach (var shipType in shipTypes)
            {
                var shipTypeDTO = await ShipTypeDTO.ToShipTypeDTOAsync(shipType);
                shipTypeDTOs.Add(shipTypeDTO);
            }

            return shipTypeDTOs;
        }

        public async Task<ShipTypeDTO> GetShipTypeByIdAsync(Guid id)
        {
            var shipType = await _context.ShipTypes.FindAsync(id);

            if (shipType == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Type found with ID {id}");

            var shipTypeDTO = await ShipTypeDTO.ToShipTypeDTOAsync(shipType);

            return shipTypeDTO;
        }

        public async Task<ShipTypeDTO> CreateShipTypeAsync(CreateShipTypeDTO request)
        {
            var existingShipType = await _context.ShipTypes.FirstOrDefaultAsync(st => st.ShipTypeName == request.ShipTypeName);

            if (existingShipType != null)
                throw new CustomException(CustomExceptionType.ShipTypeAlreadyExists, $"Ship Type {request.ShipTypeName} already exists.");

            var shipTypeDTO = await CreateShipTypeDTO.ToShipTypeAsync(request);

            _context.ShipTypes.Add(shipTypeDTO);

            await _context.SaveChangesAsync();

            var shipType = await _context.ShipTypes.FindAsync(shipTypeDTO.Id);

            var createdShipType = await ShipTypeDTO.ToShipTypeDTOAsync(shipType);

            return createdShipType;
        }

        public async Task<ShipTypeDTO> UpdateShipTypeAsync(Guid id, UpdateShipTypeDTO request)
        {
            var shipType = await _context.ShipTypes.FindAsync(id);

            if (shipType == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Type found with ID {id}");

            request.UpdateShipType(shipType, request);

            await _context.SaveChangesAsync();

            var updatedShipTypeEntity = await _context.ShipTypes.FindAsync(id);

            var updatedShipTypeDTO = await ShipTypeDTO.ToShipTypeDTOAsync(updatedShipTypeEntity);

            return updatedShipTypeDTO;
        }

        public async Task DeleteShipTypeAsync(Guid id)
        {
            var shipType = await _context.ShipTypes.FindAsync(id);

            if (shipType == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Type found with ID {id}");

            _context.ShipTypes.Remove(shipType);

            await _context.SaveChangesAsync();
        }
    }
}