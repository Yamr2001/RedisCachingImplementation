using Microsoft.AspNetCore.Mvc;
using RedisCachingImplementation.CarsServices;
using RedisCachingImplementation.Dtos;
using RedisCachingImplementation.RedisCachingService;

namespace RedisCachingImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController(ICarService carService, IRedisCachingService cacheService) : ControllerBase
    {
        private readonly ICarService _carService = carService;
        private readonly IRedisCachingService _cacheService = cacheService;

        [HttpGet]
        public async Task<IActionResult> GetAllCars(CancellationToken cancellationToken)
        {
            var Key = "E300";
            var CacheData = await _cacheService.GetAsync<IEnumerable<CarDto>>(Key);
            if (CacheData is not null)
            {
                return Ok(CacheData);
            }
            var AllCars = await _carService.GetCars(cancellationToken);
            await _cacheService.SetAsync(Key, AllCars);

            return Ok(AllCars);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CarDto request, CancellationToken cancellationToken)
        {
            return Ok(await _carService.CreateCar(request, cancellationToken));
        }
    }
}
