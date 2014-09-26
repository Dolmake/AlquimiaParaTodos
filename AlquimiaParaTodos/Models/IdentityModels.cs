using Microsoft.AspNet.Identity.EntityFramework;

namespace AlquimiaParaTodos.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
#if DEBUG
            //: base("DBROLES-Connection")
            : base("Alquimia-DBROLES-Connection")
#elif RELEASE
            : base("Alquimia-DBROLES-Hostalia-Connection")
#endif
        {
        }
       
    }
}