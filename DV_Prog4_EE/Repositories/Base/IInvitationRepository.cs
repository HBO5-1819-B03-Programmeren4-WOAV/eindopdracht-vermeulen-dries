using DV_Prog4_EE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Repositories.Base
{
    public interface IInvitationRepository
    {
        List<Invitation> GetByUserId(string email);
        Task<Invitation> GetById(int id);
        IQueryable<Invitation> GetAll();
        Task<IEnumerable<Invitation>> ListAll();
        IQueryable<Invitation> GetFiltered(Expression<Func<Invitation, bool>> predicate);
        Task<IEnumerable<Invitation>> ListFiltered(Expression<Func<Invitation, bool>> predicate);
        Task<Invitation> Add(Invitation entity);
        Task<Invitation> Delete(Invitation entity);
        Task<Invitation> Delete(int id);
        Task<Invitation> Update(Invitation entity);
    }
}
