using DispatcherService.Domain.Services.InMemory;

namespace DispatcherService.Domain.Tests;

public class UserTest
{
    /// <summary>
    /// Тест проверяет успешное получение пассажиров за указанный период поездок.
    /// </summary>
    [Fact]
    public async Task GetPassengersByTripPeriod_Success()
    {
        var repo = new UserInMemoryRepository();
        var passengers = await repo.GetPassengersDrivePeriod(20241231, 20251231);

        Assert.NotNull(passengers);
    }

    /// <summary>
    /// Тест проверяет успешное получение количества поездок для каждого пассажира.
    /// </summary>
    [Fact]
    public async Task GetTripCountByPassenger_Success()
    {
        var repo = new UserInMemoryRepository();
        var tripCounts = await repo.GetDriveCountPassenger();

        Assert.NotNull(tripCounts);
    }

    /// <summary>
    /// Тест проверяет успешное получение топ-пассажиров по количеству поездок за указанный период.
    /// </summary>
    [Fact]
    public async Task GetTopPassengersByTripPeriod_Success()
    {
        var repo = new UserInMemoryRepository();
        var topPassengers = await repo.GetTopPassengersDrivePeriod(20241201, 20251231);

        Assert.NotNull(topPassengers);
    }
}
