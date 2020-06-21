using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Models;
using tekno_egitim_web.data.Configurations;


namespace tekno_egitim_web.data
{
    public partial class SiteDbContext : DbContext
    {
        public SiteDbContext()
        {
        }

        public SiteDbContext(DbContextOptions<SiteDbContext> options)
            : base(options)
        {
        }
        public DbSet<Kategoriler> Kategoris { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Haber> Habers { get; set; }
        public DbSet<Makale> Makales { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Not> Nots { get; set; }
        public DbSet<Universite> Universites { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new HaberConfiguration());
            modelBuilder.ApplyConfiguration(new VideoConfiguration());
            modelBuilder.ApplyConfiguration(new NotConfiguration());
            modelBuilder.ApplyConfiguration(new MakaleConfiguration());
            modelBuilder.ApplyConfiguration(new KategoriConfiguration());
            modelBuilder.ApplyConfiguration(new UniversiteConfiguration());

          
        }

    }
}
