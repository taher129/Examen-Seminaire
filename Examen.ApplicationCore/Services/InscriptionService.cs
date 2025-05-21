using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Examen.ApplicationCore.Domain;

namespace Examen.ApplicationCore.Services;

public class InscriptionService: Service<Inscription>, IInscriptionService
{
    public InscriptionService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public IList<Participant> getparticipantsparSeminaire(Seminaire s)
    {
        return GetMany().Where(i => i.MSeminaire == s)
            .Select(i=>i.MyParticipant).ToList();
    }

    public IList<Specialite> getspecialitesparDateEtSeminare(DateTime d)
    {
        return GetMany().Where(i => i.MSeminaire.DateSeminaire == d)
            .Select(i => i.MyParticipant)
            .OfType<Universitaire>()
            .Select(u=>u.Specialite)
            .Distinct().ToList();
    }

    public int tauxParticipant(DateTime d)
    {
        return GetMany()
            .Where(i => i.MSeminaire.DateSeminaire.Year == d.Year)
            .Select(i => i.MyParticipant).Count();
            


    }
}