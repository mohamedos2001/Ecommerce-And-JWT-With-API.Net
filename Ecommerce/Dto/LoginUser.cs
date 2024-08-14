using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dto
{
    public class LoginUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
