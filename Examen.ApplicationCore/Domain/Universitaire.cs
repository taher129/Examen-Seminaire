namespace Examen.ApplicationCore.Domain;

public class Universitaire:Participant
{
    public string Niveau { get; set; }
    public string NomInstitu { get; set; }

    public virtual Specialite Specialite { get; set; }
}