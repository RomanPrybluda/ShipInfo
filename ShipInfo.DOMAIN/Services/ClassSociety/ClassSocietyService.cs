using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ClassSocietyService
    {
        private readonly AppDbContext _context;

        public ClassSocietyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassSocietyDTO>> GetClassSocietiesListAsync()
        {
            var classSocieties = await _context.ClassSocieties.ToListAsync();

            if (classSocieties == null)
                throw new CustomException(CustomExceptionType.NotFound, "No Classification Society");

            var classSocietiesDTO = new List<ClassSocietyDTO>();

            foreach (var classSociety in classSocieties)
            {
                var classSocietyDTO = await ClassSocietyDTO.ToClassSocietyDTOAsync(classSociety);
                classSocietiesDTO.Add(classSocietyDTO);
            }

            return classSocietiesDTO;
        }

        public async Task<ClassSocietyDTO> GetClassSocietyByIdAsync(Guid id)
        {
            var classSociety = await _context.ClassSocieties.FindAsync(id);

            if (classSociety == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Classification Society with ID {id}");

            var classSocietyDTO = await ClassSocietyDTO.ToClassSocietyDTOAsync(classSociety);

            return classSocietyDTO;
        }

        public async Task<ClassSocietyDTO> CreateClassSocietyAsync(CreateClassSocietyDTO request)
        {
            var existingClassSociety = await _context.ClassSocieties.FirstOrDefaultAsync(cs => cs.ClassSocietyName == request.ClassSocietyName);

            if (existingClassSociety != null)
                throw new CustomException(CustomExceptionType.ClassSocietyAlreadyExist, $"Classification Society {request.ClassSocietyName} already exists.");

            var classSocietyDTO = await CreateClassSocietyDTO.ToClassSocietyAsync(request);

            _context.ClassSocieties.Add(classSocietyDTO);

            await _context.SaveChangesAsync();

            var classSociety = await _context.ClassSocieties.FindAsync(classSocietyDTO.Id);

            var createdClassSociety = await ClassSocietyDTO.ToClassSocietyDTOAsync(classSociety);

            return createdClassSociety;
        }

        public async Task<ClassSocietyDTO> UpdateClassSocietyAsync(Guid id, UpdateClassSocietyDTO request)
        {
            var classSociety = await _context.ClassSocieties.FindAsync(id);

            if (classSociety == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Classification Society with ID {id}");

            classSociety.ClassSocietyName = request.ClassSocietyName;
            classSociety.ClassSocietyCode = request.ClassSocietyCode;
            classSociety.ClassSocietyIsIACS = request.ClassSocietyIsIACS;

            await _context.SaveChangesAsync();

            var updatedClassSocietyEntity = await _context.ClassSocieties.FindAsync(id);

            var updatedClassSocietyDTO = await ClassSocietyDTO.ToClassSocietyDTOAsync(updatedClassSocietyEntity);

            return updatedClassSocietyDTO;
        }


        public async Task DeleteClassSocietyAsync(Guid id)
        {
            var classSociety = await _context.ClassSocieties.FindAsync(id);

            if (classSociety == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Classification Society with ID {id}");

            _context.ClassSocieties.Remove(classSociety);
            await _context.SaveChangesAsync();
        }
    }
}
