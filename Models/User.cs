using System.ComponentModel.DataAnnotations;

namespace Singularis_Test_Task.Models
{
    public class User
    {
        public const string TABLE_NAME = "users_singularis";

        [Required]
        public long id { get; set; }

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


        public User (long id, String email, String firstName,
            String lastName, String dateBirthday, String phoneNumber, String address)
        {
            id = id;
            email = email;
            firstName = firstName;
            lastName = lastName;
            dateBirthday = dateBirthday;
            phoneNumber = phoneNumber;
            address = address;
        }

        public User()
        {
        }
    }
}
