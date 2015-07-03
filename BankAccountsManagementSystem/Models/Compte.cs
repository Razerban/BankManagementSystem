using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccountsManagementSystem.Models
{
    public enum TypeCompte
    {
        Epargne,
        Courant,
        Professionnel
    }

    public class Compte
    {
        [Display(Name = "Numéro de compte")]
        public int CompteId { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        public TypeCompte? Type { get; set; }

        [Display(Name = "Solde")]
        public decimal SoldeBase { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date ouverture")]
        public DateTime DateOuverture { get; set; }

        public virtual Banque Banque { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Credit> Credits { get; set; }
    }
}