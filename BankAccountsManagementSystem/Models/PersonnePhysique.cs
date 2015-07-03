using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BankAccountsManagementSystem.Models
{
    public class PersonnePhysique : Client
    {
        [Required]
        [StringLength(20)]
        public string Prénom { get; set; }

        [Required]
        [RegularExpression("[0-9]{8}", ErrorMessage = "Le CIN doit contenir exactement 8 chiffres")]
        [Remote("IsCinAvailable", "Cin", ErrorMessage = "Client existant")]
        public string Cin { get; set; }

        [Required]
        [StringLength(30)]
        public string Profession { get; set; }

        [Required]
        [RegularExpression("[0-9]{8}", ErrorMessage = "Le numéro de téléphone doit contenir exactement 8 chiffres")]
        public string Telephone { get; set; }

        [Required]
        public decimal Salaire { get; set; }

    }
}