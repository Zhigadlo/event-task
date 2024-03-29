﻿using AutoMapper;
using Entities;
using Entities.DatatTransferObjects.SpeakerDtos;

namespace event_web_api.BLL.Mapper
{
    public class SpeakerProfile : Profile
    {
        public SpeakerProfile()
        {
            CreateMap<SpeakerDto, Speaker>().ReverseMap();
            CreateMap<SpeakerForCreationDto, Speaker>();
        }
    }
}
