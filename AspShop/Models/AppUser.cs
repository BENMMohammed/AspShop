using Microsoft.AspNetCore.Identity;

namespace AspShop.Models
{
        public class AppUser : IdentityUser
        {
                public string Occupation { get; set; }
        }
}
