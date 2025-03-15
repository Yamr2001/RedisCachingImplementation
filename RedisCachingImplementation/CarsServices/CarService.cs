using Microsoft.EntityFrameworkCore;
using RedisCachingImplementation.ConnectionDatabase;
using RedisCachingImplementation.Dtos;

namespace RedisCachingImplementation.CarsServices
{
    public class CarService(ApplicationDbContext context) : ICarService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> CreateCar(CarDto car, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Entities.Cars
            {
                Name = car.Name,
                Model = car.Model,
                Year = car.Year
            }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteCar(int id, CancellationToken cancellationToken)
        {
            var GetCar = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (GetCar is not null)
            {
                _context.Remove(GetCar);
            }
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<CarDto> GetCar(int id, CancellationToken cancellationToken)
        {
            var GetCar = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (GetCar is not null)
            {
                return new CarDto
                {
                    Name = GetCar.Name,
                    Model = GetCar.Model,
                    Year = GetCar.Year
                };
            }
            return new();
        }

        public async Task<IEnumerable<CarDto>> GetCars(CancellationToken cancellationToken)
        {
            var AllCars = await _context.Cars.ToListAsync(cancellationToken);
            return AllCars.Select(x => new CarDto
            {
                Id = x.Id,
                Name = x.Name,
                Model = x.Model,
                Year = x.Year
            });
        }
    }
}
