using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.data.Seeds
{
    public class HaberSeeds : IEntityTypeConfiguration<Haber>
    {
        private readonly int[] _id;
        public HaberSeeds(int[] id)
        {
            _id = id;
        }

        public void Configure(EntityTypeBuilder<Haber> builder)
        {
            builder.HasData(
                  new Haber
                  {
                      haber_id = 1,
                      baslik = "HaberDeneme",
                      aciklama = "DenemeDenemeDenemeDeneme",
                      olusturulma = DateTime.Now,
                      imageUrl = "",
                      kategori_id = _id[2]
                  },
                  new Haber
                  {
                      haber_id = 2,
                      baslik = "HaberDeneme2",
                      aciklama = "DenemeDenemeDenemeDeneme2",
                      olusturulma = DateTime.Now,
                      imageUrl = "",
                      kategori_id = _id[2]
                  }
                  );
        }
    }
}
