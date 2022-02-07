using System;
using System.Data.SqlClient;

namespace Common.Infrastructure
{
    public class Settings
    {
        public Jwt Jwt { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public Storage Storage { get; set; }
        public Configuration Configuration { get; set; }
    }

    public class ConnectionStrings
    {
        public string ConnectionString { get; set; }
        protected SqlConnection db => new(ConnectionString);
    }

    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int Expires { get; set; }
    }

    public class Storage
    {
        public string ConnectionString { get; set; }
        public string ContaninerName { get; set; }
    }

    public class Configuration
    {
        public string Token { get; set; }
    }
}
