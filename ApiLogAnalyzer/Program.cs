
UserSession session = new UserSession();
IApiLogRepository apiRepo = new ApiLogRepository(session);
IAppRunner appRunner = new AppRunner(apiRepo);


try
{
    appRunner.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}





public interface IAppRunner
{
    public void Run();
}

public class AppRunner : IAppRunner
{
    private readonly IApiLogRepository _apiRepo;
    public AppRunner(IApiLogRepository apiRepo)
    {
        _apiRepo = apiRepo;
    }

    public void Run()
    {
        _apiRepo.Load();
    }
}




public enum EHttpMethod
{
    GET,
    POST,
    PUT,
    DELETE,
    UPDATE,
    PATCH
}

public enum HttpStatus
{
    // 1xx Informational
    Continue = 100,
    SwitchingProtocols = 101,
    Processing = 102,
    EarlyHints = 103,

    // 2xx Success
    Success = 200, // Or OK = 200
    Created = 201,
    Accepted = 202,
    NonAuthoritativeInformation = 203,
    NoContent = 204,
    ResetContent = 205,
    PartialContent = 206,

    // 3xx Redirection
    MultipleChoices = 300,
    MovedPermanently = 301,
    Found = 302,
    SeeOther = 303,
    NotModified = 304,
    TemporaryRedirect = 307,
    PermanentRedirect = 308,

    // 4xx Client Errors
    BadRequest = 400,
    Unauthorized = 401,
    PaymentRequired = 402,
    Forbidden = 403,
    NotFound = 404,
    MethodNotAllowed = 405,
    NotAcceptable = 406,
    ProxyAuthenticationRequired = 407,
    RequestTimeout = 408,
    Conflict = 409,
    Gone = 410,
    LengthRequired = 411,
    PreconditionFailed = 412,
    PayloadTooLarge = 413,
    UriTooLong = 414,
    UnsupportedMediaType = 415,
    RangeNotSatisfiable = 416,
    ExpectationFailed = 417,
    ImATeapot = 418, // Classic Easter Egg!
    UnprocessableEntity = 422,
    TooEarly = 425,
    UpgradeRequired = 426,
    PreconditionRequired = 428,
    TooManyRequests = 429,
    RequestHeaderFieldsTooLarge = 431,
    UnavailableForLegalReasons = 451,

    // 5xx Server Errors
    InternalServerError = 500,
    NotImplemented = 501,
    BadGateway = 502,
    ServiceUnavailable = 503,
    GatewayTimeout = 504,
    HttpVersionNotSupported = 505,
    VariantAlsoNegotiates = 506,
    InsufficientStorage = 507,
    LoopDetected = 508,
    NotExtended = 510,
    NetworkAuthenticationRequired = 511
}

public class ApiLog
{
    public string Timestamp { get; set; }
    public EHttpMethod HttpMethod { get; set; }
    public string? Endpoint { get; set; } 
    public HttpStatus HttpStatusCode { get; set; }
    public int ResponseTimeMs { get; set; }
    public string? ClientIp { get; set; }
    public string? UserAgent { get; set; }
    public int RequestSizeByte { get; set; }
    public int ResponseSizeByte { get; set; }
    public string? RequestId { get; set; }

    Dictionary<string, string>? AdditionalData { get; set; }

}

public class ApiLogRepository : IApiLogRepository
{
    private readonly StreamReader _reader;
    private readonly UserSession _session;
    public ApiLogRepository(UserSession session)
    {
        _reader = new StreamReader("api_logs.txt");
        _session = session;
    }

    public void Load()
    {
        while (!_reader.EndOfStream)
        {
            string line = _reader.ReadLine();
            string pattern = @",(?=(?:[^""]*""[^""]*"")*[^""]*$)";
            var row = line.Split(pattern);
            var newapi = new ApiLog
            {
                Timestamp = row[0],
                HttpMethod = Enum.Parse<EHttpMethod>(row[1], true),
                Endpoint = row[2],
                HttpStatusCode = Enum.Parse<HttpStatus>(row[3], true),
                ResponseTimeMs = int.Parse(row[4]),
                ClientIp = row[5],
                UserAgent = row[6],
                RequestSizeByte = int.Parse(row[7]),
                ResponseSizeByte = int.Parse(row[8]),
                RequestId = row[9] 
            };

            _session.ApiLogDataList.Add(newapi);
        }
    }
}

public interface IApiLogRepository
{
    void Load();
}

public class UserSession
{
    public List<ApiLog> ApiLogDataList { get; set; }
}