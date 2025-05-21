using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examen.Infrastructure.Configurations;

public class InscriptionConfig : IEntityTypeConfiguration<Inscription>
{
    public void Configure(EntityTypeBuilder<Inscription> builder)
    {

        builder.HasOne(i => i.MSeminaire)
            .WithMany(s => s.Inscriptions)
            .HasForeignKey(i=>i.SeminaireFK)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.MyParticipant)
            .WithMany(s => s.Inscriptions)
            .HasForeignKey(i => i.ParticipantFK)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasKey(i => new { i.SeminaireFK, 
                i.ParticipantFK, i.DateInscription });
            


    }
}