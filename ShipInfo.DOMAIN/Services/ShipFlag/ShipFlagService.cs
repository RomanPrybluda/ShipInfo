using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipFlagService
    {
        private readonly AppDbContext _context;

        public ShipFlagService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShipFlagDTO>> GetShipFlagsListAsync()
        {
            var shipFlags = await _context.ShipFlags.ToListAsync();

            if (shipFlags == null || !shipFlags.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Ship Flags found");

            var shipFlagDTOs = new List<ShipFlagDTO>();

            foreach (var shipFlag in shipFlags)
            {
                var shipFlagDTO = await ShipFlagDTO.ToShipFlagDTOAsync(shipFlag);
                shipFlagDTOs.Add(shipFlagDTO);
            }

            return shipFlagDTOs;
        }

        public async Task<ShipFlagDTO> GetShipFlagByIdAsync(Guid id)
        {
            var shipFlag = await _context.ShipFlags.FindAsync(id);

            if (shipFlag == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Flag found with ID {id}");

            var shipFlagDTO = await ShipFlagDTO.ToShipFlagDTOAsync(shipFlag);

            return shipFlagDTO;
        }

        public async Task<ShipFlagDTO> CreateShipFlagAsync(CreateShipFlagDTO request)
        {
            var existingShipFlag = await _context.ShipFlags.FirstOrDefaultAsync(sf => sf.ShipFlagName == request.ShipFlagName);

            if (existingShipFlag != null)
                throw new CustomException(CustomExceptionType.ShipFlagAlreadyExists, $"Ship Flag {request.ShipFlagName} already exists.");

            var shipFlagDTO = await CreateShipFlagDTO.ToShipFlagDTOAsync(request);

            _context.ShipFlags.Add(shipFlagDTO);

            await _context.SaveChangesAsync();

            var shipFlag = await _context.ShipFlags.FindAsync(shipFlagDTO.Id);

            var createdShipFlag = await ShipFlagDTO.ToShipFlagDTOAsync(shipFlag);

            return createdShipFlag;
        }

        public async Task<ShipFlagDTO> UpdateShipFlagAsync(Guid id, UpdateShipFlagDTO request)
        {
            var shipFlag = await _context.ShipFlags.FindAsync(id);

            if (shipFlag == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Flag found with ID {id}");

            request.UpdateShipFlag(shipFlag, request.ShipFlagName);

            await _context.SaveChangesAsync();

            var updatedShipFlagEntity = await _context.ShipFlags.FindAsync(id);

            var updatedShipFlagDTO = await ShipFlagDTO.ToShipFlagDTOAsync(updatedShipFlagEntity);

            return updatedShipFlagDTO;
        }

        public async Task DeleteShipFlagAsync(Guid id)
        {
            var shipFlag = await _context.ShipFlags.FindAsync(id);

            if (shipFlag == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Flag found with ID {id}");

            _context.ShipFlags.Remove(shipFlag);

            await _context.SaveChangesAsync();
        }
    }
}
