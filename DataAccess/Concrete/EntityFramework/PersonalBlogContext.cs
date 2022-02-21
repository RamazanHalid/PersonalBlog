using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlamak
    public class PersonalBlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=20.79.248.55;port=5432;Database = RamazanBlog; Username = ramazanhalid; Password = Terra2010*");
            //optionsBuilder.UseNpgsql(@"Server=localhostw;Database=RamazanBlogw;Trusted_Connection=true");
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<WhatIDo> WhatIDos { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.ToTable("BlogCategories");

                entity.HasMany(i => i.Blogs)
                    .WithOne(i => i.BlogCategory)
                    .HasForeignKey(i => i.BlogCategoryId)
                    .HasConstraintName("blogCategoryBlogIdFK");

            });
        }
    }
}
