using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.data.Seeds
{
    public class BlogSeeds : IEntityTypeConfiguration<Blog>
    {
        private readonly int[] _id;
        public BlogSeeds(int[] id)
        {
            _id = id;
        }

        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasData(
                new Blog
                {
                    blog_id = 1,
                    baslik = "BlogDeneme",
                    aciklama = "DenemeDenemeDenemeDeneme",
                    olusturulma = DateTime.Now,
                    imageUrl = "",
                    kategori_id = _id[1]
                },
                new Blog
                {
                    blog_id = 2,
                    baslik = "BlogDeneme2",
                    aciklama = "DenemeDenemeDenemeDeneme2",
                    olusturulma = DateTime.Now,
                    imageUrl = "",
                    kategori_id = _id[1]
                }

                );
        }
    }
}
