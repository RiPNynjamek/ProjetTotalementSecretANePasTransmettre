namespace WebService.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserTokenDBContext : DbContext
    {
        public UserTokenDBContext()
            : base("name=UserTokenDBContext")
        {
        }

        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<TokenApi> TokenApi { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Token>()
                .Property(e => e.Token1)
                .IsUnicode(false);

            modelBuilder.Entity<TokenApi>()
                .Property(e => e.TokenApi1)
                .IsUnicode(false);

            modelBuilder.Entity<TokenApi>()
                .Property(e => e.ApplicationName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Token)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
