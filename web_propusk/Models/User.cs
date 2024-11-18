using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace web_propusk.Models
{
    public partial class User
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Логин")]
        public string Login { get; set; } = null!;

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; } = null!;

        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Не надежный пароль! Используйте строчные и заглавные буквы цифру и спецсимвол")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;


        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? Rep_Password { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Имя")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Фамилия")]
        public string? Surname { get; set; }
    }
}
