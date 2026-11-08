
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24;

public class URLTradeDataProvider : ITradeDataProvider
{
    private readonly string url;
    private readonly ILogger logger;

    public URLTradeDataProvider(string url, ILogger logger)
    {
        this.url = url;
        this.logger = logger;
    }

    public IEnumerable<string> ReadTradeData()
    {
        logger.LogMessage("Reading trade data from URL: {0}", url);

        using HttpClient client = new HttpClient();
        string content = client.GetStringAsync(url)
            .GetAwaiter().GetResult();

        return content.Split(
            new[] { "\r\n", "\n" },
            StringSplitOptions.RemoveEmptyEntries);
    }
}
