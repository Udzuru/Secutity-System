using System;
using System.Collections.Generic;

namespace Main_api;

public partial class Пользователи
{
    public int Id { get; set; }

    public string? Фио { get; set; }

    public string? Пол { get; set; }

    public int? Должность { get; set; }

    public int? ТипПользователя { get; set; }

    public string? СекретноеСлово { get; set; }

    public string? Логин { get; set; }

    public string? Пароль { get; set; }

    public byte[]? Фото { get; set; }

    public bool? Check { get; set; }

    public bool? Добавление { get; set; }

    public bool? Просмотр { get; set; }

    public bool? Отчеты { get; set; }

    public virtual Должность? ДолжностьNavigation { get; set; }

    public virtual ТипПользователя? ТипПользователяNavigation { get; set; }
}
