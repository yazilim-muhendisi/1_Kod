using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Model;
namespace tekno_egitim_web.data.Configurations
{
    public class NotConfiguration : IEntityTypeConfiguration<Not>
    {
        public void Configure(EntityTypeBuilder<Not> builder)
        {
            builder.HasKey(x => x.not_id);
            builder.Property(x => x.not_id).UseIdentityColumn();
            builder.ToTable("Not");
            builder.Property(x => x.baslik).IsRequired().HasMaxLength(200);
            builder.Property(x => x.aciklama).IsRequired();
            builder.Property(x => x.olusturulma).IsRequired().HasColumnType("datetime"); //HasDefaultValueSql("getdate()")
            builder.Property(x => x.imageUrl).HasMaxLength(200);
        }
    }
}
