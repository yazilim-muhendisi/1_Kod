using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı İsmi Gereklidir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Tel No:")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Email Gereklidir.")]
        [Display(Name = "Email Adresi")]
        [EmailAddress(ErrorMessage = "Email Adresiniz Doğru Formatta Değil.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Gereklidir.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
