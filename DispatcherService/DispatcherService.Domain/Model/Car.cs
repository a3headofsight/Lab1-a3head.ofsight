using System.ComponentModel.DataAnnotations;

namespace DispatcherService.Domain.Model;
///<summary>
///Класс ТС
///</summary>
public class Car
{
    ///<summary>
    /// Идентификатор авто
    ///</summary>
    [Key]
    public required int ID { get; set; }
    ///<summary>
    /// Номер авто
    ///</summary>
    public required string? LicensePlate { get; set; }
    ///<summary>
    /// Модель авто
    ///</summary>
    public string? Model { get; set; }
    ///<summary>
    /// Цвет авто
    ///</summary>
    public string? Color { get; set; }
    ///<summary>
    /// Год выпуска авто
    ///</summary>
    public int? ManufactureYear { get; set; }
}

