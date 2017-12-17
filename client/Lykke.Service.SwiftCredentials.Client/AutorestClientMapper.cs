namespace Lykke.Service.SwiftCredentials.Client
{
    public static class AutorestClientMapper
    {
        public static Models.SwiftCredentialsModel Map(this AutorestClient.Models.SwiftCredentialsModel model)
        {
            return new Models.SwiftCredentialsModel
            {
                RegulationId= model.RegulationId,
                AssetId = model.AssetId,
                Bic = model.Bic,
                AccountNumber = model.AccountNumber,
                AccountName = model.AccountName,
                PurposeOfPayment = model.PurposeOfPayment,
                BankAddress = model.BankAddress,
                CompanyAddress = model.CompanyAddress,
                CorrespondentAccount = model.CorrespondentAccount
            };
        }

        public static AutorestClient.Models.SwiftCredentialsModel Map(this Models.SwiftCredentialsModel model)
        {
            return new AutorestClient.Models.SwiftCredentialsModel
            {
                RegulationId = model.RegulationId,
                AssetId = model.AssetId,
                Bic = model.Bic,
                AccountNumber = model.AccountNumber,
                AccountName = model.AccountName,
                PurposeOfPayment = model.PurposeOfPayment,
                BankAddress = model.BankAddress,
                CompanyAddress = model.CompanyAddress,
                CorrespondentAccount = model.CorrespondentAccount
            };
        }
    }
}
