using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Repository;

namespace tekno_egitim_web.core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IBlog Blogs { get;  }
        IHaber Habers { get; }
        IMakale Makales { get; }
        INot Nots { get; }
        IVideo Videos { get; }
        IKategoriler Kategoris { get;  }
        IUniversite Universiteler { get;  }
        Task CommitAsycn();
        void Commit();
    }
}
