﻿namespace Lykke.Service.SwiftCredentials.Models
{
    public class EmailRequestCommand
    {
        public string ClientId { set; get; }
        public string PartnerId { set; get; }
        public string RegulationId { set; get; }
        public double Amount { set; get; }
        public string AssetId { set; get; }
    }
}
