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
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext db;

        private readonly DbSet<AppUser> _users;

        private readonly DbSet<Event_User> _eventUsers;

        public UserRepository(ApplicationDbContext context)
        {
            db = context;
            _users = context.AppUsers;
            _eventUsers = context.event_Users;
        }


        public virtual async Task<AppUser> GetById(int id)
        {
            return await db.Set<AppUser>().FindAsync(id);
        }

        public AppUser GetBy(string email)
        {
            return _users.SingleOrDefault(c => c.Email == email);
        }

        // get an IQueryAble: to manipulate with deferred execution
        public virtual IQueryable<AppUser> GetAll()
        {
            // Entities won't be manipulated directly on this set --> faster with AsNoTracking()
            return db.Set<AppUser>().AsNoTracking();
        }


        public async Task<IEnumerable<AppUser>> ListAll()
        {
            return await GetAll().ToListAsync();
        }


        public virtual IQueryable<AppUser> GetFiltered(Expression<Func<AppUser, bool>> predicate)
        {
            return db.Set<AppUser>()
                   .Where(predicate).AsNoTracking();
        }

        public async virtual Task<IEnumerable<AppUser>> ListFiltered(Expression<Func<AppUser, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<AppUser> Add(AppUser entity)
        {
            db.Set<AppUser>().Add(entity);
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

        public async Task<AppUser> Update(AppUser entity)
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

        public void Save(AppUser entity)
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

        public async Task<AppUser> Delete(AppUser entity)
        {
            db.Set<AppUser>().Remove(entity);
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

        public async Task<AppUser> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            return await Delete(entity);
        }

        private async Task<bool> Exists(int id)
        {
            return await db.Set<AppUser>().AnyAsync(e => e.Id == id);
        }

        public List<AppUser> GetUsersForEvent(int id)
        {
            List<AppUser> u = new List<AppUser>();
            foreach(Event_User e in _eventUsers)
            {
                if (e.EventKey == id)
                {
                    u.Add(_users.FirstOrDefault(a => a.Email == e.Email));
                }
            }

            return u;
        }

        
    }
}
