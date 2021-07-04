using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Services
{
    public interface IConnectionService
    {
        List<T> Query<T>(string sql);
        List<T> Query<T>(string sql, object parameter);
        void Execute(string sql);
        void Execute(string sql, object parameter);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
