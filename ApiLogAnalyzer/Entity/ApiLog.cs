namespace ApiLogAnalyzer.Entity;

public class ApiLog
{
    public string? Timestamp { get; set; }
    public EHttpMethod HttpMethod { get; set; }
    public string? Endpoint { get; set; } 
    public HttpStatus HttpStatusCode { get; set; }
    public int ResponseTimeMs { get; set; }
    public string? ClientIp { get; set; }
    public string? UserAgent { get; set; }
    public int RequestSizeByte { get; set; }
    public int ResponseSizeByte { get; set; }
    public string? RequestId { get; set; }

    public Dictionary<string, string>? AdditionalData { get; set; }

}
