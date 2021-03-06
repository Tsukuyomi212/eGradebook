﻿using eGradebook.Models.UserModels.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models.DTOs
{
    public class TeacherTeachesCourseDTO
    {
        public int Id { get; set; }

        public virtual TeacherBasicDTO Teacher { get; set; }

        public virtual SubjectDTO Subject { get; set; }

        public virtual IEnumerable<SchoolClassBasicDTO> SchoolClasses { get; set; }
    }
}