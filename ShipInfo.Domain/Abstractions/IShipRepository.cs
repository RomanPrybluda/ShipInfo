
using ShipInfo.Domain.Services.Ship.DTO;

namespace ShipInfo.Domain.Abstractions
{
    public interface IShipRepository
    {
        Task<PaginatedList> GetShipsByParamsAsync(ShipSearchCriteria criteria, int pageIndex, int pageSize);

        Task<ShipAllDetails> GetShipByIdAsync(Guid shipId);

        Task<ShipShortDetails> GetShipByIMONumberAsync(int imoNumber);

        Task<ShipShortDetails> GetShipByNameAsync(string shipName);

        Task<ShipShortDetails> CreateShipAsync(CreateShipDTO ship);

        Task<ShipShortDetails> UpdateShipAsync(UpdateShipDTO ship);

        Task DeleteShipAsync(Guid shipId);
    }
}
