using Microsoft.EntityFrameworkCore;
namespace Api.User.Core.DatabaseManagementService
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider
                                 .GetService<ContextSqlServerDB.ContextSqlServerDB>();

                serviceDb.Database.Migrate();
            }
        }
    }
}
