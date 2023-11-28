using ETC.PoliceInquery.Shared;
using System.ComponentModel.DataAnnotations;

namespace ETC.PoliceInquery.Models.DTOs.Request
{
    public class SendPicRequestDto : BaseRequestDto
    {
        [Required]
        public string TrackingCode { get; set; }
        [Required]
        public string TrafficUId { get; set; }
        [Required]
        public string VehiclePic { get; set; }
        [Required]
        public string PlatePic { get; set; }
        [Required]
        public override string SignData
        {
            get => string.IsNullOrEmpty(SignData) ?
              GenSign($"{TrackingCode}{TrafficUId}") :
              SignData;
        }
    }
}
