using RedisCachingImplementation.Dtos;

namespace RedisCachingImplementation.CarsServices
{
    public interface ICarService
    {
        Task<bool> CreateCar(CarDto car, CancellationToken cancellationToken);
        Task<bool> DeleteCar(int id, CancellationToken cancellationToken);
        Task<CarDto> GetCar(int id, CancellationToken cancellationToken);
        Task<IEnumerable<CarDto>> GetCars(CancellationToken cancellationToken);
    }
}
