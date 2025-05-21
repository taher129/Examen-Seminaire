using System.ComponentModel.DataAnnotations;

namespace Examen.ApplicationCore.Domain;

public class Inscription
{
    public DateTime DateInscription { get; set; }
    public double TauxReduction { get; set; }
    public int ParticipantFK { get; set; }
    public virtual Participant MyParticipant { get; set; }
    public int SeminaireFK { get; set; }
    public virtual Seminaire MSeminaire { get; set; }

}