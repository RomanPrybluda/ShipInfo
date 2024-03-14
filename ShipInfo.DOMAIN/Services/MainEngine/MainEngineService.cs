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
                var mainEngineDTO = await MainEngineDTO.ToMainEngineDTOAsync(mainEngine);
                mainEngineDTOs.Add(mainEngineDTO);
            }

            return mainEngineDTOs;
        }

        public async Task<MainEngineDTO> GetMainEngineByIdAsync(Guid id)
        {
            var mainEngine = await _context.MainEngines.FindAsync(id);

            if (mainEngine == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Main Engine found with ID {id}");

            var mainEngineDTO = await MainEngineDTO.ToMainEngineDTOAsync(mainEngine);

            return mainEngineDTO;
        }

        public async Task<MainEngineDTO> CreateMainEngineAsync(CreateMainEngineDTO request)
        {
            var existingMainEngine = await _context.MainEngines.FirstOrDefaultAsync(me => me.MainEngineType == request.Type);

            if (existingMainEngine != null)
                throw new CustomException(CustomExceptionType.MainEngineAlreadyExists, $"Main Engine {request.Type} already exists.");

            var mainEngineDTO = await CreateMainEngineDTO.ToMainEngineAsync(request);

            _context.MainEngines.Add(mainEngineDTO);

            await _context.SaveChangesAsync();

            var mainEngine = await _context.MainEngines.FindAsync(mainEngineDTO.Id);

            var createdMainEngine = await MainEngineDTO.ToMainEngineDTOAsync(mainEngine);

            return createdMainEngine;
        }

        public async Task<MainEngineDTO> UpdateMainEngineAsync(Guid id, UpdateMainEngineDTO request)
        {
            var mainEngine = await _context.MainEngines.FindAsync(id);

            if (mainEngine == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Main Engine found with ID {id}");

            request.UpdateMainEngine(mainEngine, request.Model);

            await _context.SaveChangesAsync();

            var updatedMainEngineEntity = await _context.MainEngines.FindAsync(id);

            var updatedMainEngineDTO = await MainEngineDTO.ToMainEngineDTOAsync(updatedMainEngineEntity);

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
