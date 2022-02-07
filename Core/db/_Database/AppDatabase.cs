using Core.Component.Library.SQL;

namespace Nx.Repository
{
    public class AppDatabase : IDatabase
    {
        public AppDatabase(string cnn)
        {
            this.ConnectionString = cnn;
        }
    }
}