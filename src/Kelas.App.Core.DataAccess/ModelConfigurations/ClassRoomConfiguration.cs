﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kelas.App.Core.DataAccess.ModelConfigurations
{
    public static class ClassRoomConfiguration
    {
        public static void ConfigureClassRoom(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRoom.ClassRoom>()
                .HasOne(c => c.School)
                .WithMany(s => s.ClassRooms)
                .HasForeignKey(c => c.SchoolId);
        }
    }
}
