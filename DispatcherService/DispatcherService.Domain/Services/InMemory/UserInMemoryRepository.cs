using DispatcherService.Domain.Data;
using DispatcherService.Domain.Model;

namespace DispatcherService.Domain.Services.InMemory;
/// <summary>
/// Имплементация репозитория для Пользователей, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class UserInMemoryRepository : IUserRepository
{
    private List<User> _users;
    private List<UserDrive> _usersDrives;
    private List<Drive> _drives;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public UserInMemoryRepository()
    {
        _users = DataSeeder.Users;
        _usersDrives = DataSeeder.UserDrives;
        _drives = DataSeeder.Drives;
    }

    /// <inheritdoc/>
    public Task<User> Add(User entity)
    {
        _users.Add(entity);
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        var user = await Get(key);
        if (user != null)
        {
            _users.Remove(user);
            return true;
        }
        return false;
    }

    /// <inheritdoc/>
    public async Task<User> Update(User entity)
    {
        try
        {
            await Delete(entity.ID);
            await Add(entity);
        }
        catch
        {
            return null!;
        }
        return entity;
    }

    /// <inheritdoc/>
    public Task<User?> Get(int key) =>
        Task.FromResult(_users.FirstOrDefault(u => u.ID == key));

    /// <inheritdoc/>
    public Task<IList<User>> GetAll() =>
        Task.FromResult((IList<User>)_users);

    /// <inheritdoc/>
    public Task<IList<User>> GetPassengersDrivePeriod(int startDate, int endDate)
    {
        var passengers = _usersDrives
            .Where(ut => _drives.Any(t => t.ID == ut.DriveID && t.DriveDate >= startDate && t.DriveDate <= endDate))
            .Select(ut => _users.FirstOrDefault(u => u.ID == ut.DriveID))
            .Where(u => u != null)
            .Select(u => u!)
            .OrderBy(u => u.Surname)
            .ToList();

        return Task.FromResult<IList<User>>(passengers);
    }



    /// <inheritdoc/>
    public Task<IList<(User user, int driveCount)>> GetDriveCountPassenger()
    {
        var tripCounts = _usersDrives
            .GroupBy(ut => ut.UserID)
            .Select(g => (user: _users.FirstOrDefault(u => u.ID == g.Key), driveCount: g.Count()))
            .Where(x => x.user != null)
            .ToList();

        return Task.FromResult((IList<(User, int)>)tripCounts);
    }

    /// <inheritdoc/>
    public Task<IList<User>> GetTopPassengersDrivePeriod(int startDate, int endDate)
    {
        var topPassengers = _usersDrives
            .Where(ut => _drives.Any(t => t.ID == ut.DriveID && t.DriveDate >= startDate && t.DriveDate <= endDate))
            .GroupBy(ut => ut.UserID)
            .OrderByDescending(g => g.Count())
            .Select(g => _users.FirstOrDefault(u => u.ID == g.Key))
            .Where(u => u != null)
            .Select(u => u!)
            .ToList();

        return Task.FromResult<IList<User>>(topPassengers);
    }

}