using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipBuilderService
    {
        private readonly AppDbContext _context;

        public ShipBuilderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShipBuilderDTO>> GetShipBuildersListAsync()
        {
            var shipBuilders = await _context.ShipBuilders.ToListAsync();

            if (shipBuilders == null || !shipBuilders.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No ShipBuilders found");

            var shipBuilderDTOs = new List<ShipBuilderDTO>();

            foreach (var shipBuilder in shipBuilders)
            {
                var shipBuilderDTO = await ShipBuilderDTO.ToShipBuilderDTOAsync(shipBuilder);
                shipBuilderDTOs.Add(shipBuilderDTO);
            }

            return shipBuilderDTOs;
        }

        public async Task<ShipBuilderDTO> GetShipBuilderByIdAsync(Guid id)
        {
            var shipBuilder = await _context.ShipBuilders.FindAsync(id);

            if (shipBuilder == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No ShipBuilder found with ID {id}");

            var shipBuilderDTO = await ShipBuilderDTO.ToShipBuilderDTOAsync(shipBuilder);

            return shipBuilderDTO;
        }

        public async Task<ShipBuilderDTO> CreateShipBuilderAsync(CreateShipBuilderDTO request)
        {
            var existingShipBuilder = await _context.ShipBuilders.FirstOrDefaultAsync(sb => sb.ShipBuilderName == request.ShipBuilderName);

            if (existingShipBuilder != null)
                throw new CustomException(CustomExceptionType.ShipBuilderAlreadyExists, $"ShipBuilder {request.ShipBuilderName} already exists.");

            var shipBuilderDTO = await CreateShipBuilderDTO.ToShipBuilderAsync(request);

            _context.ShipBuilders.Add(shipBuilderDTO);

            await _context.SaveChangesAsync();

            var ShipBuilder = await _context.ShipBuilders.FindAsync(shipBuilderDTO.Id);

            var createdShipBuilder = await ShipBuilderDTO.ToShipBuilderDTOAsync(ShipBuilder);

            return createdShipBuilder;
        }

        public async Task<ShipBuilderDTO> UpdateShipBuilderAsync(Guid id, UpdateShipBuilderDTO request)
        {
            var shipBuilder = await _context.ShipBuilders.FindAsync(id);

            if (shipBuilder == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No ShipBuilder found with ID {id}");

            request.UpdateShipBuilder(shipBuilder, request);

            await _context.SaveChangesAsync();

            var updatedShipBuilderEntity = await _context.ShipBuilders.FindAsync(id);

            var updatedShipBuilderDTO = await ShipBuilderDTO.ToShipBuilderDTOAsync(updatedShipBuilderEntity);

            return updatedShipBuilderDTO;
        }

        public async Task DeleteShipBuilderAsync(Guid id)
        {
            var shipBuilder = await _context.ShipBuilders.FindAsync(id);

            if (shipBuilder == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No ShipBuilder found with ID {id}");

            _context.ShipBuilders.Remove(shipBuilder);

            await _context.SaveChangesAsync();
        }
    }
}
