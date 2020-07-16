using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperacaoBancaria.Domain.ContaCorrente.Model;
using OperacaoBancaria.Infra.Data.Extensions;

namespace OperacaoBancaria.Infra.Data.Mappings
{
    public class ContaCorrenteMapping : EntityTypeConfiguration<ContaCorrente>
    {
        public override void Map(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("varchar(15)");

            builder.ToTable("ContaCorrente");
        }
    }
}
