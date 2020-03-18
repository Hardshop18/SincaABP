using System.Threading.Tasks;

namespace Sinca.Data
{
    public interface ISincaDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
