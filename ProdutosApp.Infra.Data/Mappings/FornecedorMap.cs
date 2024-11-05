using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("FORNECEDOR");
            
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id).HasColumnName("ID");
            builder.Property(f => f.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();


        }
    }
}
