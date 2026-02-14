using Microsoft.Data.SqlClient;
using System.Configuration;

public static class DbHelper
{
    private static string connectrionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectrionString);
    }
}
