using AutoMapper;
using ETC.PoliceInquery.Authorization;
using ETC.PoliceInquery.HttpClient;
using ETC.PoliceInquery.Models.DTOs.Request;
using ETC.PoliceInquery.Models.DTOs.Request.EntranceRequests;
using ETC.PoliceInquery.Models.DTOs.Response;
using ETC.PoliceInquery.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETC.PoliceInquery.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PoliceInquery : ControllerBase
    {
        private readonly ILogger<PoliceInquery> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpClientHelperAsync _httpClientHelperAsync;
        private readonly IMapper _mapper;

        private readonly IHttpClientFactory _httpClientFactory;

        private UrlSettings Urls;

        public PoliceInquery(ILogger<PoliceInquery> logger,
                             IConfiguration configuration,
                             IWebHostEnvironment webHostEnvironment,
                             IHttpClientHelperAsync httpClientHelperAsync,
                             IMapper mapper,
                             IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _httpClientHelperAsync = httpClientHelperAsync;
            _mapper = mapper;

            Urls = _configuration.GetSection("Urls").Get<UrlSettings>();
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost(Name = "SendTrafficData")]
        public async Task<IActionResult> SendTrafficData(TrafficModelEntranceRequestDto body)
        {
            var requestBody = _mapper.Map<TrafficModelRequestDto>(body);
            return await _postData<TrafficModelRequestDto, TrafficModelResponseDto>(Urls.SendDataUrl, requestBody);
        }

        [HttpPost(Name = "SendBill")]
        public async Task<IActionResult> SendBill(BillDataEntranceRequestDto body)
        {
            var requestBody = _mapper.Map<BillDataRequestDto>(body);
            return await _postData<BillDataRequestDto, BillDataResponseDto>(Urls.SendBillUrl, requestBody);
        }

        [HttpPost(Name = "SendPaymentBill")]
        public async Task<IActionResult> SendPaymentBill(PaymentBillEntranceRequestDto body)
        {
            var requestBody = _mapper.Map<PaymentBillRequestDto>(body);
            return await _postData<PaymentBillRequestDto, PaymentBillResponseDto>(Urls.PaymentBilUrl, requestBody);
        }

        [HttpPost(Name = "SendPic")]
        public async Task<IActionResult> SendPic(SendPicEntranceRequestDto body)
        {
            var requestBody = _mapper.Map<SendPicRequestDto>(body);
            return await _postData<SendPicRequestDto, SendPicResponseDto>(Urls.SendPicUrl, requestBody);
        }

        [HttpPost(Name = "SendPenalty")]
        public async Task<IActionResult> SendPenalty(SendPenaltyEntranceRequestDto body)
        {
            var requestBody = _mapper.Map<SendPenaltyRequestDto>(body);
            return await _postData<SendPenaltyRequestDto, SendPenaltyResponseDto>(Urls.SendPenaltyUrl, requestBody);
        }

        [HttpPost(Name = "GetTrackingClass")]
        public async Task<IActionResult> GetTrackingClass(TrackingClassEntranceRequestDto body)
        {
            var requestBody = _mapper.Map<TrackingClassRequestDto>(body);
            return await _postData<TrackingClassRequestDto, TrackingClassResponseDto>(Urls.TrackingClassUrl, requestBody);
        }

        [HttpPost(Name = "CheckBarcodePlate")]
        public async Task<IActionResult> CheckBarcodePlate(CheckBarcodePlateEntranceRequestDto body)
        {
            var requestBody = _mapper.Map<CheckBarcodePlateRequestDto>(body);
            return await _postData<CheckBarcodePlateRequestDto, CheckBarcodePlateResponseDto>(Urls.CheckBarcodePlateUrl, requestBody);
        }

        #region Test HttpClient
        ////---------------
        //[HttpPost(Name = "test_post")]
        //public async Task<IActionResult> test()
        //{
        //    //var bodySerialize = JsonSerializer.Serialize(body);
        //    //var requestContent = new StringContent(bodySerialize, Encoding.UTF8, "application/json");
        //    using System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        //    httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com"); //https://dummy.restapiexample.com
        //    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        //    var response = await httpClient.PostAsync("posts", null);
        //    response.EnsureSuccessStatusCode();
        //    var responseStr = await response.Content.ReadAsStringAsync();
        //    var objDeserializeObject = JsonConvert.DeserializeObject(responseStr);
        //    return Ok(objDeserializeObject);
        //}

        //[HttpGet(Name = "test_get")]
        //public async Task<IActionResult> test_get()
        //{
        //    //await Task.Delay(50000); 
        //    //var bodySerialize = JsonSerializer.Serialize(body);
        //    //var requestContent = new StringContent(bodySerialize, Encoding.UTF8, "application/json");

        //    //using System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
        //    using var httpClient = _httpClientFactory.CreateClient("ETC");


        //    try
        //    {
        //        httpClient.BaseAddress = new Uri("https://eoht3h0oderjptt.m.pipedream.net"); //https://dummy.restapiexample.com   https://jsonplaceholder.typicode.com  
        //        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        //        var response = await httpClient.GetAsync(string.Empty);
        //        response.EnsureSuccessStatusCode();
        //        var responseStr = await response.Content.ReadAsStringAsync();
        //        var objDeserializeObject = JsonConvert.DeserializeObject<List<testGet>>(responseStr);
        //        return Ok(objDeserializeObject);
        //    }
        //    catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
        //    {
        //        //TODO insert log 
        //        return Unauthorized(ex.Message);
        //    }
        //    catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.ServiceUnavailable)
        //    {
        //        return StatusCode((int)HttpStatusCode.ServiceUnavailable,ex.Message);
        //    }
        //}

        //[HttpGet(Name = "test_generic")]
        //public async Task<IActionResult> test_generic()
        //{
        //    var objDeserializeObject = await generic<testGet>();
        //    return Ok(objDeserializeObject);
        //}

        //public async Task<IActionResult> generic<TResponse>() where TResponse : testGet
        //{
        //    var obj = new testGet
        //    {
        //        body = "Hello world !!!",
        //        email = "saman@gmail.com",
        //        id = 1,
        //        name = "Saman",
        //        postId = 12
        //    };

        //    HttpResponseMessage resMessage = new HttpResponseMessage { Content = obj };

        //    var objStr = await resMessage.Content.ReadAsStringAsync();
        //    var objDeserializeObject = JsonConvert.DeserializeObject<TResponse>(objStr);
        //    return Ok(objDeserializeObject);
        //}

        //public class testGet : HttpContent
        //{
        //    public int postId { get; set; }
        //    public int id { get; set; }
        //    public string name { get; set; }
        //    public string email { get; set; }
        //    public string body { get; set; }

        //    protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    protected override bool TryComputeLength(out long length)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
        //////---------------
        #endregion

        private async Task<IActionResult> _postData<TRequest, TResponse>(string urlStr, TRequest body)
            where TRequest : BaseRequestDto
            where TResponse : BaseResponseDto
        {
            try
            {
                var response = await _httpClientHelperAsync.PostAsync<TRequest, TResponse>(urlStr, body);
                if (response is not null)
                    return Ok(response);

                throw new HttpRequestException("Police service - Response has been null!", null, HttpStatusCode.InternalServerError);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                //TODO insert log 
                return NotFound($"Police services : {ex.Message}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                //TODO insert log 
                return Unauthorized($"Police services : {ex.Message}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Forbidden)
            {
                //TODO insert log 
                return Forbid($"Police services : {ex.Message}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                //TODO insert log
                return BadRequest($"Police services : {ex.Message}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadGateway)
            {
                //TODO insert log
                return StatusCode((int)HttpStatusCode.BadGateway,$"Police services : {ex.Message}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                //TODO insert log
                return StatusCode((int)HttpStatusCode.ServiceUnavailable, $"Police services : {ex.Message}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.InternalServerError)
            {
                //TODO insert log
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Police services : {ex.Message}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.RequestTimeout)
            {
                //TODO insert log
                return StatusCode((int)HttpStatusCode.RequestTimeout , $"Police services : {ex.Message}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.GatewayTimeout)
            {
                //TODO insert log
                return StatusCode((int)HttpStatusCode.GatewayTimeout , $"Police services : {ex.Message}");
            }
            catch (Exception otherException)
            {
                //TODO insert log
                return StatusCode(500, $"Police services : {otherException.Message}");
            }
            finally
            {
                //_logger.Log() TODO Inser Log
            }
        }
    }
}