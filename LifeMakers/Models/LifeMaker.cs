using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LifeMakers.Models
{
public class LifeMaker
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        public long? NationalId { get; set; } 

        [MaxLength(255)]
        public string Email { get; set; }

        public DateTime JoinDate { get; set; }

        public string ProfileImage { get; set; }

        public string Activities { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }
    }

}

