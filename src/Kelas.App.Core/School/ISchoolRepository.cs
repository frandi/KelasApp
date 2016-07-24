using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.School
{
    public interface ISchoolRepository: IRepository<School, NewSchool, EditSchool>
    {
    }
}
