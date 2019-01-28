using DV_Prog4_EE.Data;
using DV_Prog4_EE.Domain;
using DV_Prog4_EE.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DV_Prog4_EE.Repositories
{
    public class EventRepository: IEventRepository
    {
        protected readonly ApplicationDbContext db;

        private readonly DbSet<Event> _events;
        private readonly DbSet<Event_User> _eventUsers;

        public EventRepository(ApplicationDbContext context)
        {
            db = context;
            _events = context.Events;
            _eventUsers = context.event_Users;
        }


        public virtual async Task<Event> GetById(int id)
        {
            return await db.Set<Event>().FindAsync(id);
        }

        public Event GetBy(int id)
        {
            return _events.FirstOrDefault(c => c.Id == id);
        }

        public List<Event> GetByGroupId(int id)
        {
            return _events.Where(c => c.Owner.Id == id).ToList();
        }

        // get an IQueryAble: to manipulate with deferred execution
        public virtual IQueryable<Event> GetAll()
        {
            // Entities won't be manipulated directly on this set --> faster with AsNoTracking()
            return db.Set<Event>().AsNoTracking();
        }


        public async Task<IEnumerable<Event>> ListAll()
        {
            return await GetAll().ToListAsync();
        }


        public virtual IQueryable<Event> GetFiltered(Expression<Func<Event, bool>> predicate)
        {
            return db.Set<Event>()
                   .Where(predicate).AsNoTracking();
        }

        public async virtual Task<IEnumerable<Event>> ListFiltered(Expression<Func<Event, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<Event> Add(Event entity)
        {
            db.Set<Event>().Add(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<Event> Update(Event entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public void Save(Event entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            try
            {
                db.SaveChangesAsync();
            }
            catch
            {

            }

        }

        public async Task<Event> Delete(Event entity)
        {
            db.Set<Event>().Remove(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<Event> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            return await Delete(entity);
        }

        private async Task<bool> Exists(int id)
        {
            return await db.Set<Event>().AnyAsync(e => e.Id == id);
        }

        public List<Event> GetAllEvents()
        {
            List<Event> events = _events.ToList();
            
            return events;
        }

        public async Task<Event_User> AddLinkToUser(Event_User entity)
        {
            db.Set<Event_User>().Add(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }
    }
}

