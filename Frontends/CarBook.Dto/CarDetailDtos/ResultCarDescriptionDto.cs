﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarDetailDtos
{
    public class ResultCarDescriptionDto
    {
        public int CarDescriptionID { get; set; }
        public int CarID { get; set; }
        public string? Details { get; set; }
    }
}
