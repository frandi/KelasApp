using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.ClassRoom
{
    /// <summary>
    /// Class Room
    /// </summary>
    public class ClassRoom: BaseModel
    {
        [Required]
        public string Name { get; set; }

        public Guid SchoolId { get; set; }
        public School.School School { get; set; }
    }

    /// <summary>
    /// A class containing required fields to create new ClassRoom 
    /// </summary>
    public class NewClassRoom
    {
        [Required]
        public string Name { get; set; }
        public Guid SchoolId { get; set; }

        public ClassRoom ToClassRoom()
        {
            return new ClassRoom()
            {
                Name = Name,
                SchoolId = SchoolId
            };
        }
    }

    /// <summary>
    /// A class containing editable fields of ClassRoom
    /// </summary>
    public class EditClassRoom
    {
        [Required]
        public string Name { get; set; }
        public Guid SchoolId { get; set; }

        public void UpdateClassRoomFields(ClassRoom originalClassRoom)
        {
            originalClassRoom.Name = Name;
            originalClassRoom.SchoolId = SchoolId;
        }
    }

    
}
