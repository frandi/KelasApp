using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.ClassRoom
{
    public class ClassRoomService: IClassRoomService
    {
        private IClassRoomRepository _classRoomRepo;
        
        public ClassRoomService(IClassRoomRepository classRoomRepo)
        {
            _classRoomRepo = classRoomRepo;
        }

        public ClassRoom GetClassRoom(Guid classRoomId)
        {
            return _classRoomRepo.GetById(classRoomId);
        }

        public IEnumerable<ClassRoom> GetClassRoom(List<SearchCriteria> criteria)
        {
            return _classRoomRepo.Get(criteria);
        }

        public ClassRoom CreateClassRoom(NewClassRoom newClassRoom)
        {
            return _classRoomRepo.Insert(newClassRoom);
        }

        public ClassRoom UpdateClassRoom(Guid classRoomId, EditClassRoom editClassRoom)
        {
            return _classRoomRepo.Update(classRoomId, editClassRoom);
        }

        public int DeleteClassRoom(Guid classRoomId)
        {
            return _classRoomRepo.Delete(classRoomId);
        }
    }
}
