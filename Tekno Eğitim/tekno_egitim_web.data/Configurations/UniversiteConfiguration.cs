using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Models;

namespace tekno_egitim_web.data.Configurations
{
    public class UniversiteConfiguration : IEntityTypeConfiguration<Universite>
    {
        public void Configure(EntityTypeBuilder<Universite> builder)
        {
            builder.HasKey(x => x.uni_id);
            builder.Property(x => x.uni_id).UseIdentityColumn();
            builder.ToTable("UNIVERSITELER");

        }
    }
}
