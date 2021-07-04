using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Tables
{
    public class Table1Service : ITable1Service
    {
        readonly Services.IConnectionService ConnectionService;

        public Table1Service(Services.IConnectionService connectionService)
        {
            this.ConnectionService = connectionService;
        }

        public Models.Table1 GetTable1(int id)
        {
            var list = this.ConnectionService.Query<Models.Table1>("select id Id,column1 Column1 from table1 where id=@id", new { id = id });
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
            this.ConnectionService.Execute("insert into table1(id,column1)values(@id,@column1)", new { id = table1.Id, column1 = table1.Column1 });
        }
    }
}
