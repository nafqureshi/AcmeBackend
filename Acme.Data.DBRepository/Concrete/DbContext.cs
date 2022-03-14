using Acme.Data.DBRepository.Entity;
using Microsoft.EntityFrameworkCore;

namespace Acme.Data.DBRepository.Concrete
{
   
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserActivity>().HasKey(a => new { a.Email, a.Activity });
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserActivity> UserActivity { get; set; }

        public void InsertUserActivity(User user, UserActivity userActivity)
        {
            User.Add(user);
            UserActivity.Add(userActivity);

            SaveChanges();
        }

        public void UpdateUserActivity(User user, UserActivity userActivity, bool newUserActivity = false)
        {
            Update(user);
            if(newUserActivity)
                UserActivity.Add(userActivity);
            else
                Update(userActivity);

            SaveChanges();
        }
    }
}
