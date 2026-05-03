using System.Text.RegularExpressions;
using ApiLogAnalyzer.Entity;
using ApiLogAnalyzer.Shared;

namespace ApiLogAnalyzer.Repo;

public class ApiLogRepository : IApiLogRepository
{
    private readonly UserSession _session;
    private string _filePath = Path.Combine("_data", "api_logs_sample.csv");
    public ApiLogRepository(UserSession session)
    {
        _session = session;
    }

    public void Load()
    {

        if(!File.Exists(_filePath))
        {
            Console.WriteLine($"File not found: {_filePath}");
            return;
        }

        using(var _reader = new StreamReader(_filePath))
        {
            string header = _reader.ReadLine()!;
            var headerColumns = header.Split(',').Select(h => h.Trim()).ToList();

            while (!_reader.EndOfStream)
            {
                string line = _reader.ReadLine()!;
                string pattern = @",(?=(?:[^""]*""[^""]*"")*[^""]*$)";
                var row = Regex.Split(line, pattern);
                
                for(int i=0; i < row.Length; i++)
                {
                    row[i] = row[i].Trim();
                }
                
                var newApi = new ApiLog
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
                    RequestId = row[9],
                };

                newApi.AdditionalData = new Dictionary<string, string>();
                for(int j=10; j < row.Length; j++)
                {
                    var key = headerColumns[j];
                    var value = row[j];
                    newApi.AdditionalData[key] = value;
                }   

                _session.ApiLogDataList.Add(newApi);
                _session.ApiLogColumns = headerColumns;
            }
        }


    }
}
