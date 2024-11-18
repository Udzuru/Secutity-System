using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web_propusk.Models;

public partial class Zaivki
{
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [HiddenInput(DisplayValue = false)]
    public int? People { get; set; }
    [Required(ErrorMessage = "Поле должно быть установлено")]
    public DateTime? FromDate { get; set; }
    [Required(ErrorMessage = "Поле должно быть установлено")]
    public DateTime? ToDate { get; set; }

    [HiddenInput(DisplayValue = false)]
    public int? Where { get; set; }

    public byte[]? Photo { get; set; }

    [HiddenInput(DisplayValue = false)]
    public string? Status { get; set; }

    public string? File { get; set; }

    public double? Group { get; set; }

    public DateTime? Date { get; set; }

    public int? Type { get; set; }

    public virtual Person? PeopleNavigation { get; set; }

    public virtual Typ? TypeNavigation { get; set; }

    public virtual Employer? WhereNavigation { get; set; }
}
