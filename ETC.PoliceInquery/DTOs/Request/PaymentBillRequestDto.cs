namespace ETC.PoliceInquery.DTOs.Request
{
    public class PaymentBillRequestDto
    {
        public string TrackingCode { get; set; }
        public string BillNumber { get; set; }
        public string PaymentPrice { get; set; }
        public string PaymentDateTime { get; set; }
        public string PayoffStatus { get; set; }
        public string SignData { get; set; }
    }
}
