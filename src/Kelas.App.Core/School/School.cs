using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.School
{
    public class School: BaseModel
    {
        [Required]
        [RegularExpression("/[a-z0-9-]/g")]
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Owner { get; set; }

        public IEnumerable<ClassRoom.ClassRoom> ClassRooms { get; set; }
    }

    public class NewSchool
    {
        [Required]
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Owner { get; set; }

        public School ToSchool()
        {
            return new School()
            {
                Name = Name,
                FullName = FullName,
                Owner = Owner
            };
        }
    }

    public class EditSchool
    {
        [Required]
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Owner { get; set; }

        public void UpdateSchoolFields(School originalSchool)
        {
            originalSchool.Name = Name;
            originalSchool.FullName = FullName;
            originalSchool.Owner = Owner;
        }
    }
}
