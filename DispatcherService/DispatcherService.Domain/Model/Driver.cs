using System.ComponentModel.DataAnnotations;

namespace DispatcherService.Domain.Model;
///<summary>
///Класс водители
///</summary>
public class Driver
{
    /// <summary>
    /// Идентификатор водителя
    /// </summary>
    [Key]
    public required int ID { get; set; }
    ///<summary>
    /// Имя водителя 
    ///</summary>
    public string? Name { get; set; }
    ///<summary>
    /// Фамилия водителя 
    ///</summary>
    public string? Surname { get; set; }
    ///<summary>
    /// Отчество водителя 
    ///</summary>
    public string? Patronymic { get; set; }
    ///<summary>
    /// Телефон водителя
    ///</summary>
    public int? PhoneNumber { get; set; }
    ///<summary>
    /// Серия паспорта
    ///</summary>
    public int? PassportSeries { get; set; }
    ///<summary>
    /// Номер паспорта
    ///</summary>
    public int? PassportNumber { get; set; }
}

