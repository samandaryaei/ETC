using System.ComponentModel.DataAnnotations;

namespace ETC.PoliceInquery.Models.DTOs.Request.EntranceRequests
{
    public class TrackingClassEntranceRequestDto
    {
        [Required]
        public string TrackingCode { get; set; }
        [Required]
        public string TrafficUId { get; set; }
        public string? BillNumber { get; set; }
        public string? EventId { get; set; }
    }
}
