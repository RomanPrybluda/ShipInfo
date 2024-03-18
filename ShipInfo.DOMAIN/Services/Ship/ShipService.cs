using Microsoft.EntityFrameworkCore;
using ShipInfo.DAL;

namespace ShipInfo.DOMAIN
{
    public class ShipService
    {
        private readonly AppDbContext _context;

        public ShipService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShipDTO>> GetShipsListAsync()
        {
            var ships = await _context.Ships.ToListAsync();

            if (ships == null)
                throw new CustomException(CustomExceptionType.NotFound, "No ships");

            var shipDTOs = new List<ShipDTO>();

            foreach (var ship in ships)
            {
                var shipDTO = ShipDTO.ShipToShipDTO(ship, _context);
                shipDTOs.Add(shipDTO);
            }

            return shipDTOs;
        }

        public async Task<ShipByIdDTO> GetShipByIdAsync(Guid id)
        {
            var shipById = await _context.Ships.FindAsync(id);

            if (shipById == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No shipById with ID {id}");

            var shipByIdDTO = ShipByIdDTO.ToShipByIdDTOAsync(shipById, _context);

            return shipByIdDTO;
        }

        public async Task<ShipDTO> CreateShipAsync(CreateShipDTO request)
        {

            var shipByImoNumber = await _context.Ships.FirstOrDefaultAsync(ship => ship.ImoNumber == request.ImoNumber);

            if (shipByImoNumber != null)
                throw new CustomException(CustomExceptionType.ShipAlreadyExist, $"Ship with IMO number {request.ImoNumber} already exists.");

            var shipTypeById = await _context.ShipTypes.FindAsync(request.ShipTypeId);

            if (shipTypeById == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Type found with ID {request.ShipTypeId}");

            var statusById = await _context.Statuses.FindAsync(request.StatusId);

            if (statusById == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Status found with ID {request.StatusId}");

            var ship = CreateShipDTO.CreateShipDTOToShip(request);

            _context.Ships.Add(ship);

            await _context.SaveChangesAsync();

            var createdShip = await _context.Ships.FindAsync(ship.Id);

            var shipDTO = ShipDTO.ShipToShipDTO(createdShip, _context);

            return shipDTO;
        }


        public async Task<ShipByIdDTO> UpdateShipAsync(Guid id, UpdateShipDTO request)
        {
            var existingShip = await _context.Ships.FirstOrDefaultAsync(ship => ship.Id == id);

            if (existingShip == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No shipById with ID {id}.");

            if (await _context.Ships.FirstOrDefaultAsync(x => x.ImoNumber == request.ImoNumber) != null)
                throw new CustomException(CustomExceptionType.ShipAlreadyExist, $"Ship with this IMO number {request.ImoNumber} already exists.");

            var shipType = await _context.ShipTypes.FindAsync(request.ShipTypeId);

            if (shipType == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Ship Type found with ID {request.ShipTypeId}");

            var status = await _context.Statuses.FindAsync(request.StatusId);

            if (status == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No Status found with ID {request.StatusId}");

            await _context.SaveChangesAsync();

            var updatedShipDTO = ShipByIdDTO.ToShipByIdDTOAsync(existingShip, _context);

            return updatedShipDTO;
        }

        public async Task DeleteShipAsync(Guid id)
        {
            var ship = await _context.Ships.FindAsync(id);

            if (ship is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No shipById with {id} id");

            _context.Ships.Remove(ship);
            await _context.SaveChangesAsync();
        }

    }
}
