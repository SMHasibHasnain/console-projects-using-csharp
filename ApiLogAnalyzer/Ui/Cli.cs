using System.ComponentModel.DataAnnotations.Schema;
using ApiLogAnalyzer.Shared;
using Spectre.Console;

namespace ApiLogAnalyzer.Ui;

class Cli
{
    private UserSession _session;
    public Cli(UserSession session)
    {
        _session = session;
    }

    public void MakeApiDataList()
    {
        var table = new Table();

        int limit = 15;
        
        foreach(var column in _session.ApiLogColumns)
        {
            if(limit-- <= 0) break;
            table.AddColumn(column);
        }

        limit = 5;

        foreach(var apiLog in _session.ApiLogDataList)
        {
            var row = new List<string>
            {
                apiLog.Timestamp,
                apiLog.HttpMethod.ToString(),
                apiLog.Endpoint,
                apiLog.HttpStatusCode.ToString(),
                apiLog.ResponseTimeMs.ToString(),
                apiLog.ClientIp,
                apiLog.UserAgent,
                apiLog.RequestSizeByte.ToString(),
                apiLog.ResponseSizeByte.ToString(),
                apiLog.RequestId
            };

            foreach(var column in _session.ApiLogColumns.Skip(10))
            {
                if(limit-- <= 0) break;

                if(apiLog.AdditionalData.ContainsKey(column))
                {
                    row.Add(apiLog.AdditionalData[column]);
                }
                else
                {
                    row.Add("");
                }
            }

            table.AddRow(row.ToArray());
        }

        AnsiConsole.Write(table);

    }
}