using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.ClassRoom
{
    public interface IClassRoomService
    {
        Task<ClassRoom> GetClassRoom(Guid classRoomId);
        Task<IEnumerable<ClassRoom>> GetClassRoom(List<SearchCriteria> criteria);
        Task<ClassRoom> CreateClassRoom(NewClassRoom newClassRoom);
        Task<ClassRoom> UpdateClassRoom(Guid classRoomId, EditClassRoom editClassRoom);
        Task<int> DeleteClassRoom(Guid classRoomId);
    }
}
