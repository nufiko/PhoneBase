using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBase.DAL.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
    }
}
