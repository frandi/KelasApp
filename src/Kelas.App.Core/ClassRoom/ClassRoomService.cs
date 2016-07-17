using Kelas.App.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.ClassRoom
{
    public class ClassRoomService: IClassRoomService
    {
        private IClassRoomRepository _classRoomRepo;

        #region Constructors
        public ClassRoomService(IClassRoomRepository classRoomRepo)
        {
            _classRoomRepo = classRoomRepo;
        } 
        #endregion

        /// <summary>
        /// Get a class room by its id
        /// </summary>
        /// <param name="classRoomId">Id of the class room</param>
        /// <returns></returns>
        public async Task<ClassRoom> GetClassRoom(Guid classRoomId)
        {
            if (classRoomId.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(classRoomId));

            return await _classRoomRepo.GetById(classRoomId);
        }

        /// <summary>
        /// Get all class rooms
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ClassRoom>> GetClassRooms()
        {
            return await _classRoomRepo.Get(null);
        }

        /// <summary>
        /// Get class rooms based on certain criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ClassRoom>> GetClassRooms(List<SearchCriteria> criteria)
        {
            return await _classRoomRepo.Get(criteria);
        }

        /// <summary>
        /// Create a new class room
        /// </summary>
        /// <param name="newClassRoom">New class room details</param>
        /// <returns></returns>
        public async Task<ClassRoom> CreateClassRoom(NewClassRoom newClassRoom)
        {
            if (newClassRoom == null)
                throw new ArgumentNullException(nameof(newClassRoom));

            return await _classRoomRepo.Insert(newClassRoom);
        }

        /// <summary>
        /// Update a class room
        /// </summary>
        /// <param name="classRoomId">Id of the class room</param>
        /// <param name="editClassRoom">Updated details of the class room</param>
        /// <returns></returns>
        public async Task<ClassRoom> UpdateClassRoom(Guid classRoomId, EditClassRoom editClassRoom)
        {
            if (classRoomId.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(classRoomId));

            if (editClassRoom == null)
                throw new ArgumentNullException(nameof(editClassRoom));

            return await _classRoomRepo.Update(classRoomId, editClassRoom);
        }

        /// <summary>
        /// Delete a class room
        /// </summary>
        /// <param name="classRoomId">Id of the class room</param>
        /// <returns></returns>
        public async Task<int> DeleteClassRoom(Guid classRoomId)
        {
            if (classRoomId.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(classRoomId));

            return await _classRoomRepo.Delete(classRoomId);
        }
    }
}
