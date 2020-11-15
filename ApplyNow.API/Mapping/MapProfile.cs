using System;
using ApplyNow.API.DTOs;
using ApplyNow.API.Models.Request;
using ApplyNow.Core.Models;
using AutoMapper;

namespace ApplyNow.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, UserWithResumesDto>();
            CreateMap<UserWithResumesDto, User>();

            CreateMap<UserDto, UserWithResumesDto>();
            CreateMap<UserWithResumesDto, UserDto>();

            CreateMap<Resume, ResumeDto>();
            CreateMap<ResumeCreateRequestDto, Resume>();
            CreateMap<ResumeCreateRequestDto.EducationRequestDto, Education>();
            CreateMap<ResumeCreateRequestDto.Experience, Experience>();

            CreateMap<Education, EducationDto>();
            CreateMap<EducationDto, Education>();

            CreateMap<Experience, ExperienceDto>();
            CreateMap<ExperienceDto, Experience>();

            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();

            CreateMap<Company, CompanyWithAnnouncementDto>();
            CreateMap<CompanyWithAnnouncementDto, Company>();

            CreateMap<Announcement, AnnouncementDto>();
            CreateMap<AnnouncementDto, Announcement>();

            CreateMap<CompanyDto, CompanyWithAnnouncementDto>();
            CreateMap<CompanyWithAnnouncementDto, CompanyDto>();

            CreateMap<Apply, ApplyDto>();
            CreateMap<ApplyDto, Apply>();

            CreateMap<Apply, ApplyRequestModel>();
            CreateMap<ApplyRequestModel, Apply>();





        }
    }
}
