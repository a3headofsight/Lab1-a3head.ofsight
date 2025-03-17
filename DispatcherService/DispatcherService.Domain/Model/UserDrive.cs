using System.ComponentModel.DataAnnotations;

namespace DispatcherService.Domain.Model;
///<summary>
///Класс связывающий пользователей и поездки
///</summary>
public class UserDrive
{
    /// <summary>
    /// Идентификатор отношения
    /// </summary>
    [Key]
    public required int ID { get; set; }
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public required int UserID { get; set; }
    /// <summary>
    /// Идентификатор поездки
    /// </summary>
    public required int DriveID { get; set; }
}

