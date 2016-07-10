using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core
{
    public interface IRepository<T, NewT, EditT> where T: BaseModel
    {
        T GetById(Guid id);
        IEnumerable<T> Get(List<SearchCriteria> criteria);
        T Insert(NewT newItem);
        T Update(Guid id, EditT editItem);
        int Delete(Guid id);
    }
}
