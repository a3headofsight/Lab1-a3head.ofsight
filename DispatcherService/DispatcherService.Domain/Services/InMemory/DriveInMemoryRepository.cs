using DispatcherService.Domain.Data;
using DispatcherService.Domain.Model;

namespace DispatcherService.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория для Поездок, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class DriveInMemoryRepository : IDriveRepository
{
    private readonly List<Drive> _drives;
    private readonly List<Driver> _drivers;
    private readonly List<DriverCar> _driverCars;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public DriveInMemoryRepository()
    {
        _drives = DataSeeder.Drives;
        _drivers = DataSeeder.Drivers;
        _driverCars = DataSeeder.DriverCars;
    }

    /// <inheritdoc/>
    public Task<Drive> Add(Drive entity)
    {
        _drives.Add(entity);
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        var drive = await Get(key);
        if (drive != null)
        {
            _drives.Remove(drive);
            return true;
        }
        return false;
    }

    /// <inheritdoc/>
    public Task<Drive> Update(Drive entity)
    {
        var existingTrip = _drives.FirstOrDefault(d => d.ID == entity.ID);
        if (existingTrip != null)
        {           
            existingTrip.ID = entity.ID;
            existingTrip.RouteStart= entity.RouteStart;
            existingTrip.RouteEnd = entity.RouteEnd;
            existingTrip.DriveDate= entity.DriveDate;
            existingTrip.DriveTime= entity.DriveTime;
            existingTrip.Price= entity.Price;
            existingTrip.CarID = entity.CarID;
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public Task<Drive?> Get(int key) =>
        Task.FromResult(_drives.FirstOrDefault(t => t.ID == key));

    /// <inheritdoc/>
    public Task<IList<Drive>> GetAll() =>
        Task.FromResult((IList<Drive>)_drives);

    /// <inheritdoc/>
    public Task<IList<(Driver driver, int tripCount, double avgTravelTime, int maxTravelTime)>> GetDriverDriveStats()
    {
        var statistics = _drives
            .GroupBy(t => t.CarID)
            .Select(g =>
            {
                var driverCar = _driverCars.FirstOrDefault(dc => dc.CarID == g.Key);
                var driver = driverCar != null ? _drivers.FirstOrDefault(d => d.ID == driverCar.DriverID) : null;
                return driver != null
                    ? (driver, g.Count(), g.Average(t => t.DriveTime ?? 0), g.Max(t => t.DriveTime ?? 0))
                    : default;
            })
            .Where(stat => stat.driver != null)
            .ToList();

        return Task.FromResult((IList<(Driver, int, double, int)>)statistics);
    }
}
