using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipPropulsorTypeService
    {
        private readonly AppDbContext _context;

        public ShipPropulsorTypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShipPropulsorTypeDTO>> GetShipPropulsorTypesListAsync()
        {
            var shipPropulsorTypes = await _context.ShipPropulsorTypes.ToListAsync();

            if (shipPropulsorTypes == null || !shipPropulsorTypes.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Ship Propulsor Types found");

            var shipPropulsorTypeDTOs = new List<ShipPropulsorTypeDTO>();

            foreach (var shipPropulsorType in shipPropulsorTypes)
            {
                var shipPropulsorTypeDTO = await ShipPropulsorTypeDTO.ToShipPropulsorTypeDTOAsync(shipPropulsorType);
                shipPropulsorTypeDTOs.Add(shipPropulsorTypeDTO);
            }

            return shipPropulsorTypeDTOs;
        }

        public async Task<ShipPropulsorTypeDTO> GetShipPropulsorTypeByIdAsync(Guid id)
        {
            var shipPropulsorType = await _context.ShipPropulsorTypes.FindAsync(id);

            if (shipPropulsorType == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Propulsor Type found with ID {id}");

            var shipPropulsorTypeDTO = await ShipPropulsorTypeDTO.ToShipPropulsorTypeDTOAsync(shipPropulsorType);

            return shipPropulsorTypeDTO;
        }

        public async Task<ShipPropulsorTypeDTO> CreateShipPropulsorTypeAsync(CreateShipPropulsorTypeDTO request)
        {
            var existingShipPropulsorType = await _context.ShipPropulsorTypes.FirstOrDefaultAsync(st => st.PropulsorTypeName == request.PropulsorTypeName);

            if (existingShipPropulsorType != null)
                throw new CustomException(CustomExceptionType.ShipPropulsorTypeAlreadyExists, $"Ship Propulsor Type {request.PropulsorTypeName} already exists.");

            var shipPropulsorTypeDTO = await CreateShipPropulsorTypeDTO.ToShipPropulsorTypeAsync(request);

            _context.ShipPropulsorTypes.Add(shipPropulsorTypeDTO);

            await _context.SaveChangesAsync();

            var shipPropulsorType = await _context.ShipPropulsorTypes.FindAsync(shipPropulsorTypeDTO.Id);

            var createdShipPropulsorType = await ShipPropulsorTypeDTO.ToShipPropulsorTypeDTOAsync(shipPropulsorType);

            return createdShipPropulsorType;
        }

        public async Task<ShipPropulsorTypeDTO> UpdateShipPropulsorTypeAsync(Guid id, UpdateShipPropulsorTypeDTO request)
        {
            var shipPropulsorType = await _context.ShipPropulsorTypes.FindAsync(id);

            if (shipPropulsorType == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Propulsor Type found with ID {id}");

            request.UpdateShipPropulsorType(shipPropulsorType, request.PropulsorTypeName);

            await _context.SaveChangesAsync();

            var updatedShipPropulsorTypeEntity = await _context.ShipPropulsorTypes.FindAsync(id);

            var updatedShipPropulsorTypeDTO = await ShipPropulsorTypeDTO.ToShipPropulsorTypeDTOAsync(updatedShipPropulsorTypeEntity);

            return updatedShipPropulsorTypeDTO;
        }

        public async Task DeleteShipPropulsorTypeAsync(Guid id)
        {
            var shipPropulsorType = await _context.ShipPropulsorTypes.FindAsync(id);

            if (shipPropulsorType == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Propulsor Type found with ID {id}");

            _context.ShipPropulsorTypes.Remove(shipPropulsorType);

            await _context.SaveChangesAsync();
        }
    }
}
