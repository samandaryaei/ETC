namespace ETC.PoliceInquery.DTOs.Response
{
    public class BaseResponseDto
    {
        public string TrackingCode { get; set; }
        public string VehicleClass { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string SignData { get; set; }
    }
}
