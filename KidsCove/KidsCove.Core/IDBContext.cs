using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KidsCove.Core
{
    public interface IDBContext : IDisposable
    {
        void BeginTransaction();

        void Commit();

        void Rollback();

        IDBContext Start();
    }
}
