using Kelas.App.Core.ClassRoom;
using Microsoft.EntityFrameworkCore.Query;
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

        public int Delete(Guid id)
        {
            int count = 0;

            var item = _db.ClassRooms.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _db.ClassRooms.Remove(item);
                count = _db.SaveChanges();
            }

            return count;
        }

        public IEnumerable<ClassRoom.ClassRoom> Get(List<SearchCriteria> criteria)
        {
            throw new NotImplementedException();
        }

        public ClassRoom.ClassRoom GetById(Guid id)
        {
            return _db.ClassRooms.FirstOrDefault(c => c.Id == id);
        }

        public ClassRoom.ClassRoom Insert(NewClassRoom newItem)
        {
            var item = new ClassRoom.ClassRoom() { Name = newItem.Name };
            _db.ClassRooms.Add(item);
            _db.SaveChanges();

            return item;
        }

        public ClassRoom.ClassRoom Update(Guid id, EditClassRoom editItem)
        {
            throw new NotImplementedException();
        }
    }
}
