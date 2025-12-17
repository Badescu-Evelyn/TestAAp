using foodrecipe.Models;
using Microsoft.AspNetCore.Identity;

namespace foodrecipe.DataModels
{
    public class User :IdentityUser
    {
        
        public ICollection<Review> Reviews { get; set; }
    }
}
