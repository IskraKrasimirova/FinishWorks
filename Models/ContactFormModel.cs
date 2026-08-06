using System.ComponentModel.DataAnnotations;

namespace FinishWorks.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Името е задължително.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Името трябва да бъде между 2 и 100 символа.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Телефонният номер е задължителен.")]
        [Phone(ErrorMessage = "Невалиден телефонен формат.")]
        [RegularExpression(@"^(\+)?([0-9\s\-]{8,20})$", ErrorMessage = "Невалиден телефонен номер.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Имейл адресът е задължителен.")]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Съобщението е задължително.")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Съобщението трябва да бъде поне 10 символа.")]
        public string Message { get; set; } = string.Empty;
    }
}
