using System.Collections.Generic;

namespace AimyInvoiceDemo.Repository
{
    // public interface IRepository<M ,D, S, L>
    public interface IRepository<M, D, S>
    {
        // int Create(S model);
        void Create(S model);
        //void CreateLines(List<L> model);
        D GetDetail(int id);
        List<M> GetList(string searchtype, string searchname);
        string Delete(int id);
    }
}
