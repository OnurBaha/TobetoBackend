﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.LanguageLevel
{
    public class UpdateLanguageLevelRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
