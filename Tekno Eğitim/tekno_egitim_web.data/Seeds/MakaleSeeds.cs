using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.data.Seeds
{
    public class MakaleSeeds : IEntityTypeConfiguration<Makale>
    {
        private readonly int[] _id;
        public MakaleSeeds(int[] id)
        {
            _id = id;
        }

        public void Configure(EntityTypeBuilder<Makale> builder)
        {
            builder.HasData(
                 new Makale
                 {
                     makale_id = 1,
                     baslik = "MakaleDeneme",
                     aciklama = "DenemeDenemeDenemeDeneme",
                     olusturulma = DateTime.Now,
                     imageUrl = "",
                     kategori_id = _id[3]
                 },
                 new Makale
                 {
                     makale_id = 2,
                     baslik = "MakaleDeneme2",
                     aciklama = "DenemeDenemeDenemeDeneme2",
                     olusturulma = DateTime.Now,
                     imageUrl = "",
                     kategori_id = _id[3]
                 }

                 );
        }
    }
}
