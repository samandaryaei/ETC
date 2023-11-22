namespace ETC.PoliceInquery.DTOs.Request
{
    public class SendPenaltyResponseDto
    {
        public string TrackingCode { get; set; }
        public string vehicleClass { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string SignData { get; set; }
    }
}
