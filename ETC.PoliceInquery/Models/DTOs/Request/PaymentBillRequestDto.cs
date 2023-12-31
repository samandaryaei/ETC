﻿using ETC.PoliceInquery.Shared;
using System.ComponentModel.DataAnnotations;

namespace ETC.PoliceInquery.Models.DTOs.Request
{
    public class PaymentBillRequestDto : BaseRequestDto
    {
        [Required]
        public string TrackingCode { get; set; }
        [Required]
        public string BillNumber { get; set; }
        [Required]
        public string PaymentPrice { get; set; }
        [Required]
        public string PaymentDateTime { get; set; }
        [Required]
        public string PayoffStatus { get; set; }
    }
}
