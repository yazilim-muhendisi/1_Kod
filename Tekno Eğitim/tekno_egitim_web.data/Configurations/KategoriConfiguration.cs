using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using tekno_egitim_web.core.Model;

namespace tekno_egitim_web.data.Configurations
{
    public class KategoriConfiguration : IEntityTypeConfiguration<Kategoriler>
    {
        public void Configure(EntityTypeBuilder<Kategoriler> builder)
        {
            builder.HasKey(x => x.kategori_id);
            builder.Property(x => x.kategori_id).UseIdentityColumn();
            builder.Property(x => x.kategori_ad).IsRequired().HasMaxLength(50);
            builder.ToTable("Kategoriler");

        }
    }
}
