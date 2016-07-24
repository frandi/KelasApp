using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.DataAccess.ModelConfigurations
{
    public static class SchoolConfiguration
    {
        public static void ConfigureSchool(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School.School>().HasIndex(s => s.Name).IsUnique();
        }
    }
}
