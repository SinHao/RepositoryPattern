using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Databases
{
    public interface IMyDatabase
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        Tables.ITable1Service Table1 { get; }
    }
}
