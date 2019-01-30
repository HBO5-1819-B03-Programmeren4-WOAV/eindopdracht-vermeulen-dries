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
    public class GroupRepository: IGroupRepository
    {
        protected readonly ApplicationDbContext db;

        private readonly DbSet<Group> _group;

        public GroupRepository(ApplicationDbContext context)
        {
            db = context;
            _group = context.Groups;
        }


        public Group GetById(int id)
        {
            return _group.Include(u => u.Members)
                .FirstOrDefault(c => c.Id == id);
        }

        public Group GetBy(string name)
        {
            return _group.Include(u => u.Members).
                SingleOrDefault(c => c.Name == name);
        }

        // get an IQueryAble: to manipulate with deferred execution
        public virtual IQueryable<Group> GetAll()
        {
            // Entities won't be manipulated directly on this set --> faster with AsNoTracking()
            return db.Set<Group>().AsNoTracking();
        }


        public async Task<IEnumerable<Group>> ListAll()
        {
            return await GetAll().ToListAsync();
        }


        public virtual IQueryable<Group> GetFiltered(Expression<Func<Group, bool>> predicate)
        {
            return db.Set<Group>()
                   .Where(predicate).AsNoTracking();
        }

        public async virtual Task<IEnumerable<Group>> ListFiltered(Expression<Func<Group, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<Group> Add(Group entity)
        {
            db.Set<Group>().Add(entity);
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

        public async Task<Group> Update(Group entity)
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

        public void Save(Group entity)
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

        public async Task<Group> Delete(Group entity)
        {
            db.Set<Group>().Remove(entity);
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

        public async Task<Group> Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return null;
            return await Delete(entity);
        }

        private async Task<bool> Exists(int id)
        {
            return await db.Set<Group>().AnyAsync(e => e.Id == id);
        }

    }
}
