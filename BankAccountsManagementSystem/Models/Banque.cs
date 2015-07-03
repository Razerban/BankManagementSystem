using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccountsManagementSystem.Models
{
    public class Banque
    {
        [Key]
        public string Nom { get; set; }

        public decimal Capital { get; set; }

        [Display(Name = "Nombre de clients")]
        public int NbrClients { get; set; }

        [Display(Name = "Nombre de comptes")]
        public int NbrComptes { get; set; }

        [Display(Name = "Nombre de crédits")]
        public int NbrCredits { get; set; }

        [Display(Name = "Somme totale déposée par tous les clients")]
        public decimal ArgentDepose { get; set; }

        [Display(Name = "Somme totale des crédits")]
        public decimal SommeCredits { get; set; }

        public ICollection<Compte> Comptes { get; set; }
    }
}