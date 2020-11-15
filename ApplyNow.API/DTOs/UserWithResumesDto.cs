using System;
using System.Collections.Generic;

namespace ApplyNow.API.DTOs
{
    public class UserWithResumesDto : UserDto
    {
        public ResumeDto Resume { get; set; }

    }
}
