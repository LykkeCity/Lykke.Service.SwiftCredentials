using MessagePack;

namespace Lykke.Service.SwiftCredentials.Contracts
{
    [MessagePackObject(true)]
    public class SwiftCredentialsRequestedEvent
    {
        public string Email { set; get; }
        public string PartnerId { set; get; }
        public string RegulatorId { get; set; }
        public string AssetId { get; set; }
        public string ClientName { get; set; }
        public string AssetSymbol { get; set; }
        public double Amount { get; set; }
        public string Year { get; set; }
        public string Bic { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string PurposeOfPaymentTemplate { get; set; }
        public string BankAddress { get; set; }
        public string CompanyAddress { get; set; }
        public string CorrespondentAccount { get; set; }
    }
}
