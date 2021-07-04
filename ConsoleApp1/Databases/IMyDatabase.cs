using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Databases
{
    public interface IMyDatabase
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        Tables.ITable1 Table1 { get; }
    }
}
