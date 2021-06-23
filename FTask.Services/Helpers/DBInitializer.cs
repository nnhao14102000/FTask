using FTask.Database.Models;

namespace FTask.Services.Helpers
{
    public static class DBInitializer
    {
        public static void Initialize(FTaskContext context)
        {
            if (context.Database.EnsureCreated() == false)
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
