namespace ETC.PoliceInquery.DTOs.Request
{
    public class BillDataRequestDto
    {
        public string TrackingCode { get; set; }
        public string TrafficUId { get; set; }
        public string BillNumber { get; set; }
        public string BillPrice { get; set; }
        public string BillDateTime { get; set; }
        public string EventId { get; set; }
        public string SignData { get; set; }
    }
}
