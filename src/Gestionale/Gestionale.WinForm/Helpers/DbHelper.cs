using Microsoft.Data.SqlClient;
using System.Configuration;

public static class DbHelper
{
    public static SqlConnection GetConnection()
    {
        string connectrionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        return new SqlConnection(connectrionString);
    }
}
