using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core
{
    public interface IRepository<T, NewT, EditT> where T: BaseModel
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> Get(List<SearchCriteria> criteria);
        Task<T> Insert(NewT newItem);
        Task<T> Update(Guid id, EditT editItem);
        Task<int> Delete(Guid id);
    }
}
