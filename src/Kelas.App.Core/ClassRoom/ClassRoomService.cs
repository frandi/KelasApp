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

        public async Task<ClassRoom> GetClassRoom(Guid classRoomId)
        {
            return await _classRoomRepo.GetById(classRoomId);
        }

        public async Task<IEnumerable<ClassRoom>> GetClassRoom(List<SearchCriteria> criteria)
        {
            return await _classRoomRepo.Get(criteria);
        }

        public async Task<ClassRoom> CreateClassRoom(NewClassRoom newClassRoom)
        {
            return await _classRoomRepo.Insert(newClassRoom);
        }

        public async Task<ClassRoom> UpdateClassRoom(Guid classRoomId, EditClassRoom editClassRoom)
        {
            return await _classRoomRepo.Update(classRoomId, editClassRoom);
        }

        public async Task<int> DeleteClassRoom(Guid classRoomId)
        {
            return await _classRoomRepo.Delete(classRoomId);
        }
    }
}
