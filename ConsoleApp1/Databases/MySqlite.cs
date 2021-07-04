using ConsoleApp1.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Databases
{
    public class MySqlite : IMyDatabase
    {
        readonly Connections.IConnection Connection;

        private Tables.ITable1 _table1;

        Tables.ITable1 IMyDatabase.Table1 => this._table1 ?? new Tables.Table1(this.Connection);

        public MySqlite(Connections.IConnection connection)
        {
            this.Connection = connection;
        }

        public void BeginTransaction()
        {
            this.Connection.BeginTransaction();
        }

        public void Commit()
        {
            this.Connection.Commit();
        }

        public void Rollback()
        {
            this.Connection.Rollback();
        }
    }
}
