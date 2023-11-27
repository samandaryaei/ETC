using System.ComponentModel.DataAnnotations;

namespace ETC.PoliceInquery.DTOs.Request
{
    public class SendPenaltyRequestDto : BaseRequestDto
    {
        [Required]
        public string TrackingCode { get; set; }
        [Required]
        public string BillNumber { get; set; }
        [Required]
        public string ViolationCode { get; set; }
        [Required]
        public override string SignData
        {
            get => string.IsNullOrEmpty(SignData) ?
               base.GenSign($"{BillNumber}{TrackingCode}{ViolationCode}") :
               SignData;
        }
    }
}
