using System.ComponentModel.DataAnnotations;

namespace ETC.PoliceInquery.Models.DTOs.Request.EntranceRequests
{
    public class SendPenaltyEntranceRequestDto
    {
        [Required]
        public string TrackingCode { get; set; }
        [Required]
        public string BillNumber { get; set; }
        [Required]
        public string ViolationCode { get; set; }
    }
}
