﻿using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Course
{
    public class UpdatedCourseResponse : BasePageableModel
    {
        public Guid Id { get; set; }
        public int CourseLevelId { get; set; }
        public int SoftwareLanguageId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }
    }
}
