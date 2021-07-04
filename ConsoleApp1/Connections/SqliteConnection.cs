using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;

namespace ConsoleApp1.Connections
{
    public class SqliteConnectionService : IConnection
    {
        readonly System.Data.SQLite.SQLiteConnection Connection;
        System.Data.SQLite.SQLiteTransaction _transaction;

        public SqliteConnectionService(System.Data.SQLite.SQLiteConnection connection)
        {
            this.Connection = connection;
        }

        public void Execute(string sql)
        {
            this.Execute(sql, null);
        }

        public void Execute(string sql, object parameter)
        {
            this.ConnectionOpen();
            this.Connection.Execute(sql, parameter);
            this.ConnectionClose();
        }

        public List<T> Query<T>(string sql)
        {
            return this.Query<T>(sql, null);
        }

        public List<T> Query<T>(string sql, object parameter)
        {
            this.ConnectionOpen();
            List<T> list = new List<T>();
            list = this.Connection.Query<T>(sql, parameter).ToList();
            this.ConnectionClose();
            return list;
        }

        private void ConnectionOpen()
        {
            if (this.Connection.State != System.Data.ConnectionState.Open)
            {
                this.Connection.Open();
            }
        }

        private void ConnectionClose()
        {
            if (null == this._transaction)
            {
                this.Connection.Close();
            }
        }

        public void BeginTransaction()
        {
            if (null == this._transaction)
            {
                this.Connection.Open();
                this._transaction = this.Connection.BeginTransaction();
            }
        }

        public void Commit()
        {
            if (null != this._transaction)
            {
                this._transaction.Commit();
                this._transaction = null;
                this.Connection.Close();
            }
        }

        public void Rollback()
        {
            if (null != this._transaction)
            {
                this._transaction.Rollback();
                this._transaction = null;
                this.Connection.Close();
            }
        }
    }
}
