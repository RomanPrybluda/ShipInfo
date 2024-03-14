using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class OwnerService
    {
        private readonly AppDbContext _context;

        public OwnerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OwnerDTO>> GetOwnersListAsync()
        {
            var owners = await _context.Owners.ToListAsync();

            if (owners == null || !owners.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Owners found");

            var ownerDTOs = new List<OwnerDTO>();

            foreach (var owner in owners)
            {
                var ownerDTO = await OwnerDTO.ToOwnerDTOAsync(owner);
                ownerDTOs.Add(ownerDTO);
            }

            return ownerDTOs;
        }

        public async Task<OwnerDTO> GetOwnerByIdAsync(Guid id)
        {
            var owner = await _context.Owners.FindAsync(id);

            if (owner == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Owner found with ID {id}");

            var ownerDTO = await OwnerDTO.ToOwnerDTOAsync(owner);

            return ownerDTO;
        }

        public async Task<OwnerDTO> CreateOwnerAsync(CreateOwnerDTO request)
        {
            var existingOwner = await _context.Owners.FirstOrDefaultAsync(o => o.OwnerName == request.Name);

            if (existingOwner != null)
                throw new CustomException(CustomExceptionType.OwnerAlreadyExists, $"Owner {request.Name} already exists.");

            var ownerDTO = await CreateOwnerDTO.ToOwnerAsync(request);

            _context.Owners.Add(ownerDTO);

            await _context.SaveChangesAsync();

            var owner = await _context.Owners.FindAsync(ownerDTO.Id);

            var createdOwner = await OwnerDTO.ToOwnerDTOAsync(owner);

            return createdOwner;
        }

        public async Task<OwnerDTO> UpdateOwnerAsync(Guid id, UpdateOwnerDTO request)
        {
            var owner = await _context.Owners.FindAsync(id);

            if (owner == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Owner found with ID {id}");

            request.UpdateOwner(owner, request.Name);

            await _context.SaveChangesAsync();

            var updatedOwnerEntity = await _context.Owners.FindAsync(id);

            var updatedOwnerDTO = await OwnerDTO.ToOwnerDTOAsync(updatedOwnerEntity);

            return updatedOwnerDTO;
        }

        public async Task DeleteOwnerAsync(Guid id)
        {
            var owner = await _context.Owners.FindAsync(id);

            if (owner == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Owner found with ID {id}");

            _context.Owners.Remove(owner);

            await _context.SaveChangesAsync();
        }
    }
}
