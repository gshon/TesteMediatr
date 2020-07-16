using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperacaoBancaria.Domain.Lancamentos.Model;
using OperacaoBancaria.Infra.Data.Extensions;

namespace OperacaoBancaria.Infra.Data.Mappings
{
    public class LancamentosMapping : EntityTypeConfiguration<Lancamentos>
    {
        public override void Map(EntityTypeBuilder<Lancamentos> builder)
        {
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Lancamentos");
        }
    }
}
