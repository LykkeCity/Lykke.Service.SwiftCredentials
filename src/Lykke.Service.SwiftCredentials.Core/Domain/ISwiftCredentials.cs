﻿namespace Lykke.Service.SwiftCredentials.Core.Domain
{
    public interface ISwiftCredentials
    {
        string RegulationId { get; set; }
        string AssetId { get; set; }
        string Bic { get; set; }
        string AccountNumber { get; set; }
        string AccountName { get; set; }
        string PurposeOfPayment { get; set; }
        string BankAddress { get; set; }
        string CompanyAddress { get; set; }
        string CorrespondentAccount { get; set; }
    }
}
