namespace ETC.PoliceInquery.DTOs.Request
{
    public class SendPenaltyRequestDto
    {
        public string TrackingCode { get; set; }
        public string BillNumber { get; set; }
        public string ViolationCode { get; set; }
        public string SignData { get; set; }
    }
}
