using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.ClassRoom
{
    /// <summary>
    /// Class Room
    /// </summary>
    public class ClassRoom: BaseModel
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// A class containing required fields to create new ClassRoom
    /// </summary>
    public class NewClassRoom
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// A class containing editable fields of ClassRoom
    /// </summary>
    public class EditClassRoom
    {
        public string Name { get; set; }
    }

    
}
