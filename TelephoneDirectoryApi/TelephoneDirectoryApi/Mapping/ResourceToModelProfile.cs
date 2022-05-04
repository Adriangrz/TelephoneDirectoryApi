using AutoMapper;
using TelephoneDirectoryApi.Models;

namespace TelephoneDirectoryApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<EntryInTelephoneDirectoryResource, EntryInTelephoneDirectory>();
        }
    }
}
