using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Billeterie.Repositories
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();
        TEntity GetOne(int id);
        void Delete(int id);
        void Update(TEntity t);
    }
}
