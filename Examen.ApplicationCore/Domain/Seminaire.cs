using System.ComponentModel.DataAnnotations;

namespace Examen.ApplicationCore.Domain;

public class Seminaire
{
    [Key]
    public int Code { get; set; }
    public string Intitule { get; set; }
    public string Lieu { get; set; }
    public double Tarif { get; set; }
    public DateTime DateSeminaire { get; set; }
    [Range(1,100, ErrorMessage = "Capacity max depacé")]
    public int NombreMaximal { get; set; }
    public virtual IList<Inscription> Inscriptions { get; set; }
}