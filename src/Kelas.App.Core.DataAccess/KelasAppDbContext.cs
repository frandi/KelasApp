using Kelas.App.Core.DataAccess.ModelConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.DataAccess
{
    public class KelasAppDbContext: DbContext
    {
        public KelasAppDbContext(DbContextOptions<KelasAppDbContext> options)
            : base (options)
        {
            
        }

        public DbSet<ClassRoom.ClassRoom> ClassRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureClassRoom();
        }
    }
}
