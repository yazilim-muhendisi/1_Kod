using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.data.Configurations
{
    class HaberConfiguration : IEntityTypeConfiguration<Haber>
    {
        public void Configure(EntityTypeBuilder<Haber> builder)
        {
            builder.HasKey(x => x.haber_id);
            builder.Property(x => x.haber_id).UseIdentityColumn();
            builder.ToTable("Haber");
            builder.Property(x => x.baslik).IsRequired().HasMaxLength(200);
            builder.Property(x => x.aciklama).IsRequired();
            builder.Property(x => x.olusturulma).IsRequired().HasColumnType("datetime"); 
            builder.Property(x => x.imageUrl).HasMaxLength(200);
            builder.Property(x => x.haber_silme);
            builder.Property(x => x.haber_görüntüleme);
        }
    }
}
