
using System.Text.Json;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24;

public class RestfulTradeDataProvider : ITradeDataProvider
{
    private readonly string url;
    private readonly ILogger logger;

    public RestfulTradeDataProvider(string url, ILogger logger)
    {
        this.url = url;
        this.logger = logger;
    }

    public IEnumerable<string> ReadTradeData()
    {
        logger.LogMessage("Reading trade data from Restful API: {0}", url);

        using HttpClient client = new HttpClient();
        string json = client.GetStringAsync(url)
            .GetAwaiter().GetResult();

        return JsonSerializer.Deserialize<List<string>>(json)
            ?? new List<string>();
    }
}
