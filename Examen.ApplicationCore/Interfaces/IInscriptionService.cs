using Examen.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces;

public interface IInscriptionService : IService<Inscription>
{
    IList<Participant> getparticipantsparSeminaire(Seminaire s);
    IList<Specialite> getspecialitesparDateEtSeminare(DateTime d);
    int tauxParticipant(DateTime d);
}