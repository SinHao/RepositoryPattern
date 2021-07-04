using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Tables
{
    public interface ITable1Service
    {
        Models.Table1 GetTable1(int id);

        void AddTable1(Models.Table1 table1);
    }
}
