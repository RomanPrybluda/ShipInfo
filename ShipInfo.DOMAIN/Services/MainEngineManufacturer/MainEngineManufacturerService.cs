using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class MainEngineManufacturerService
    {
        private readonly AppDbContext _context;

        public MainEngineManufacturerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MainEngineManufacturerDTO>> GetMainEngineManufacturersListAsync()
        {
            var mainEngineManufacturers = await _context.MainEngineManufacturers.ToListAsync();

            if (mainEngineManufacturers == null || !mainEngineManufacturers.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Main Engine Manufacturers found");

            var mainEngineManufacturerDTOs = new List<MainEngineManufacturerDTO>();

            foreach (var manufacturer in mainEngineManufacturers)
            {
                var mainEngineManufacturerDTO = await MainEngineManufacturerDTO.ToMainEngineManufacturerDTOAsync(manufacturer);
                mainEngineManufacturerDTOs.Add(mainEngineManufacturerDTO);
            }

            return mainEngineManufacturerDTOs;
        }

        public async Task<MainEngineManufacturerDTO> GetMainEngineManufacturerByIdAsync(Guid id)
        {
            var manufacturer = await _context.MainEngineManufacturers.FindAsync(id);

            if (manufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Main Engine Manufacturer found with ID {id}");

            var mainEngineManufacturerDTO = await MainEngineManufacturerDTO.ToMainEngineManufacturerDTOAsync(manufacturer);

            return mainEngineManufacturerDTO;
        }

        public async Task<MainEngineManufacturerDTO> CreateMainEngineManufacturerAsync(CreateMainEngineManufacturerDTO request)
        {
            var existingManufacturer = await _context.MainEngineManufacturers.FirstOrDefaultAsync(m => m.MainEngineManufacturerName == request.MainEngineManufacturerName);

            if (existingManufacturer != null)
                throw new CustomException(CustomExceptionType.MainEngineManufacturerAlreadyExists, $"Main Engine Manufacturer {request.MainEngineManufacturerName} already exists.");

            var mainEngineManufacturerDTO = await CreateMainEngineManufacturerDTO.ToMainEngineManufacturerAsync(request);

            _context.MainEngineManufacturers.Add(mainEngineManufacturerDTO);

            await _context.SaveChangesAsync();

            var manufacturer = await _context.MainEngineManufacturers.FindAsync(mainEngineManufacturerDTO.Id);

            var createdManufacturer = await MainEngineManufacturerDTO.ToMainEngineManufacturerDTOAsync(manufacturer);

            return createdManufacturer;
        }

        public async Task<MainEngineManufacturerDTO> UpdateMainEngineManufacturerAsync(Guid id, UpdateMainEngineManufacturerDTO request)
        {
            var manufacturer = await _context.MainEngineManufacturers.FindAsync(id);

            if (manufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Main Engine Manufacturer found with ID {id}");

            request.UpdateMainEngineManufacturer(manufacturer, request);

            await _context.SaveChangesAsync();

            var updatedManufacturerEntity = await _context.MainEngineManufacturers.FindAsync(id);

            var updatedManufacturerDTO = await MainEngineManufacturerDTO.ToMainEngineManufacturerDTOAsync(updatedManufacturerEntity);

            return updatedManufacturerDTO;
        }

        public async Task DeleteMainEngineManufacturerAsync(Guid id)
        {
            var manufacturer = await _context.MainEngineManufacturers.FindAsync(id);

            if (manufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Main Engine Manufacturer found with ID {id}");

            _context.MainEngineManufacturers.Remove(manufacturer);

            await _context.SaveChangesAsync();
        }
    }
}