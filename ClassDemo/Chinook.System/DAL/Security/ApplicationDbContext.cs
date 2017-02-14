
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using Microsoft.AspNet.Identity.EntityFramework;
using Chinook.Data.Entities.Security;
#endregion


namespace Chinook.System.DAL.Security
{
    internal class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}
