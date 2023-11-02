using AutoMapper;
using Entities;
using Entities.DatatTransferObjects.EventDtos;

namespace event_web_api.BLL.Mapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventDto, Event>().ReverseMap();
            CreateMap<EventForCreationDto, Event>();
            CreateMap<EventForUpdateDto, Event>();
        }
    }
}
