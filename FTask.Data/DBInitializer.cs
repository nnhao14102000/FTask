using FTask.Data.Models;

namespace FTask.Data
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
