using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.blog_id);
            builder.Property(x => x.blog_id).UseIdentityColumn();
            builder.ToTable("Blog");
            builder.Property(x => x.baslik).IsRequired().HasMaxLength(200);
            builder.Property(x => x.aciklama).IsRequired();
            builder.Property(x => x.olusturulma).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.imageUrl).HasMaxLength(200);
            builder.Property(x => x.blog_silme);
        }
    }
}
