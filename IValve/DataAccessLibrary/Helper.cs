using System.Configuration;


namespace DataAccessLibrary
{
    public static class Helper
    {
        public static string Connection(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
