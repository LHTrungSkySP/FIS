using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UI_Elearning.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Required(ErrorMessage = "Tên tài khoản không được để trống!")]
        public string AccountName { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [MinLength(8)]
        public string AccountPassword { get; set; }
        [Required(ErrorMessage = "Email không được để trống!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Họ không được để trống!")]
        public string UserLastName { get; set; }
        [Required(ErrorMessage = "Tên không được để trống!")]
        public string UserFirstName { get; set; }
        [Required(ErrorMessage = "Giới tính không được để trống!")]
        public bool Sex { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        public string Address { get; set; }
    }
}