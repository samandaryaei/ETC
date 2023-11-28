using System.ComponentModel.DataAnnotations;

namespace ETC.PoliceInquery.Models.DTOs.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class BillDataRequestDto : BaseRequestDto
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
        [Required]
        public override string SignData
        {
            get => string.IsNullOrEmpty(SignData) ?
                GenSign($"{TrackingCode}{TrafficUId}{EventId}{BillNumber}{BillPrice}{BillDateTime}") :
                SignData;
        }
    }
}
