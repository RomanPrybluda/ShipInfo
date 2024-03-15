using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class StatusService
    {
        private readonly AppDbContext _context;

        public StatusService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StatusDTO>> GetStatusesListAsync()
        {
            var statuses = await _context.Statuses.ToListAsync();

            if (statuses == null || !statuses.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Statuses found");

            var statusDTOs = new List<StatusDTO>();

            foreach (var status in statuses)
            {
                var statusDTO = await StatusDTO.ToStatusDTOAsync(status);
                statusDTOs.Add(statusDTO);
            }

            return statusDTOs;
        }

        public async Task<StatusDTO> GetStatusByIdAsync(Guid id)
        {
            var status = await _context.Statuses.FindAsync(id);

            if (status == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Status found with ID {id}");

            var statusDTO = await StatusDTO.ToStatusDTOAsync(status);

            return statusDTO;
        }

        public async Task<StatusDTO> CreateStatusAsync(CreateStatusDTO request)
        {
            var existingStatus = await _context.Statuses.FirstOrDefaultAsync(st => st.StatusName == request.StatusName);

            if (existingStatus != null)
                throw new CustomException(CustomExceptionType.StatusAlreadyExists, $"Status {request.StatusName} already exists.");

            var statusDTO = await CreateStatusDTO.ToStatusAsync(request);

            _context.Statuses.Add(statusDTO);

            await _context.SaveChangesAsync();

            var status = await _context.Statuses.FindAsync(statusDTO.Id);

            var createdStatus = await StatusDTO.ToStatusDTOAsync(status);

            return createdStatus;
        }

        public async Task<StatusDTO> UpdateStatusAsync(Guid id, UpdateStatusDTO request)
        {
            var status = await _context.Statuses.FindAsync(id);

            if (status == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Status found with ID {id}");

            request.UpdateStatus(status, request);

            await _context.SaveChangesAsync();

            var updatedStatusEntity = await _context.Statuses.FindAsync(id);

            var updatedStatusDTO = await StatusDTO.ToStatusDTOAsync(updatedStatusEntity);

            return updatedStatusDTO;
        }

        public async Task DeleteStatusAsync(Guid id)
        {
            var status = await _context.Statuses.FindAsync(id);

            if (status == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Status found with ID {id}");

            _context.Statuses.Remove(status);

            await _context.SaveChangesAsync();
        }
    }
}
