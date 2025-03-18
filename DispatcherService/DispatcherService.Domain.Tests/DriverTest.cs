using DispatcherService.Domain.Services.InMemory;

namespace DispatcherService.Domain.Tests;

public class DriverTest
{
    /// <summary>
    ///Тест проверяет успешное получение водителя с его автомобилем
    /// </summary>
    [Fact]
    public async Task GetDriverWithCar_Success()
    {
        var repo = new DriverInMemoryRepository();
        var driverCar = await repo.GetCarDriver(1);

        Assert.NotNull(driverCar);
        Assert.NotNull(driverCar?.driver);
        Assert.NotNull(driverCar?.car);
    }
    /// <summary>
    ///Тест проверяет успешное получение топ-5 водителей по количеству поездок
    /// </summary>
    [Fact]
    public async Task GetTop5DriversByTripCount_Success()
    {
        var repo = new DriverInMemoryRepository();
        var topDrivers = await repo.GetTopFiveDriveCount();

        Assert.NotNull(topDrivers);
        Assert.True(topDrivers.Count <= 5);
    }
    /// <summary>
    ///Тест проверяет успешное получение статистики по поездкам водителей
    /// </summary>
    [Fact]
    public async Task GetDriverTripStatistics_Success()
    {
        var repo = new DriverInMemoryRepository();
        var statistics = await repo.GetDriverDriveStats();

        Assert.NotNull(statistics);
    }
}
