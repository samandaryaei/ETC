namespace ETC.PoliceInquery.DTOs.Request
{
    public class TrafficModelRequestDto
    {
        public string TrafficDate { get; set; }
        public string TrafficTime { get; set; }
        public string PlateNumber { get; set; }
        public string FreewayCode { get; set; }
        public string CameraCode { get; set; }
        public string TrafficUId { get; set; }
        public string SignData { get; set; }
    }
}
