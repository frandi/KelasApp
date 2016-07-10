using Kelas.App.Core.ClassRoom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.DataAccess
{
    public class ClassRoomRepository : IClassRoomRepository
    {
        private KelasAppDbContext _db;

        public ClassRoomRepository(KelasAppDbContext db)
        {
            _db = db;
        }

        public async Task<int> Delete(Guid id)
        {
            int count = 0;

            var item = await _db.ClassRooms.FirstOrDefaultAsync(c => c.Id == id);
            if (item != null)
            {
                _db.ClassRooms.Remove(item);
                count = await _db.SaveChangesAsync();
            }

            return count;
        }

        public async Task<IEnumerable<ClassRoom.ClassRoom>> Get(List<SearchCriteria> searchCriteria)
        {
            var query = _db.ClassRooms.AsQueryable();

            if(searchCriteria != null)
            {
                var cr = new ClassRoom.ClassRoom();
                foreach (SearchCriteria criteria in searchCriteria)
                {
                    switch (criteria.SearchField)
                    {
                        case nameof(cr.Name):
                            if (criteria.SearchOperator == SearchOperator.Equals)
                                query = query.Where(c => c.Name == criteria.SearchValue);
                            else if (criteria.SearchOperator == SearchOperator.StartsWith)
                                query = query.Where(c => c.Name.StartsWith(criteria.SearchValue));
                            else if (criteria.SearchOperator == SearchOperator.Contains)
                                query = query.Where(c => c.Name.Contains(criteria.SearchValue));
                            break;
                    }
                }
            }

            return await query.ToListAsync();
        }

        public async Task<ClassRoom.ClassRoom> GetById(Guid id)
        {
            return await _db.ClassRooms.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ClassRoom.ClassRoom> Insert(NewClassRoom newItem)
        {
            var item = new ClassRoom.ClassRoom() { Name = newItem.Name };
            _db.ClassRooms.Add(item);
            await _db.SaveChangesAsync();

            return item;
        }

        public async Task<ClassRoom.ClassRoom> Update(Guid id, EditClassRoom editItem)
        {
            var item = await _db.ClassRooms.FirstOrDefaultAsync(c => c.Id == id);
            if(item != null)
            {
                item.Name = editItem.Name;

                _db.ClassRooms.Update(item);
                await _db.SaveChangesAsync();
            }

            return item;
        }
    }
}
