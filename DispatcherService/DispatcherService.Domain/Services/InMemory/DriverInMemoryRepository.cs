using DispatcherService.Domain.Model;
using DispatcherService.Domain.Services;
using DispatcherService.Domain.Data;

namespace DispatcherService.Domain.Services.InMemory;
/// <summary>
/// Реализация репозитория для работы с водителями в памяти.
/// </summary>
public class DriverInMemoryRepository : IDriverRepository
{
    private readonly List<Driver> _drivers;
    private readonly List<Car> _cars;
    private readonly List<DriverCar> _driverCars;
    private readonly List<Drive> _trips;

    /// <inheritdoc/>
    public DriverInMemoryRepository()
    {
        _drivers = DataSeeder.Drivers;
        _cars = DataSeeder.Cars;
        _driverCars = DataSeeder.DriverCars;
        _trips = DataSeeder.Drives;
    }

    /// <inheritdoc/>
    public Task<IList<Driver>> GetAll()
    {
        return Task.FromResult<IList<Driver>>(_drivers);
    
    }

    /// <inheritdoc/>
    public Task<Driver?> Get(int key)
    {
        var driver = _drivers.FirstOrDefault(d => d.ID == key);
        return Task.FromResult(driver);
    }

    /// <inheritdoc/>
    public Task<Driver> Add(Driver entity)
    {
        if (!_drivers.Any(d => d.ID == entity.ID))
        {
            _drivers.Add(entity);
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<Driver> Update(Driver entity)
    {
        var existingDriver = _drivers.FirstOrDefault(d => d.ID == entity.ID);
        if (existingDriver != null)
        {
            existingDriver.Name = entity.Name;
            existingDriver.Surname = entity.Surname;
            existingDriver.Patronymic = entity.Patronymic;
            existingDriver.PhoneNumber = entity.PhoneNumber;
            existingDriver.PassportSeries = entity.PassportSeries;
            existingDriver.PassportNumber = entity.PassportNumber;
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<bool> Delete(int key)
    {
        var driver = _drivers.FirstOrDefault(d => d.ID == key);
        if (driver != null)
        {
            _drivers.Remove(driver);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <inheritdoc/>
    public Task<(Driver driver, Car car)?> GetCarDriver(int Id)
    {
        var driverCar = _driverCars.FirstOrDefault(dc => dc.DriverID == Id);
        if (driverCar != null)
        {
            var driver = _drivers.FirstOrDefault(d => d.ID == driverCar.DriverID);
            var car = _cars.FirstOrDefault(c => c.ID == driverCar.CarID);
            if (driver != null && car != null)
            {
                return Task.FromResult<(Driver, Car)?>((driver, car));
            }
        }
        return Task.FromResult<(Driver, Car)?>(null);
    }

    /// <inheritdoc/>
    public Task<IList<(Driver driver, int driveCount)>> GetTopFiveDriveCount()
    {
        var topDrivers = _trips
            .GroupBy(t => t.CarID)
            .Select(g => new
            {
                Driver = _drivers.FirstOrDefault(d => _driverCars.Any(dc => dc.DriverID == d.ID && dc.CarID == g.Key)),
                TripCount = g.Count()
            })
            .Where(x => x.Driver != null)
            .OrderByDescending(x => x.TripCount)
            .Take(5)
            .Select(x => (x.Driver!, x.TripCount))
            .ToList();

        return Task.FromResult<IList<(Driver, int)>>(topDrivers);
    }

    /// <inheritdoc/>
    public Task<IList<(Driver driver, int driveCount, double driveTimeAverage, int driveTimeMaximum)>> GetDriverDriveStats()
    {
        var driverStats = _trips
            .GroupBy(t => t.CarID)
            .Select(g => new
            {
                Driver = _drivers.FirstOrDefault(d => _driverCars.Any(dc => dc.DriverID == d.ID && dc.CarID == g.Key)),
                TripCount = g.Count(),
                AvgTravelTime = g.Average(t => t.DriveTime ?? 0),
                MaxTravelTime = g.Max(t => t.DriveTime ?? 0)
            })
            .Where(x => x.Driver != null)
            .Select(x => (x.Driver!, x.TripCount, x.AvgTravelTime, x.MaxTravelTime))
            .ToList();

        return Task.FromResult<IList<(Driver, int, double, int)>>(driverStats);
    }
}
