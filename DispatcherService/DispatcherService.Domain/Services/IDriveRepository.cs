using DispatcherService.Domain.Services;
using DispatcherService.Domain.Model;

namespace DispatcherService.Domain.Services;
/// <summary>
/// Репозиторий для работы с Поездками.
/// </summary>
public interface IDriveRepository : IRepository<Drive, int>
{
    /// <summary>
    /// Получить количество поездок, среднее и максимальное время поездки для каждого водителя.
    /// </summary>
    /// <returns>Список данных о поездках водителей.</returns>
    Task<IList<(Driver driver, int driveCount, double driveTimeAverage, int driveTimeMaximum)>> GetDriverDriveStats();
}
