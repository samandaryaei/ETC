﻿using System.ComponentModel.DataAnnotations;

namespace ETC.PoliceInquery.Models.DTOs.Request
{
    public class TrackingClassRequestDto : BaseRequestDto
    {
        [Required]
        public string TrackingCode { get; set; }
        [Required]
        public string TrafficUId { get; set; }
        public string? BillNumber { get; set; }
        public string? EventId { get; set; }
        [Required]
        public override string SignData
        {
            get => string.IsNullOrEmpty(SignData) ?
             GenSign($"{TrackingCode}{TrafficUId}{BillNumber}{EventId}") :
             SignData;
        }
    }
}