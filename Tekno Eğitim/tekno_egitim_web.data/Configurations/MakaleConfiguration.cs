using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Model;
namespace tekno_egitim_web.data.Configurations
{
    public class MakaleConfiguration : IEntityTypeConfiguration<Makale>
    {
        public void Configure(EntityTypeBuilder<Makale> builder)
        {
            builder.HasKey(x => x.makale_id);
            builder.Property(x => x.makale_id).UseIdentityColumn();
            builder.ToTable("Makale");
            builder.Property(x => x.baslik).IsRequired().HasMaxLength(200);
            builder.Property(x => x.aciklama).IsRequired();
            builder.Property(x => x.olusturulma).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.imageUrl).HasMaxLength(200);
            builder.Property(x => x.makale_silme);
        }
    }
}
