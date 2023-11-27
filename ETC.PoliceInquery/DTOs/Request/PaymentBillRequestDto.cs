using ETC.PoliceInquery.Shared;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace ETC.PoliceInquery.DTOs.Request
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
        [Required]
        public override string SignData
        {
            get => string.IsNullOrEmpty(SignData) ?
               base.GenSign($"{TrackingCode}" +
                $"{BillNumber}" +
                $"{PaymentPrice}" +
                $"{PaymentDateTime}" +
                $"{(short)Enum.Parse(typeof(PayOffStatus), PayoffStatus)}") :
               SignData;
        }
    }
}
