using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetricConverter.Library.Repositories
{
    public interface IGenericRepository : IDisposable 
    {
        IEnumerable<T> All<T>(string cmd);
        T Find<T>(string cmd);
        int Add<T>(T entity, string cmd);
        int Add<T>(IEnumerable<T> entities, string cmd);
        void Remove(string cmd);
        int Update<T>(T entity, string cmd);
    }
}
