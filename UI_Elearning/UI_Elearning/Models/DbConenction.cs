using System.Data.Entity;

namespace UI_Elearning.Models
{
    public class DbConenction : DbContext
    {
        public DbConenction() : base("ConnectString")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}