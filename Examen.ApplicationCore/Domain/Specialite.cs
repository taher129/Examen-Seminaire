using System.ComponentModel.DataAnnotations;

namespace Examen.ApplicationCore.Domain;

public class Specialite
{
    [Key]
    public int SpecialiteId { get; set; }
    public string Nom { get; set; }
    public string Abreviation { get; set; }

    public virtual IList<Universitaire> Universitaires { get; set; }
}