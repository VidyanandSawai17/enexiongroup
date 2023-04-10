using System.ComponentModel.DataAnnotations;
namespace enexiongroup.Models
{
    public class Login
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [DataType(DataType.Text)]
        [Display(Name = " Name")]
        public string Name { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }


        [Required]
        [Display(Name = "Email Adress")]
        [MaxLength(40)]
        public string Email { get; set; }


        [Required]
        public string Gender { get; set; }


        [Required]
        public string Language { get; set; }
    }
}
