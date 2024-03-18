using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class GeneratorService
    {
        private readonly AppDbContext _context;

        public GeneratorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GeneratorDTO>> GetGeneratorsListAsync()
        {
            var generators = await _context.Generators.ToListAsync();

            if (generators == null || !generators.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Generators found");

            var generatorDTOs = new List<GeneratorDTO>();

            foreach (var generator in generators)
            {
                var generatorDTO = await GeneratorDTO.ToGeneratorDTOAsync(generator);
                generatorDTOs.Add(generatorDTO);
            }

            return generatorDTOs;
        }

        public async Task<GeneratorDTO> GetGeneratorByIdAsync(Guid id)
        {
            var generator = await _context.Generators.FindAsync(id);

            if (generator == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Generator found with ID {id}");

            var generatorDTO = await GeneratorDTO.ToGeneratorDTOAsync(generator);

            return generatorDTO;
        }

        public async Task<GeneratorDTO> CreateGeneratorAsync(CreateGeneratorDTO request)
        {
            var existingGenerator = await _context.Generators.FirstOrDefaultAsync(g => g.GeneratorType == request.GeneratorType);

            if (existingGenerator != null)
                throw new CustomException(CustomExceptionType.GeneratorAlreadyExists, $"Generator {request.GeneratorType} already exists.");

            var generatorManufacturer = await _context.GeneratorManufacturers.FindAsync(request.GeneratorManufacturerId);

            if (generatorManufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Generator Manufacturer found with ID {request.GeneratorManufacturerId}");

            var generatorDTO = await CreateGeneratorDTO.ToGeneratorAsync(request);

            _context.Generators.Add(generatorDTO);

            await _context.SaveChangesAsync();

            var generator = await _context.Generators.FindAsync(generatorDTO.Id);

            var createdGenerator = await GeneratorDTO.ToGeneratorDTOAsync(generator);

            return createdGenerator;
        }

        public async Task<GeneratorDTO> UpdateGeneratorAsync(Guid id, UpdateGeneratorDTO request)
        {
            var generator = await _context.Generators.FindAsync(id);

            if (generator == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Generator found with ID {id}");

            var generatorManufacturer = await _context.GeneratorManufacturers.FindAsync(request.GeneratorManufacturerId);

            if (generatorManufacturer == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Generator Manufacturer found with ID {request.GeneratorManufacturerId}");

            request.UpdateGenerator(generator, request);

            await _context.SaveChangesAsync();

            var updatedGeneratorEntity = await _context.Generators.FindAsync(id);

            var updatedGeneratorDTO = await GeneratorDTO.ToGeneratorDTOAsync(updatedGeneratorEntity);

            return updatedGeneratorDTO;
        }

        public async Task DeleteGeneratorAsync(Guid id)
        {
            var generator = await _context.Generators.FindAsync(id);

            if (generator == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Generator found with ID {id}");

            _context.Generators.Remove(generator);

            await _context.SaveChangesAsync();
        }
    }
}
