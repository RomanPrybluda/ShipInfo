using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class AuxiliaryEngineService
    {
        private readonly AppDbContext _context;

        public AuxiliaryEngineService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuxiliaryEngineDTO>> GetAuxiliaryEnginesListAsync()
        {
            var auxiliaryEngines = await _context.AuxiliaryEngines.ToListAsync();

            if (auxiliaryEngines == null || !auxiliaryEngines.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Auxiliary Engines found");

            var auxiliaryEngineDTOs = new List<AuxiliaryEngineDTO>();

            foreach (var auxiliaryEngine in auxiliaryEngines)
            {
                var auxiliaryEngineDTO = await AuxiliaryEngineDTO.ToAuxiliaryEngineDTOAsync(auxiliaryEngine);
                auxiliaryEngineDTOs.Add(auxiliaryEngineDTO);
            }

            return auxiliaryEngineDTOs;
        }

        public async Task<AuxiliaryEngineDTO> GetAuxiliaryEngineByIdAsync(Guid id)
        {
            var auxiliaryEngine = await _context.AuxiliaryEngines.FindAsync(id);

            if (auxiliaryEngine == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Auxiliary Engine found with ID {id}");

            var auxiliaryEngineDTO = await AuxiliaryEngineDTO.ToAuxiliaryEngineDTOAsync(auxiliaryEngine);

            return auxiliaryEngineDTO;
        }

        public async Task<AuxiliaryEngineDTO> CreateAuxiliaryEngineAsync(CreateAuxiliaryEngineDTO request)
        {
            var existingAuxiliaryEngine = await _context.AuxiliaryEngines.FirstOrDefaultAsync(ae => ae.AuxiliaryEngineType == request.AuxiliaryEngineType);

            if (existingAuxiliaryEngine != null)
                throw new CustomException(CustomExceptionType.AuxiliaryEngineAlreadyExists, $"Auxiliary Engine {request.AuxiliaryEngineType} already exists.");

            var manufacturer = await _context.AuxiliaryEngineManufacturers.FindAsync(request.AuxiliaryEngineManufacturerId);

            if (manufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Auxiliary Engine Manufacturer found with ID {request.AuxiliaryEngineManufacturerId}");

            var auxiliaryEngineDTO = await CreateAuxiliaryEngineDTO.ToAuxiliaryEngineAsync(request);

            _context.AuxiliaryEngines.Add(auxiliaryEngineDTO);

            await _context.SaveChangesAsync();

            var auxiliaryEngine = await _context.AuxiliaryEngines.FindAsync(auxiliaryEngineDTO.Id);

            var createdAuxiliaryEngine = await AuxiliaryEngineDTO.ToAuxiliaryEngineDTOAsync(auxiliaryEngine);

            return createdAuxiliaryEngine;
        }

        public async Task<AuxiliaryEngineDTO> UpdateAuxiliaryEngineAsync(Guid id, UpdateAuxiliaryEngineDTO request)
        {
            var auxiliaryEngine = await _context.AuxiliaryEngines.FindAsync(id);

            if (auxiliaryEngine == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Auxiliary Engine found with ID {id}");

            var manufacturer = await _context.AuxiliaryEngineManufacturers.FindAsync(request.AuxiliaryEngineManufacturerId);

            if (manufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Auxiliary Engine Manufacturer found with ID {request.AuxiliaryEngineManufacturerId}");

            request.UpdateAuxiliaryEngine(auxiliaryEngine, request);

            await _context.SaveChangesAsync();

            var updatedAuxiliaryEngineEntity = await _context.AuxiliaryEngines.FindAsync(id);

            var updatedAuxiliaryEngineDTO = await AuxiliaryEngineDTO.ToAuxiliaryEngineDTOAsync(updatedAuxiliaryEngineEntity);

            return updatedAuxiliaryEngineDTO;
        }

        public async Task DeleteAuxiliaryEngineAsync(Guid id)
        {
            var auxiliaryEngine = await _context.AuxiliaryEngines.FindAsync(id);

            if (auxiliaryEngine == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Auxiliary Engine found with ID {id}");

            _context.AuxiliaryEngines.Remove(auxiliaryEngine);

            await _context.SaveChangesAsync();
        }
    }
}
