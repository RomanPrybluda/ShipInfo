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
                var shipDTO = await ShipDTO.ToShipDTOAsync(ship, _context);
                shipDTOs.Add(shipDTO);
            }

            return shipDTOs;
        }

        public async Task<ShipByIdDTO> GetShipByIdAsync(Guid id)
        {
            var ship = await _context.Ships.FindAsync(id);

            if (ship == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No ship with ID {id}");

            var shipByIdDTO = await ShipByIdDTO.ToShipByIdDTOAsync(ship, _context);

            return shipByIdDTO;
        }

        public async Task<ShipDTO> CreateShipAsync(CreateShipDTO request)
        {
            var existingShip = await _context.Ships.FirstOrDefaultAsync(ship => ship.ImoNumber == request.ImoNumber);

            if (existingShip != null)
                throw new CustomException(CustomExceptionType.ShipAlreadyExist, $"Ship with IMO number {request.ImoNumber} already exists.");

            var newShip = await CreateShipDTO.ToShipAsync(request);

            _context.Ships.Add(newShip);

            await _context.SaveChangesAsync();

            var ship = await _context.Ships.FindAsync(newShip.Id);
            var shipDTO = await ShipDTO.ToShipDTOAsync(ship, _context);

            return shipDTO;
        }

        public async Task<ShipByIdDTO> UpdateShipAsync(ShipByIdDTO request)
        {
            var existingShip = await _context.Ships.FirstOrDefaultAsync(ship => ship.Id == request.Id);

            if (existingShip == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No ship with ID {request.Id}.");

            if (await _context.Ships.FirstOrDefaultAsync(x => x.ImoNumber == request.ImoNumber) != null)
                throw new CustomException(CustomExceptionType.ShipAlreadyExist, $"Ship with this IMO number {request.ImoNumber} already exists.");

            // add code to change Property of existingShip from request

            await _context.SaveChangesAsync();

            var updatedShipDTO = await ShipByIdDTO.ToShipByIdDTOAsync(existingShip, _context);

            return updatedShipDTO;
        }

        public async Task DeleteShipAsync(Guid id)
        {
            var ship = await _context.Ships.FindAsync(id);

            if (ship is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No ship with {id} id");

            _context.Ships.Remove(ship);
            await _context.SaveChangesAsync();
        }

    }
}
