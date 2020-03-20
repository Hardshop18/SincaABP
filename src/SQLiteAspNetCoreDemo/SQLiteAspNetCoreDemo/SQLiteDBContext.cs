using Microsoft.EntityFrameworkCore;

namespace SQLiteAspNetCoreDemo
{
    public class SQLiteDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string path = System.Environment.CurrentDirectory.ToString()+"\\..\\..\\..\\";
            options.UseSqlite($"Data Source={path}sqlitedemo.db");
        }
    }
}
