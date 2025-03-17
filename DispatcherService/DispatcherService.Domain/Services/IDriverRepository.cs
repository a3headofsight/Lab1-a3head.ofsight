using DispatcherService.Domain.Services;
using DispatcherService.Domain.Model;

namespace DispatcherService.Domain.Services;
/// <summary>
/// Репозиторий для работы с водителями.
/// </summary>
public interface IDriverRepository : IRepository<Driver, int>
{
    /// <summary>
    /// Метод для получения информации о водителе и авто
    /// </summary>
    /// <param name="ID">Идентификатор водителя.</param>
    /// <returns>Возвращает данные водителя и его авто</returns>
    Task<(Driver driver, Car car)?> GetCarDriver(int ID);
    /// <summary>
    /// Метод для получения 5 водителей с наибольшим количеством поездок
    /// </summary>
    /// <returns>Возвращает список из 5 водителей и их поездки</returns>
    Task<IList<(Driver driver, int driveCount)>> GetTopFiveDriveCount();
    /// <summary>
    /// Метод для получения информации о количестве поездок, и среднем/максимальном времени поездки каждого водителя
    /// </summary>
    /// <returns>Возвращает спискок водителей и время поездок</returns>
    Task<IList<(Driver driver, int driveCount, double driveTimeAverage, int driveTimeMaximum)>> GetDriverDriveStats();
}