using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccountsManagementSystem.Models
{
    public class Client
    {
        [Display(Name = "Numéro client")]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nom { get; set; }

        [Required]
        [StringLength(50)]
        public string Adresse { get; set; }

        public virtual ICollection<Compte> Comptes { get; set; }

    }
}