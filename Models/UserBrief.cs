using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Singularis_Test_Task.Models
{
    public class UserBrief
    {

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required]
        public String firstName { get; set; }

        [Required]
        public String lastName { get; set; }
    }
}
