using DapperNet.DbContext;
using DapperNet.Models;
using Newtonsoft.Json.Linq;


string configPath = Path.Combine(AppContext.BaseDirectory, "Config", "Config.json");

if (!File.Exists(configPath))
{
    Console.WriteLine("Config file not found: " + configPath);
    return;
}

string jsonContent = File.ReadAllText(configPath);
JObject config = JObject.Parse(jsonContent);
string? ConnectionString = config["Config"]?["ConnectionString"]?.ToString();

if (string.IsNullOrEmpty(ConnectionString))
{
    Console.WriteLine("Connection string is null or empty.");
    return;
}

using var dbContext = new DapperContext(ConnectionString);

int siteId = 1; // Example site ID

SearchSite? searchSite = await GetSearchSite(dbContext, siteId);

static async Task<SearchSite?> GetSearchSite(DapperContext dbContext, int siteId)
{
    try
    {
        string sql = "SELECT TOP(1) * FROM SearchSite WHERE ID = @SiteId";
        var parameters = new { SiteId = siteId };

        SearchSite record = await dbContext.QuerySingleAsync<SearchSite>(sql, parameters);

        if (record != null)
        {
            Console.WriteLine($"SearchSite found: {record.Domain}");
            return record;
        }

        Console.WriteLine("SearchSite not found.");
        return null;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
        return null;
    }
}
