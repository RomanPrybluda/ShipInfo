using ShipInfo.Domain.Abstractions;

namespace ShipInfo.Domain
{
    public class ShipService
    {
        private readonly IShipRepository _shipRepository;

        public ShipService(IShipRepository shipRepository)
        {
            _shipRepository = shipRepository;
        }

        //public async Task<IEnumerable<ShipShortDetails>> GetShipsListAsync()
        //{
        //    var ships = await _shipRepository.Ships.ToListAsync();

        //    if (ships == null)
        //        throw new CustomException(CustomExceptionType.NotFound, "No ships");

        //    var shipDTOs = new List<ShipDTO>();

        //    foreach (var ship in ships)
        //    {
        //        var shipDTO = ShipDTO.ShipToShipDTO(ship, _shipRepository);
        //        shipDTOs.Add(shipDTO);
        //    }

        //    return shipDTOs;
        //}

        public async Task<ShipShortDetails> GetShipsByIMONumberAsync(int imoNumber)
        {
            var ship = await _shipRepository.GetShipByIMONumberAsync(imoNumber);

            if (ship == null)
                throw new CustomException(CustomExceptionType.NotFound, "No ships");

            return ship;
        }

        public async Task<ShipShortDetails> GetShipsByNameAsync(string shipName)
        {
            var ship = await _shipRepository.GetShipByNameAsync(shipName);

            if (ship == null)
                throw new CustomException(CustomExceptionType.NotFound, "No ships");

            return ship;
        }

        public async Task<ShipAllDetails> GetShipByIdAsync(Guid shipId)
        {
            var shipById = await _shipRepository.GetShipByIdAsync(shipId);

            if (shipById == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No shipById with ID {shipId}");

            return shipById;
        }

        //public async Task<ShipDTO> CreateShipAsync(CreateShipDTO request)
        //{

        //    var shipByImoNumber = await _shipRepository.Ships.FirstOrDefaultAsync(ship => ship.ImoNumber == request.ImoNumber);

        //    if (shipByImoNumber != null)
        //        throw new CustomException(CustomExceptionType.ShipAlreadyExist, $"Ship with IMO number {request.ImoNumber} already exists.");

        //    var shipTypeById = await _shipRepository.ShipTypes.FindAsync(request.ShipTypeId);

        //    if (shipTypeById == null)
        //        throw new CustomException(CustomExceptionType.NotFound, $"No Ship Type found with ID {request.ShipTypeId}");

        //    var statusById = await _shipRepository.Statuses.FindAsync(request.StatusId);

        //    if (statusById == null)
        //        throw new CustomException(CustomExceptionType.NotFound, $"No ShipStatus found with ID {request.StatusId}");

        //    var ship = CreateShipDTO.CreateShipDTOToShip(request);

        //    _shipRepository.Ships.Add(ship);

        //    await _shipRepository.SaveChangesAsync();

        //    var createdShip = await _shipRepository.Ships.FindAsync(ship.Id);

        //    var shipDTO = ShipDTO.ShipToShipDTO(createdShip, _shipRepository);

        //    return shipDTO;
        //}


        //public async Task<ShipAllDetails> UpdateShipAsync(Guid id, UpdateShipDTO request)
        //{
        //    var ship = await _shipRepository.Ships.FindAsync(id);

        //    if (ship == null)
        //        throw new CustomException(CustomExceptionType.NotFound, $"No shipById with ID {id}.");

        //    if (await _shipRepository.Ships.FirstOrDefaultAsync(x => x.ImoNumber == request.ImoNumber) != null)
        //        throw new CustomException(CustomExceptionType.ShipAlreadyExist, $"Ship with this IMO number {request.ImoNumber} already exists.");

        //    var shipType = await _shipRepository.ShipTypes.FindAsync(request.ShipTypeId);

        //    if (shipType == null)
        //        throw new CustomException(CustomExceptionType.NotFound, $"No Ship Type found with ID {request.ShipTypeId}");

        //    var status = await _shipRepository.Statuses.FindAsync(request.StatusId);

        //    if (status == null)
        //        throw new CustomException(CustomExceptionType.NotFound, $"No ShipStatus found with ID {request.StatusId}");

        //    request.UpdateShip(ship, request);

        //    await _shipRepository.SaveChangesAsync();

        //    var updatedShipDTO = ShipAllDetails.ToShipByIdDTOAsync(ship, _shipRepository);

        //    return updatedShipDTO;
        //}

        public async Task DeleteShipAsync(Guid shipId)
        {
            var ship = await _shipRepository.GetShipByIdAsync(shipId);

            if (ship is null)
                throw new CustomException(CustomExceptionType.NotFound, $"No shipById with {shipId} id");

            await _shipRepository.DeleteShipAsync(shipId);
        }

    }
}
