using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web_propusk.Models;

public partial class Person
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле должно быть установлено")]
    public string? Surname { get; set; }
    [Required(ErrorMessage = "Поле должно быть установлено")]
    public string? Name { get; set; }
    
    public string? Patronimic { get; set; }

    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "Поле должно быть установлено")]
    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
    public string? EMail { get; set; }
    [Required(ErrorMessage = "Поле должно быть установлено")]
    
    public string? DateOfBirth { get; set; }
    [Required(ErrorMessage = "Поле должно быть установлено")]
    public string? PassportNumber { get; set; }
    [Required(ErrorMessage = "Поле должно быть установлено")]
    public double? PassportSeria { get; set; }

    public string? Organization { get; set; }
    [Required(ErrorMessage = "Поле должно быть установлено")]
    public string? Comment { get; set; }

    public virtual ICollection<Zaivki> Zaivkis { get; } = new List<Zaivki>();
}
