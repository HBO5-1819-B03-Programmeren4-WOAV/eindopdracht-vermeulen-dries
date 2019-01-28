using DV_Prog4_EE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Repositories.Base
{
    public interface IUserRepository
    {
        AppUser GetBy(string email);
        Task<AppUser> GetById(int id);
        IQueryable<AppUser> GetAll();
        Task<IEnumerable<AppUser>> ListAll();
        IQueryable<AppUser> GetFiltered(Expression<Func<AppUser, bool>> predicate);
        Task<IEnumerable<AppUser>> ListFiltered(Expression<Func<AppUser, bool>> predicate);
        Task<AppUser> Add(AppUser entity);
        Task<AppUser> Delete(AppUser entity);
        Task<AppUser> Delete(int id);
        Task<AppUser> Update(AppUser entity);
        List<AppUser> GetUsersForEvent(int id);
    }
}
