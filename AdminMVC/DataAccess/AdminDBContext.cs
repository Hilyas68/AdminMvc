using AdminMVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdminMVC.DataAccess
{
    public class AdminDBContext : IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public AdminDBContext() : base($"name={nameof(AdminDBContext)}")
        {
        }
    }
}