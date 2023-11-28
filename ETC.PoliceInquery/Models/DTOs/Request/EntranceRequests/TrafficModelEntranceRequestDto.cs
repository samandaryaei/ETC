using System.ComponentModel.DataAnnotations;

namespace ETC.PoliceInquery.Models.DTOs.Request.EntranceRequests
{
    public class TrafficModelEntranceRequestDto
    {
        [Required]
        public string TrafficDate { get; set; }
        [Required]
        public string TrafficTime { get; set; }
        [Required]
        public string PlateNumber { get; set; }
        [Required]
        public string FreewayCode { get; set; }
        [Required]
        public string CameraCode { get; set; }
        [Required]
        public string TrafficUId { get; set; }
    }
}
