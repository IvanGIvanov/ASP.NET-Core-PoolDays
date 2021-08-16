using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PoolDays.Data.Models
{
    using static PoolDays.Data.DataConstants.User;

    public class User : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        public string LastName { get; set; }

        public IEnumerable<Pool> Pools { get; set; } = new List<Pool>();

        public IEnumerable<Jacuzzi> Jacuzzis { get; set; } = new List<Jacuzzi>();
    }
}
