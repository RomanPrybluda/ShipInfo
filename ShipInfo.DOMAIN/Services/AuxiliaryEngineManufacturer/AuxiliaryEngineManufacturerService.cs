using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class AuxiliaryEngineManufacturerService
    {
        private readonly AppDbContext _context;

        public AuxiliaryEngineManufacturerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuxiliaryEngineManufacturerDTO>> GetAuxiliaryEngineManufacturersListAsync()
        {
            var manufacturers = await _context.AuxiliaryEngineManufacturers.ToListAsync();

            if (manufacturers == null || !manufacturers.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Auxiliary Engine Manufacturers found");

            var manufacturerDTOs = new List<AuxiliaryEngineManufacturerDTO>();

            foreach (var manufacturer in manufacturers)
            {
                var manufacturerDTO = await AuxiliaryEngineManufacturerDTO.ToAuxiliaryEngineManufacturerDTOAsync(manufacturer);
                manufacturerDTOs.Add(manufacturerDTO);
            }

            return manufacturerDTOs;
        }

        public async Task<AuxiliaryEngineManufacturerDTO> GetAuxiliaryEngineManufacturerByIdAsync(Guid id)
        {
            var manufacturer = await _context.AuxiliaryEngineManufacturers.FindAsync(id);

            if (manufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Auxiliary Engine Manufacturer found with ID {id}");

            var manufacturerDTO = await AuxiliaryEngineManufacturerDTO.ToAuxiliaryEngineManufacturerDTOAsync(manufacturer);

            return manufacturerDTO;
        }

        public async Task<AuxiliaryEngineManufacturerDTO> CreateAuxiliaryEngineManufacturerAsync(CreateAuxiliaryEngineManufacturerDTO request)
        {
            var existingManufacturer = await _context.AuxiliaryEngineManufacturers.FirstOrDefaultAsync(m => m.Name == request.Name);

            if (existingManufacturer != null)
                throw new CustomException(CustomExceptionType.AuxiliaryEngineManufacturerAlreadyExists, $"Auxiliary Engine Manufacturer {request.Name} already exists.");

            var manufacturerDTO = await CreateAuxiliaryEngineManufacturerDTO.ToAuxiliaryEngineManufacturerAsync(request);

            _context.AuxiliaryEngineManufacturers.Add(manufacturerDTO);

            await _context.SaveChangesAsync();

            var manufacturer = await _context.AuxiliaryEngineManufacturers.FindAsync(manufacturerDTO.Id);

            var createdManufacturer = await AuxiliaryEngineManufacturerDTO.ToAuxiliaryEngineManufacturerDTOAsync(manufacturer);

            return createdManufacturer;
        }

        public async Task<AuxiliaryEngineManufacturerDTO> UpdateAuxiliaryEngineManufacturerAsync(Guid id, UpdateAuxiliaryEngineManufacturerDTO request)
        {
            var manufacturer = await _context.AuxiliaryEngineManufacturers.FindAsync(id);

            if (manufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Auxiliary Engine Manufacturer found with ID {id}");

            request.UpdateAuxiliaryEngineManufacturer(manufacturer, request.Name);

            await _context.SaveChangesAsync();

            var updatedManufacturerEntity = await _context.AuxiliaryEngineManufacturers.FindAsync(id);

            var updatedManufacturerDTO = await AuxiliaryEngineManufacturerDTO.ToAuxiliaryEngineManufacturerDTOAsync(updatedManufacturerEntity);

            return updatedManufacturerDTO;
        }

        public async Task DeleteAuxiliaryEngineManufacturerAsync(Guid id)
        {
            var manufacturer = await _context.AuxiliaryEngineManufacturers.FindAsync(id);

            if (manufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Auxiliary Engine Manufacturer found with ID {id}");

            _context.AuxiliaryEngineManufacturers.Remove(manufacturer);

            await _context.SaveChangesAsync();
        }
    }
}
