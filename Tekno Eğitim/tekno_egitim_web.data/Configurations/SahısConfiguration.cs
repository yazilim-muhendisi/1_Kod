using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Models;

namespace tekno_egitim_web.data.Configurations
{
    public class SahısConfiguration : IEntityTypeConfiguration<Sahıs>
    {
        public void Configure(EntityTypeBuilder<Sahıs> builder)
        {
            builder.HasKey(x => x.sahis_id);
            builder.Property(x => x.sahis_id).UseIdentityColumn();
            builder.ToTable("Sahis");
            builder.Property(x => x.sahis_ad).HasMaxLength(100);
            builder.Property(x => x.sahis_soyad).HasMaxLength(100);

        }
    }
}
