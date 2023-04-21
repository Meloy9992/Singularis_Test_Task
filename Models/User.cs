using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Singularis_Test_Task.Models
{
    public class User
    {
        public const string TABLE_NAME = "users_singularis";

        public const string SEQUENCE_NAME = "users_singularis_id_user_seq";

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
            this.id = id;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateBirthday = dateBirthday;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

        public User(String email, String firstName, 
            String lastName, String dateBirthday, String phoneNumber, String address)
        {
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateBirthday = dateBirthday;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

        public User()
        {
        }
    }
}
