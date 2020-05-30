using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.data.Seeds
{
    public class VideoSeeds : IEntityTypeConfiguration<Video>
    {
        private readonly int[] _id;
        public VideoSeeds(int[] id)
        {
            _id = id;
        }

        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasData(
                 new 
                 {
                     video_id = 1,
                     baslik = "VideoDeneme",
                     aciklama = "DenemeDenemeDenemeDeneme",
                     olusturulma = DateTime.Now,
                     videoUrl = "",
                     kategori_id = _id[4],
                     video_silme = false
                 },
                 new 
                 {
                     video_id = 2,
                     baslik = "HaberDeneme2",
                     aciklama = "DenemeDenemeDenemeDeneme2",
                     olusturulma = DateTime.Now,
                     videoUrl = "",
                     kategori_id = _id[4],
                     video_silme = false
                 }
                 );

        }
    }
}
