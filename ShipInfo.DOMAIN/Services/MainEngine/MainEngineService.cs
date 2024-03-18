using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class MainEngineService
    {
        private readonly AppDbContext _context;

        public MainEngineService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MainEngineDTO>> GetMainEnginesListAsync()
        {
            var mainEngines = await _context.MainEngines.ToListAsync();

            if (mainEngines == null || !mainEngines.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Main Engines found");

            var mainEngineDTOs = new List<MainEngineDTO>();

            foreach (var mainEngine in mainEngines)
            {
                var mainEngineDTO = MainEngineDTO.ToMainEngineDTOAsync(mainEngine);
                mainEngineDTOs.Add(mainEngineDTO);
            }

            return mainEngineDTOs;
        }

        public async Task<MainEngineDTO> GetMainEngineByIdAsync(Guid id)
        {
            var mainEngine = await _context.MainEngines.FindAsync(id);

            if (mainEngine == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Main Engine found with ID {id}");

            var mainEngineDTO = MainEngineDTO.ToMainEngineDTOAsync(mainEngine);

            return mainEngineDTO;
        }

        public async Task<MainEngineDTO> CreateMainEngineAsync(CreateMainEngineDTO request)
        {
            var existingMainEngine = await _context.MainEngines.FirstOrDefaultAsync(me => me.MainEngineType == request.MainEngineType);

            if (existingMainEngine != null)
                throw new CustomException(CustomExceptionType.MainEngineAlreadyExists, $"Main Engine {request.MainEngineType} already exists.");

            var manufacturer = await _context.MainEngineManufacturers.FindAsync(request.MainEngineManufacturerId);

            if (manufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Main Engine Manufacturer found with ID {request.MainEngineManufacturerId}");

            var mainEngineDTO = CreateMainEngineDTO.ToMainEngineAsync(request);

            _context.MainEngines.Add(mainEngineDTO);

            await _context.SaveChangesAsync();

            var mainEngine = await _context.MainEngines.FindAsync(mainEngineDTO.Id);

            var createdMainEngine = MainEngineDTO.ToMainEngineDTOAsync(mainEngine);

            return createdMainEngine;
        }

        public async Task<MainEngineDTO> UpdateMainEngineAsync(Guid id, UpdateMainEngineDTO request)
        {
            var mainEngine = await _context.MainEngines.FindAsync(id);

            if (mainEngine == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Main Engine found with ID {id}");

            var manufacturer = await _context.MainEngineManufacturers.FindAsync(request.MainEngineManufacturerId);

            if (manufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Main Engine Manufacturer found with ID {request.MainEngineManufacturerId}");

            request.UpdateMainEngine(mainEngine, request);

            await _context.SaveChangesAsync();

            var updatedMainEngineEntity = await _context.MainEngines.FindAsync(id);

            var updatedMainEngineDTO = MainEngineDTO.ToMainEngineDTOAsync(updatedMainEngineEntity);

            return updatedMainEngineDTO;
        }

        public async Task DeleteMainEngineAsync(Guid id)
        {
            var mainEngine = await _context.MainEngines.FindAsync(id);

            if (mainEngine == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Main Engine found with ID {id}");

            _context.MainEngines.Remove(mainEngine);

            await _context.SaveChangesAsync();
        }
    }
}
