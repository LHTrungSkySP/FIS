using System.Data.Entity;

namespace register_log_in03.Models
{
    public class ContextDB : DbContext
    {
        public ContextDB() : base("ContextDB")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}