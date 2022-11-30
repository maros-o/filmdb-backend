using DapperWebApi.DataAccess;

namespace DapperWebApi
{
    public static class GlobalConfig
    {
        public static string ConnString { get; set; } = string.Empty;
        public static IDataConnection Connection { get; set; } = new CsvConnector();
    }
}
