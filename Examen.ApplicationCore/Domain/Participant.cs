using System.ComponentModel.DataAnnotations;

namespace Examen.ApplicationCore.Domain;

public class Participant
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Nom { get; set; }
    [Required]
    [StringLength(50)]
    public string Prenom { get; set; }
    [Display(Name = "Address Email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DataType(DataType.PhoneNumber)]
    public int NumeroTelephone { get; set; }


    public virtual IList<Inscription> Inscriptions { get; set; }

}