﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Courses
{
    public class CourseSubject : Entity<int>
    {
        public int SubjectId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
