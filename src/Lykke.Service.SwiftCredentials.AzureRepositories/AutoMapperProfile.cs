using AutoMapper;
using Lykke.Service.SwiftCredentials.Core.Domain;

namespace Lykke.Service.SwiftCredentials.AzureRepositories
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ISwiftCredentials, SwiftCredentialsEntity>(MemberList.Source)
                .IgnoreTableEntityFields()
                .ReverseMap();
        }

        public override string ProfileName => "EntityMapper";
    }
}
