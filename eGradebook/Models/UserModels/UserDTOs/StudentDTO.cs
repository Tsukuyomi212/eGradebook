﻿using eGradebook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eGradebook.Models.UserModels.UserDTOs
{
    public class StudentDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public ParentBasicDTO Parent { get; set; }
        public SchoolClassBasicDTO SchoolClass { get; set; }


    }
}