using System.ComponentModel.DataAnnotations;

namespace DeliveryOrdersApp.Models
{
    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(100, ErrorMessage = "Название слишком длинное")]
        [Display(Name = "Город отправителя")]
        public string SenderCity { get; set; } = default!;

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(200, ErrorMessage = "Лимит символов превышен")]
        [Display(Name = "Адрес отправителя")]
        public string SenderAdress { get; set; } = default!;

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(100, ErrorMessage = "Лимит символов превышен")]
        [Display(Name = "Город получателя")]
        public string RecipientCity { get; set; } = default!;

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(200, ErrorMessage = "Лимит символов превышен")]
        [Display(Name = "Адрес получателя")]
        public string RecipientAdress { get; set; } = default!;

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0.1, 1000, ErrorMessage = $"Разрешенный вес груза от 0.1 до 1000 кг.")]
        [Display(Name = "Вес груза")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Date), Display(Name = "Дата забора груза")]
        public DateTime PickupDate { get; set; }
    }
}