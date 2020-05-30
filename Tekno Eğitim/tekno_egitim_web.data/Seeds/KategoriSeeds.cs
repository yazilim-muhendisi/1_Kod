using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.data.Seeds
{
    public class KategoriSeeds : IEntityTypeConfiguration<Kategoriler>
    {
        private readonly int[] _id;
        public KategoriSeeds(int[] id)
        {
            _id = id;
        }

        public void Configure(EntityTypeBuilder<Kategoriler> builder)
        {
            builder.HasData(
                 new Kategoriler
                 {
                     kategori_id = _id[0],
                     kategori_ad = "Blog",

                 },
                 new Kategoriler
                 {
                     kategori_id = _id[1],
                     kategori_ad = "Haber",

                 },
                 new Kategoriler
                 {
                     kategori_id = _id[2],
                     kategori_ad = "Makale",

                 },
                 new Kategoriler
                 {
                     kategori_id = _id[3],
                     kategori_ad = "Not",

                 },
                 new Kategoriler
                 {
                     kategori_id = _id[4],
                     kategori_ad = "Video",

                 });

        }
    }
}
