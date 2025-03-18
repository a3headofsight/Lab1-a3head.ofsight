
using DispatcherService.Domain.Services.InMemory;

namespace DispatcherService.Domain.Tests;

public class DriveTest
{
    /// <summary>
    /// Тест проверяет успешное получение статистики по поездкам водителей.
    /// </summary>
    [Fact]
    public async Task GetDriverTripStatistics_Success()
    {
        var repo = new DriveInMemoryRepository();
        var statistics = await repo.GetDriverDriveStats();

        Assert.NotNull(statistics);
    }
}
