using System.ComponentModel.DataAnnotations;

namespace ETC.PoliceInquery.Models.DTOs.Request.EntranceRequests
{
    /// <summary>
    /// 
    /// </summary>
    public class BillDataEntranceRequestDto
    {
        [Required]
        public string TrackingCode { get; set; }
        [Required]
        public string TrafficUId { get; set; }
        [Required]
        public string BillNumber { get; set; }
        [Required]
        public string BillPrice { get; set; }
        [Required]
        public string BillDateTime { get; set; }
        [Required]
        public string EventId { get; set; }
    }
}
