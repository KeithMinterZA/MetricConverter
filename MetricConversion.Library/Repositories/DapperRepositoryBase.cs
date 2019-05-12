using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MetricConverter.Library.Repositories
{
    public abstract class DapperRepositoryBase : IGenericRepository
    {
        private string ConnectionString { get; set; }
        public DapperRepositoryBase(string connString)
        {
            ConnectionString = connString;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

        public int Add<T>(T entity, string cmd)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Execute(cmd, entity);
            }
        }

        public int Add<T>(IEnumerable<T> entities, string cmd)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Execute(cmd, entities);
            }
        }

        public IEnumerable<T> All<T>(string cmd)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<T>(cmd);
            }
        }

        public T Find<T>(string cmd)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.QueryFirst<T>(cmd);
            }
        }

        public void Remove(string cmd)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute(cmd);
            }
        }

        public int Update<T>(T entity, string cmd)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Execute(cmd);
            }
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
