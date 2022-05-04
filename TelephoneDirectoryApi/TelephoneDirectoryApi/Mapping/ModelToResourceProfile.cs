using AutoMapper;
using TelephoneDirectoryApi.Models;

namespace TelephoneDirectoryApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<EntryInTelephoneDirectory, EntryInTelephoneDirectoryResource>();
        }
    }
}
