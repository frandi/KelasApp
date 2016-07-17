using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.ClassRoom
{
    public interface IClassRoomService
    {
        /// <summary>
        /// Get a class room by its id
        /// </summary>
        /// <param name="classRoomId">Id of the class room</param>
        /// <returns></returns>
        Task<ClassRoom> GetClassRoom(Guid classRoomId);

        /// <summary>
        /// Get all class rooms
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ClassRoom>> GetClassRooms();

        /// <summary>
        /// Get class rooms based on certain criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        Task<IEnumerable<ClassRoom>> GetClassRooms(List<SearchCriteria> criteria);

        /// <summary>
        /// Create a new class room
        /// </summary>
        /// <param name="newClassRoom">New class room details</param>
        /// <returns></returns>
        Task<ClassRoom> CreateClassRoom(NewClassRoom newClassRoom);

        /// <summary>
        /// Update a class room
        /// </summary>
        /// <param name="classRoomId">Id of the class room</param>
        /// <param name="editClassRoom">Updated details of the class room</param>
        /// <returns></returns>
        Task<ClassRoom> UpdateClassRoom(Guid classRoomId, EditClassRoom editClassRoom);

        /// <summary>
        /// Delete a class room
        /// </summary>
        /// <param name="classRoomId">Id of the class room</param>
        /// <returns></returns>
        Task<int> DeleteClassRoom(Guid classRoomId);
    }
}
