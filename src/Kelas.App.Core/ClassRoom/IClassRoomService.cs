using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.ClassRoom
{
    public interface IClassRoomService
    {
        ClassRoom GetClassRoom(Guid classRoomId);
        IEnumerable<ClassRoom> GetClassRoom(List<SearchCriteria> criteria);
        ClassRoom CreateClassRoom(NewClassRoom newClassRoom);
        ClassRoom UpdateClassRoom(Guid classRoomId, EditClassRoom editClassRoom);
        int DeleteClassRoom(Guid classRoomId);
    }
}
