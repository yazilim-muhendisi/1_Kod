using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.data.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasKey(x => x.video_id);
            builder.Property(x => x.video_id).UseIdentityColumn();
            builder.ToTable("Video");
            builder.Property(x => x.baslik).IsRequired().HasMaxLength(200);
            builder.Property(x => x.aciklama);
            builder.Property(x => x.olusturulma).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.videoUrl).HasMaxLength(200);
            builder.Property(x => x.video_silme);
            builder.Property(x => x.izlenme_sayisi);
        }
    }
}
