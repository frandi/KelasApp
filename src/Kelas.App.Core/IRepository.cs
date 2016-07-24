using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core
{
    public interface IRepository<T, NewT, EditT> 
        where T: BaseModel
        where NewT: class
        where EditT: class
    {
        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="id">Id of the item</param>
        /// <returns></returns>
        Task<T> GetById(Guid id);

        /// <summary>
        /// Get items based on criteria. If criteria is not supplied, all items are returned.
        /// </summary>
        /// <param name="criteria">Search criteria</param>
        /// <returns></returns>
        Task<IEnumerable<T>> Get(List<SearchCriteria> criteria);

        /// <summary>
        /// Insert new item
        /// </summary>
        /// <param name="newItem">New item model</param>
        /// <returns></returns>
        Task<T> Insert(NewT newItem);

        /// <summary>
        /// Update existing item
        /// </summary>
        /// <param name="id">Id of the item to update</param>
        /// <param name="editItem">Edit item model</param>
        /// <returns></returns>
        Task<T> Update(Guid id, EditT editItem);

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">Id of the item to update</param>
        /// <returns></returns>
        Task<int> Delete(Guid id);
    }
}
