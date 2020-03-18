using Microsoft.EntityFrameworkCore;
using Sinca.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Sinca.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See SincaMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class SincaDbContext : AbpDbContext<SincaDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
		public DbSet<Cliente> Clientes { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside SincaDbContextModelCreatingExtensions.ConfigureSinca
         */

        public SincaDbContext(DbContextOptions<SincaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
				b.ToTable("Cliente"); 
                b.ConfigureByConvention();
				
                b.ToTable("AbpUsers"); //Sharing the same table "AbpUsers" with the IdentityUser
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                //Moved customization to a method so we can share it with the SincaMigrationsDbContext class
                b.ConfigureCustomUserProperties();
            });

            /* Configure your own tables/entities inside the ConfigureSinca method */

            builder.ConfigureSinca();
        }
    }
}
