namespace ETC.PoliceInquery.DTOs.Request
{
    public class SendPicRequestDto
    {
        public string TrackingCode { get; set; }
        public string TrafficUId { get; set; }
        public string VehiclePic { get; set; }
        public string PlatePic { get; set; }
        public string SignData { get; set; }
    }
}
