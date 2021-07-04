using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FTask.AuthDatabase.Data
{
    public class FTaskAuthDbContext : IdentityDbContext
    {
        public FTaskAuthDbContext(DbContextOptions<FTaskAuthDbContext> options)
            : base(options)
        {

        }
    }
}
