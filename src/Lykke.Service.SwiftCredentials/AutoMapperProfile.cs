using AutoMapper;
using Lykke.Service.SwiftCredentials.Core.Domain;
using Lykke.Service.SwiftCredentials.Models;

namespace Lykke.Service.SwiftCredentials
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ISwiftCredentials, SwiftCredentialsModel>(MemberList.Source);
            CreateMap<SwiftCredentialsModel, Core.Domain.SwiftCredentials>(MemberList.Destination);
        }
    }
}
