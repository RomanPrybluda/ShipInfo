using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class GeneratorManufacturerService
    {
        private readonly AppDbContext _context;

        public GeneratorManufacturerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GeneratorManufacturerDTO>> GetGeneratorManufacturersListAsync()
        {
            var generatorManufacturers = await _context.GeneratorManufacturers.ToListAsync();

            if (generatorManufacturers == null || !generatorManufacturers.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Generator Manufacturers found");

            var generatorManufacturerDTOs = new List<GeneratorManufacturerDTO>();

            foreach (var generatorManufacturer in generatorManufacturers)
            {
                var generatorManufacturerDTO = await GeneratorManufacturerDTO.ToGeneratorManufacturerDTOAsync(generatorManufacturer);
                generatorManufacturerDTOs.Add(generatorManufacturerDTO);
            }

            return generatorManufacturerDTOs;
        }

        public async Task<GeneratorManufacturerDTO> GetGeneratorManufacturerByIdAsync(Guid id)
        {
            var generatorManufacturer = await _context.GeneratorManufacturers.FindAsync(id);

            if (generatorManufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Generator Manufacturer found with ID {id}");

            var generatorManufacturerDTO = await GeneratorManufacturerDTO.ToGeneratorManufacturerDTOAsync(generatorManufacturer);

            return generatorManufacturerDTO;
        }

        public async Task<GeneratorManufacturerDTO> CreateGeneratorManufacturerAsync(CreateGeneratorManufacturerDTO request)
        {
            var existingGeneratorManufacturer = await _context.GeneratorManufacturers.FirstOrDefaultAsync(gm => gm.Name == request.Name);

            if (existingGeneratorManufacturer != null)
                throw new CustomException(CustomExceptionType.GeneratorManufacturerAlreadyExists, $"Generator Manufacturer {request.Name} already exists.");

            var generatorManufacturerDTO = await CreateGeneratorManufacturerDTO.ToGeneratorManufacturerAsync(request);

            _context.GeneratorManufacturers.Add(generatorManufacturerDTO);

            await _context.SaveChangesAsync();

            var generatorManufacturer = await _context.GeneratorManufacturers.FindAsync(generatorManufacturerDTO.Id);

            var createdGeneratorManufacturer = await GeneratorManufacturerDTO.ToGeneratorManufacturerDTOAsync(generatorManufacturer);

            return createdGeneratorManufacturer;
        }

        public async Task<GeneratorManufacturerDTO> UpdateGeneratorManufacturerAsync(Guid id, UpdateGeneratorManufacturerDTO request)
        {
            var generatorManufacturer = await _context.GeneratorManufacturers.FindAsync(id);

            if (generatorManufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Generator Manufacturer found with ID {id}");

            request.UpdateGeneratorManufacturer(generatorManufacturer, request.Name);

            await _context.SaveChangesAsync();

            var updatedGeneratorManufacturerEntity = await _context.GeneratorManufacturers.FindAsync(id);

            var updatedGeneratorManufacturerDTO = await GeneratorManufacturerDTO.ToGeneratorManufacturerDTOAsync(updatedGeneratorManufacturerEntity);

            return updatedGeneratorManufacturerDTO;
        }

        public async Task DeleteGeneratorManufacturerAsync(Guid id)
        {
            var generatorManufacturer = await _context.GeneratorManufacturers.FindAsync(id);

            if (generatorManufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Generator Manufacturer found with ID {id}");

            _context.GeneratorManufacturers.Remove(generatorManufacturer);

            await _context.SaveChangesAsync();
        }
    }
}
