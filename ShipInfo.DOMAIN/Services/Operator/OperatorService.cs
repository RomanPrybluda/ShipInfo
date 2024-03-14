using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class OperatorService
    {
        private readonly AppDbContext _context;

        public OperatorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OperatorDTO>> GetOperatorsListAsync()
        {
            var operators = await _context.Operators.ToListAsync();

            if (operators == null || !operators.Any())
                throw new CustomException(CustomExceptionType.NotFound, "No Operators found");

            var operatorDTOs = new List<OperatorDTO>();

            foreach (var op in operators)
            {
                var operatorDTO = await OperatorDTO.ToOperatorDTOAsync(op);
                operatorDTOs.Add(operatorDTO);
            }

            return operatorDTOs;
        }

        public async Task<OperatorDTO> GetOperatorByIdAsync(Guid id)
        {
            var op = await _context.Operators.FindAsync(id);

            if (op == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Operator found with ID {id}");

            var operatorDTO = await OperatorDTO.ToOperatorDTOAsync(op);

            return operatorDTO;
        }

        public async Task<OperatorDTO> CreateOperatorAsync(CreateOperatorDTO request)
        {
            var existingOperator = await _context.Operators.FirstOrDefaultAsync(o => o.OperatorName == request.Name);

            if (existingOperator != null)
                throw new CustomException(CustomExceptionType.OperatorAlreadyExists, $"Operator {request.Name} already exists.");

            var operatorDTO = await CreateOperatorDTO.ToOperatorAsync(request);

            _context.Operators.Add(operatorDTO);

            await _context.SaveChangesAsync();

            var op = await _context.Operators.FindAsync(operatorDTO.Id);

            var createdOperator = await OperatorDTO.ToOperatorDTOAsync(op);

            return createdOperator;
        }

        public async Task<OperatorDTO> UpdateOperatorAsync(Guid id, UpdateOperatorDTO request)
        {
            var op = await _context.Operators.FindAsync(id);

            if (op == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Operator found with ID {id}");

            request.UpdateOperator(op, request.Name);

            await _context.SaveChangesAsync();

            var updatedOperatorEntity = await _context.Operators.FindAsync(id);

            var updatedOperatorDTO = await OperatorDTO.ToOperatorDTOAsync(updatedOperatorEntity);

            return updatedOperatorDTO;
        }

        public async Task DeleteOperatorAsync(Guid id)
        {
            var op = await _context.Operators.FindAsync(id);

            if (op == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Operator found with ID {id}");

            _context.Operators.Remove(op);

            await _context.SaveChangesAsync();
        }
    }
}
