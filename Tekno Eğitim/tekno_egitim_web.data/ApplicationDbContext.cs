using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.data.Configurations;
using tekno_egitim_web.data.Seeds;

namespace tekno_egitim_web.data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Kategoriler> Kategoris { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Haber> Habers { get; set; }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Not> Nots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new HaberConfiguration());
            modelBuilder.ApplyConfiguration(new VideoConfiguration());
            modelBuilder.ApplyConfiguration(new NotConfiguration());
            modelBuilder.ApplyConfiguration(new MakaleConfiguration());
            modelBuilder.ApplyConfiguration(new KategoriConfiguration());

            modelBuilder.ApplyConfiguration(new KategoriSeeds(new int[] { 1, 2, 3, 4, 5 }));

            modelBuilder.ApplyConfiguration(new BlogSeeds(new int[] { 1, 2, 3, 4, 5 }));
            modelBuilder.ApplyConfiguration(new HaberSeeds(new int[] { 1, 2, 3, 4, 5 }));
            modelBuilder.ApplyConfiguration(new MakaleSeeds(new int[] { 1, 2, 3, 4, 5 }));
            modelBuilder.ApplyConfiguration(new NotSeeds(new int[] { 1, 2, 3, 4, 5 }));
            modelBuilder.ApplyConfiguration(new VideoSeeds(new int[] { 1, 2, 3, 4, 5 }));

        }

    }
}
