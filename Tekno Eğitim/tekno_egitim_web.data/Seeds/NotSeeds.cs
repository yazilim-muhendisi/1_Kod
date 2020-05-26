using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.data.Seeds
{
    public class NotSeeds : IEntityTypeConfiguration<Not>
    {
        private readonly int[] _id;
        public NotSeeds(int[] id)
        {
            _id = id;
        }

        public void Configure(EntityTypeBuilder<Not> builder)
        {
            builder.HasData(
                  new Not
                  {
                      not_id = 1,
                      baslik = "NotDeneme",
                      aciklama = "DenemeDenemeDenemeDeneme",
                      olusturulma = DateTime.Now,
                      imageUrl = "",
                      kategori_id = _id[4]
                  },
                  new Not
                  {
                      not_id = 2,
                      baslik = "NotDeneme2",
                      aciklama = "DenemeDenemeDenemeDeneme2",
                      olusturulma = DateTime.Now,
                      imageUrl = "",
                      kategori_id = _id[4]
                  }

                  );
        }
    }
}
