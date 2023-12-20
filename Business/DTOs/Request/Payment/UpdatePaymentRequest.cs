﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Payment
{
    public class UpdatePaymentRequest
    {
        public int Id { get; set; }
        public int StudentCourseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool? Status { get; set; }
    }
}
