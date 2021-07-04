using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1.Tables
{
    public class Table1 : ITable1
    {
        readonly Connections.IConnection Connection;

        public Table1(Connections.IConnection connection)
        {
            this.Connection = connection;
        }

        public Models.Table1 GetTable1(int id)
        {
            var list = this.Connection.Query<Models.Table1>("select id Id,column1 Column1 from table1 where id=@id", new { id = id });
            if (list.Count.Equals(0))
            {
                return null;
            }
            else
            {
                return list.First();
            }
        }

        public void AddTable1(Models.Table1 table1)
        {
            this.Connection.Execute("insert into table1(id,column1)values(@id,@column1)", new { id = table1.Id, column1 = table1.Column1 });
        }
    }
}
