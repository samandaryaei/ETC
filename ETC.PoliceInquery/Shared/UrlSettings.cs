namespace ETC.PoliceInquery.Shared
{
    public class UrlSettings
    {
        public UrlSettings()
        {
        }
        public UrlSettings(string baseUrl,
                           string sendDataUrl,
                           string sendPicUrl,
                           string sendBillUrl,
                           string paymentBilUrl,
                           string sendPenaltyUrl,
                           string trackingClassUrl,
                           string checkBarcodePlateUrl)
        {
            BaseUrl = baseUrl;
            SendDataUrl = sendDataUrl;
            SendPicUrl = sendPicUrl;
            SendBillUrl = sendBillUrl;
            PaymentBilUrl = paymentBilUrl;
            SendPenaltyUrl = sendPenaltyUrl;
            TrackingClassUrl = trackingClassUrl;
            CheckBarcodePlateUrl = checkBarcodePlateUrl;
        }

        public string BaseUrl { get; set; }
        public string SendDataUrl { get; set; }
        public string SendPicUrl { get; set; }
        public string SendBillUrl { get; set; }
        public string PaymentBilUrl { get; set; }
        public string SendPenaltyUrl { get; set; }
        public string TrackingClassUrl { get; set; }
        public string CheckBarcodePlateUrl { get; set; }
    }
}
