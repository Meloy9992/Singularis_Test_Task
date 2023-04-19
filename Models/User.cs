using System.ComponentModel.DataAnnotations;

namespace Singularis_Test_Task.Models
{
    public class User
    {
        [Required]
        public String email { get; set; }

        [Required]
        public String firstName { get; set; }

        [Required]
        public String lastName { get; set; }

        [Required]
        public String dateBirthday { get; set; }

        [Required]
        public String phoneNumber { get; set; }

        [Required]
        public String address { get; set; }
    }
}
