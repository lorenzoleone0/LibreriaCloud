using Libreria.Entita;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Configurazioni
{
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            
            builder.ToTable("Utenti");
            builder.HasKey(u => u.Id_utente);                

            builder.Property(u => u.Nome)
                .HasColumnName("Nome")
                .IsRequired();


            builder.Property(u => u.Cognome)
                .HasColumnName("Cognome")
                .IsRequired();


            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnName("Password")
                .IsRequired();
        }
    }
}
