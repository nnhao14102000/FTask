using FTask.AuthDatabase.Data;

namespace FTask.AuthServices.Helpers
{
    public static class AuthDBInitializer
    {
        public static void Initialize(FTaskAuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
