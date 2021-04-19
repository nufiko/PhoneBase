using System.ComponentModel.DataAnnotations;

namespace PhoneBase.DAL.Model
{
    public class Phone
    {
        public int Id { get; set; }
        [Required]
        [MinLength(6)]
        public string PhoneNumber { get; set; }
        public User User { get; set; }
    }
}