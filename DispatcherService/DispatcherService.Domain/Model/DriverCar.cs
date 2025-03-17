using System.ComponentModel.DataAnnotations;

namespace DispatcherService.Domain.Model;
///<summary>
///Класс связывающий водителей и ТС
///</summary>
public class DriverCar
{
    /// <summary>
    /// Идентификатор отношения
    /// </summary>
    [Key]
    public required int ID { get; set; }
    /// <summary>
    /// Идентификатор авто
    /// </summary>
    public required int CarID { get; set; }
    /// <summary>
    /// Идентификатор водителя
    /// </summary>
    public required int DriverID { get; set; }
    /// <summary>
}

