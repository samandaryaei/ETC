using System.ComponentModel.DataAnnotations;

namespace ETC.PoliceInquery.Models.DTOs.Request
{
    public class TrafficModelRequestDto : BaseRequestDto
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
        [Required]
        public override string SignData
        {
            get => string.IsNullOrEmpty(SignData) ?
            GenSign($"{TrafficUId}{PlateNumber}{TrafficDate}{TrafficTime}{CameraCode}{FreewayCode}") :
            SignData;
        }
    }
}
