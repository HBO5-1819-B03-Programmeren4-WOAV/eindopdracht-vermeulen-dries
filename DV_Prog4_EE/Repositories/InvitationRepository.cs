using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DV_Prog4_EE.Data;
using DV_Prog4_EE.Domain;
using DV_Prog4_EE.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DV_Prog4_EE.Repositories
{
    public class InvitationRepository:IInvitationRepository
    {
        protected readonly ApplicationDbContext db;

        private readonly DbSet<Invitation> _Invitation;

        public InvitationRepository(ApplicationDbContext context)
        {
            db = context;
            _Invitation = context.Invitations;
        }

        public List<Invitation> GetByUserId(string email)
        {
            return _Invitation.Where(c => c.ReceiverEmail == email).ToList();
        }

        public virtual async Task<Invitation> GetById(int id)
        {
            return await db.Set<Invitation>().FindAsync(id);
        }
        

        // get an IQueryAble: to manipulate with deferred execution
        public virtual IQueryable<Invitation> GetAll()
        {
            // Entities won't be manipulated directly on this set --> faster with AsNoTracking()
            return db.Set<Invitation>().AsNoTracking();
        }


        public async Task<IEnumerable<Invitation>> ListAll()
        {
            return await GetAll().ToListAsync();
        }


        public virtual IQueryable<Invitation> GetFiltered(Expression<Func<Invitation, bool>> predicate)
        {
            return db.Set<Invitation>()
                   .Where(predicate).AsNoTracking();
        }

        public async virtual Task<IEnumerable<Invitation>> ListFiltered(Expression<Func<Invitation, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<Invitation> Add(Invitation entity)
        {
            db.Set<Invitation>().Add(entity);
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

        public async Task<Invitation> Update(Invitation entity)
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

        public void Save(Invitation entity)
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

        public async Task<Invitation> Delete(Invitation entity)
        {
            db.Set<Invitation>().Remove(entity);
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

        public async Task<Invitation> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            return await Delete(entity);
        }

        private async Task<bool> Exists(int id)
        {
            return await db.Set<Invitation>().AnyAsync(e => e.Id == id);
        }
    }
}
