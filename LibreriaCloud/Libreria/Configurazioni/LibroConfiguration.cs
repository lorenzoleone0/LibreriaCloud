using Libreria.Entita;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Configurazioni
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libri");
            builder.HasKey(l => l.Id_libro);

            builder.Property(l => l.Titolo) 
                .HasColumnName("Titolo")
                .IsRequired();
             
            builder.Property(l => l.Autore)
                .HasColumnName("Autore")
                .IsRequired();

            builder.Property(l => l.DataPubblicazione)
                .HasColumnName("DataPubblicazione")
                .HasColumnType("DATE")
                .IsRequired();
               
            builder.Property(l => l.Editore)
                .HasColumnName("Editore")
                .IsRequired();

            builder.Property(l => l.Categoria)
                .HasColumnName("Categoria")
                .IsRequired(false);
        }
    }

}
