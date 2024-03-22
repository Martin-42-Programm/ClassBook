using ClassBook.Data.Enums;
using Microsoft.AspNetCore.Identity;


namespace ClassBook.Data
{
    public static class DataSeed
    {
        public static void SeedUserRoles(WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ApplicationContext>();

            var roles = Enum.GetValues(typeof(UserRoles));
            foreach (var role in roles)
            {
                var roleName = role.ToString();

                var roleExists = dbContext.Roles.Any(roleEntity => roleEntity.Name == roleName);
                if (!roleExists)
                {
                    var identityRole = new IdentityRole(roleName)
                    {
                        NormalizedName = roleName.ToUpper()
                    };

                    dbContext.Roles.Add(identityRole);
                }
            }

            dbContext.SaveChanges(); 
        }
    }
}