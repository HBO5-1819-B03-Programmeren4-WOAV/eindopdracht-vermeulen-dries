using DV_Prog4_EE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Repositories.Base
{
    public interface IGroupRepository
    {
        Group GetBy(string name);
        Task<Group> GetById(int id);
        IQueryable<Group> GetAll();
        Task<IEnumerable<Group>> ListAll();
        IQueryable<Group> GetFiltered(Expression<Func<Group, bool>> predicate);
        Task<IEnumerable<Group>> ListFiltered(Expression<Func<Group, bool>> predicate);
        Task<Group> Add(Group entity);
        Task<Group> Delete(Group entity);
        Task<Group> Delete(int id);
        Task<Group> Update(Group entity);

    }
}
