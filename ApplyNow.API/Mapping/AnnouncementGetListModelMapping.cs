using System;
using System.Collections.Generic;
using System.Linq;
using ApplyNow.API.DTOs;
using ApplyNow.API.Models.Response;
using ApplyNow.Core.Models;

namespace ApplyNow.API.Mapping
{
    public static class AnnouncementGetListModelMapping
    {
        public static AnnouncementGetListResponseModel ToAnnouncementGetListMappingModel(this List<Apply> model)
        {
            if (model != null && model.Count > 0)
            {
                AnnouncementGetListResponseModel responseModel = new AnnouncementGetListResponseModel();
                var announcement = model.FirstOrDefault().Announcement;

                responseModel.Description = announcement.Description;
                responseModel.Location = announcement.Location;
                responseModel.CreatedDate = announcement.CreatedDate;
                responseModel.EndDate = announcement.EndDate;

                responseModel.Resumes = new List<ResumeDto>();

                foreach (var item in model)
                {
                    if (item.Resume != null) {

                        var educations = new List<EducationDto>();
                        var experiences = new List<ExperienceDto>();


                        foreach (var education in item.Resume.Educations)
                        {
                            educations.Add(new EducationDto
                            {
                                Name = education.Name,
                                Department = education.Department,
                                EndDate = education.EndDate
                            });
                        }

                        foreach (var experience in item.Resume.Experiences)
                        {
                            experiences.Add(new ExperienceDto
                            {
                                Title = experience.Title,
                                CompanyName = experience.CompanyName,
                                StartDate = experience.StartDate,
                                EndDate = experience.EndDate
                            });
                        }

                        var resume = new ResumeDto()
                        {
                            CreatedDate = item.Resume.CreatedDate,
                            Educations =  educations,
                            Experiences = experiences
                        };

                        responseModel.Resumes.Add(resume);
                    }
                }

                return responseModel;

            }

            return null;
        }
    }
}
