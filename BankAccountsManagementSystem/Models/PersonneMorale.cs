using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BankAccountsManagementSystem.Models
{
    public class PersonneMorale : Client
    {
        [Required]
        [RegularExpression("[0-9]{7}", ErrorMessage = "Le matricul fiscal doit contenir exactement 7 chiffres")]
        [Display(Name = "Matricul fiscal")]
        [Remote("IsMatriculFiscalAvailable", "MatriculFiscal", ErrorMessage = "Client existant")]
        public string MatriculFiscal { get; set; }
    }
}