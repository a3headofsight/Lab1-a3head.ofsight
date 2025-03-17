using System.ComponentModel.DataAnnotations;

namespace DispatcherService.Domain.Model;
///<summary>
///Класс пользователь
///</summary>
public class User
{
    /// <summary>
    /// Индификатор пользователя 
    /// </summary>
    [Key]
    public required int ID { get; set; }
    ///<summary>
    /// Имя пользователя 
    ///</summary>
    public string? Name { get; set; }
    ///<summary>
    /// Фамилия пользователя 
    ///</summary>
    public string? Surname { get; set; }
    ///<summary>
    /// Отчество пользователя 
    ///</summary>
    public string? Patronymic { get; set; }
    ///<summary>
    /// Телефон пользователя
    ///</summary>
    public string? PhoneNumber { get; set; }
}

