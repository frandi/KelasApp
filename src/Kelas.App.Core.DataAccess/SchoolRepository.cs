using Kelas.App.Core.School;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.DataAccess
{
    public class SchoolRepository : ISchoolRepository
    {
        private KelasAppDbContext _db;

        public SchoolRepository(KelasAppDbContext db)
        {
            _db = db;
        }

        public async Task<int> Delete(Guid id)
        {
            int count = 0;

            var item = await _db.Schools.FirstOrDefaultAsync(s => s.Id == id);
            if (item != null)
            {
                _db.Schools.Remove(item);
                count = await _db.SaveChangesAsync();
            }

            return count;
        }

        public async Task<IEnumerable<School.School>> Get(List<SearchCriteria> searchCriteria)
        {
            var query = _db.Schools.AsQueryable();

            if (searchCriteria != null)
            {
                var cr = new School.School();
                foreach (SearchCriteria criteria in searchCriteria)
                {
                    switch (criteria.SearchField)
                    {
                        case nameof(cr.Name):
                            if (criteria.SearchOperator == SearchOperator.Equals)
                                query = query.Where(s => s.Name == criteria.SearchValue);
                            else if (criteria.SearchOperator == SearchOperator.StartsWith)
                                query = query.Where(s => s.Name.StartsWith(criteria.SearchValue));
                            else if (criteria.SearchOperator == SearchOperator.Contains)
                                query = query.Where(s => s.Name.Contains(criteria.SearchValue));
                            break;
                        case nameof(cr.Owner):
                            if (criteria.SearchOperator == SearchOperator.Equals)
                                query = query.Where(s => s.Owner == criteria.SearchValue);
                            else if (criteria.SearchOperator == SearchOperator.StartsWith)
                                query = query.Where(s => s.Owner.StartsWith(criteria.SearchValue));
                            else if (criteria.SearchOperator == SearchOperator.Contains)
                                query = query.Where(s => s.Owner.Contains(criteria.SearchValue));
                            break;
                    }
                }
            }

            return await query.ToListAsync();
        }

        public async Task<School.School> GetById(Guid id)
        {
            return await _db.Schools.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<School.School> Insert(School.NewSchool newItem)
        {
            var item = newItem.ToSchool();
            item.Created = DateTime.UtcNow;

            _db.Schools.Add(item);
            await _db.SaveChangesAsync();

            return item;
        }

        public async Task<School.School> Update(Guid id, School.EditSchool editItem)
        {
            var item = await _db.Schools.FirstOrDefaultAsync(c => c.Id == id);
            if (item != null)
            {
                editItem.UpdateSchoolFields(item);
                item.Updated = DateTime.UtcNow;

                _db.Schools.Update(item);
                await _db.SaveChangesAsync();
            }

            return item;
        }
    }
}
