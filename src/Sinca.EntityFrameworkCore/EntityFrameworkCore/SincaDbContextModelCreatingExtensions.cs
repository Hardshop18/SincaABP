using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users;

namespace Sinca.EntityFrameworkCore
{
    public static class SincaDbContextModelCreatingExtensions
    {
        public static void ConfigureSinca(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

			builder.Entity<Cliente>(b =>
            {
                b.ToTable("Cliente");
                b.ConfigureByConvention();
                b.Property(x => x.Nome).IsRequired().HasMaxLength(128);
                b.Property(x => x.Observacao).IsRequired().HasMaxLength(128);
            });
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser: class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}