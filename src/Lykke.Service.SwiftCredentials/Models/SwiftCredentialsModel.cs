using System.ComponentModel.DataAnnotations;

namespace Lykke.Service.SwiftCredentials.Models
{
    public class SwiftCredentialsModel
    {
        [Required]
        public string RegulatorId { get; set; }
        [Required]
        public string AssetId { get; set; }
        public string Bic { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string PurposeOfPayment { get; set; }
        public string BankAddress { get; set; }
        public string CompanyAddress { get; set; }
        public string CorrespondentAccount { get; set; }
        public string WithdrawalMessage { get; set; }
    }
}
