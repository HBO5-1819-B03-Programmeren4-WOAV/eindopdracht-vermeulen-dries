using DV_Prog4_EE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Repositories.Base
{
    public interface IEventRepository
    {
        
        Task<Event> GetById(int id);
        IQueryable<Event> GetAll();
        Task<IEnumerable<Event>> ListAll();
        IQueryable<Event> GetFiltered(Expression<Func<Event, bool>> predicate);
        Task<IEnumerable<Event>> ListFiltered(Expression<Func<Event, bool>> predicate);
        Task<Event> Add(Event entity);
        Task<Event> Delete(Event entity);
        Task<Event> Delete(int id);
        Task<Event> Update(Event entity);
        List<Event> GetAllEvents();
        Event GetBy(int id);
        List<Event> GetByGroupId(int id);
        Task<Event_User> AddLinkToUser(Event_User entity)
    }
}
