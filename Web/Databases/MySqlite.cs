using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Databases
{
    public class MyDatabase : IMyDatabase
    {
        readonly Services.IConnectionService ConnectionService;

        private Tables.ITable1Service _table1;

        Tables.ITable1Service IMyDatabase.Table1 => this._table1 ?? new Tables.Table1Service(this.ConnectionService);

        public MyDatabase(Services.IConnectionService databaseService)
        {
            this.ConnectionService = databaseService;
        }

        public void BeginTransaction()
        {
            this.ConnectionService.BeginTransaction();
        }

        public void Commit()
        {
            this.ConnectionService.Commit();
        }

        public void Rollback()
        {
            this.ConnectionService.Rollback();
        }
    }
}
