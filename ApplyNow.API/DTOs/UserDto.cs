using System;
using System.ComponentModel.DataAnnotations;

namespace ApplyNow.API.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string Password { get; set; }

    }
}
