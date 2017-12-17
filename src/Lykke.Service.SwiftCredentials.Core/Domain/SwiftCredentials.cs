﻿namespace Lykke.Service.SwiftCredentials.Core.Domain
{
    public class SwiftCredentials : ISwiftCredentials
    {
        public string RegulationId { get; set; }
        public string AssetId { get; set; }
        public string Bic { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string PurposeOfPayment { get; set; }
        public string BankAddress { get; set; }
        public string CompanyAddress { get; set; }
        public string CorrespondentAccount { get; set; }
    }
}
