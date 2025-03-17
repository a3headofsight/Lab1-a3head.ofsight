using System.ComponentModel.DataAnnotations;

namespace DispatcherService.Domain.Model;
///<summary>
///Класс поездки
///</summary>
public class Drive
{
    ///<summary>
    /// Идентификатор поездки
    ///</summary>
    [Key]
    public required int ID { get; set; }
    ///<summary>
    /// Точка начала маршрута 
    ///</summary>
    public string? RouteStart { get; set; }
    ///<summary>
    /// Точка конца маршрута
    ///</summary>
    public string? RouteEnd { get; set; }
    ///<summary>
    /// Дата поездки
    ///</summary>
    public int? DriveDate { get; set; }
    ///<summary>
    /// Время поездки
    ///</summary>
    public int? DriveTime { get; set; }
    ///<summary>
    /// Цена поездки
    ///</summary>
    public int? Price { get; set; }
    /// <summary>
    /// Идентификатор авто
    /// </summary>
    public required int CarID { get; set; }
    /// <summary>

