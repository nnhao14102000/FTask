using FTask.Database.Models;

namespace FTask.Services.Helpers
{
    public static class DBInitializer
    {
        public static void Initialize(FTaskContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
