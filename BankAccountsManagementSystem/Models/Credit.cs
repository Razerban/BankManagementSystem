using System.ComponentModel.DataAnnotations;

namespace BankAccountsManagementSystem.Models
{
    public class Credit
    {
        public int CreditId { get; set; }
        [Display(Name = "Montant")]
        public decimal MontantCredit { get; set; }
        [Display(Name = "A payer sur")]
        public int Planification { get; set; }

        [Display(Name = "Payement monsuel")]
        public decimal PayementMonsuel { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}