using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Connections
{
    public interface IConnection
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