using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BankAccountsManagementSystem.Models
{
    public enum TypeOperation
    {
        Retrait,Depot
    }

    public class Operation
    {
        [Display(Name = "Numéro opération")]
        public int OperationId { get; set; }
        public TypeOperation? Type { get; set; }

        [Required]
        public decimal Montant { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Numéro de compte")]
        public int CompteId { get; set; }
        public virtual Compte Compte { get; set; }
    }
}