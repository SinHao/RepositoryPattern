using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tables
{
    public interface ITable1
    {
        Models.Table1 GetTable1(int id);

        void AddTable1(Models.Table1 table1);
    }
}
