using DispatcherService.Domain.Model;

namespace DispatcherService.Domain.Data;

/// <summary>
/// Класс заполнения сущностей данными
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Список авто
    /// </summary>
    public static readonly List<Car> Cars =
    [
        new() { ID = 1, LicensePlate = "A994KX763", Model = "ON-DO", ManufactureYear = 2018 },
        new() { ID = 2, LicensePlate = "H935TE63", Model = "21099", ManufactureYear = 2000 },
        new() { ID = 3, LicensePlate = "O462KY163", Model = "2113", ManufactureYear = 2011 },
        new() { ID = 4, LicensePlate = "A777AA777", Model = "Senat", ManufactureYear = 2024 },
        new() { ID = 5, LicensePlate = "T335XC163", Model = "Polo", ManufactureYear = 2014 }
    ];
    /// <summary>
    /// Список водителей
    /// </summary>
    public static readonly List<Driver> Drivers =
    [
        new() { ID = 1, Name = "Тимур", Surname = "Дамирбулатов" },
        new() { ID = 2, Name = "Илья", Surname = "Николаев" },
        new() {ID = 3, Name = "Сергей", Surname = "Пискун"},
        new() {ID = 4, Name = "Владимир", Surname = "Такченко"},
        new() {ID = 5, Name = "Денис", Surname = "Сухачёв"}
    ];
    /// <summary>
    /// Список отношенитй водитель-авто
    /// </summary>
    public static readonly List<DriverCar> DriverCars =
    [
        new() { ID = 1, DriverID = 1, CarID = 1 },
        new() { ID = 2, DriverID = 2, CarID = 2 },
        new() { ID = 3, DriverID = 3, CarID = 3 },
        new() { ID = 4, DriverID = 4, CarID = 4 },
        new() { ID = 5, DriverID = 5, CarID = 5 }
    ];
    /// <summary>
    /// Список пользователей
    /// </summary>
    public static readonly List<User> Users =
    [
        new() {ID = 1, Name = "Мария", Surname = "Смирнова"},
        new() {ID = 2, Name = "Ольга", Surname = "Козлова"},
        new() {ID = 3, Name = "Павел", Surname = "Морозов"},
        new() {ID = 4, Name = "Анна", Surname = "Васильева"},
        new() {ID = 5, Name = "Роман", Surname = "Зайцев"}
    ];
    /// <summary>
    /// Список поездок
    /// </summary>
    public static readonly List<Drive> Drives =
    [
        new() { ID = 1, CarID = 1, DriveDate= 20250311, DriveTime= 15 },
        new() { ID = 2, CarID = 2, DriveDate = 20250111, DriveTime = 60 },
        new() {ID = 3, CarID = 3, DriveDate = 20250112, DriveTime = 18},
        new() {ID = 4, CarID = 4, DriveDate = 20250310, DriveTime = 44},
        new() {ID = 5, CarID = 5, DriveDate = 20250112, DriveTime = 23}
    ];
    /// <summary>
    /// Список отношений пользователь-поездка
    /// </summary>
    public static readonly List<UserDrive> UserDrives =
    [
        new() { ID = 1, UserID = 1, DriveID = 1 },
        new() { ID = 2, UserID = 2, DriveID = 2 },
        new() {ID = 3, UserID = 3, DriveID = 3},
        new() {ID = 4, UserID = 4, DriveID = 4},
        new() {ID = 5, UserID = 5, DriveID = 5}
    ];
}
