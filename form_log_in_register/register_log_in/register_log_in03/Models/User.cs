using System.ComponentModel.DataAnnotations;

namespace register_log_in03.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}