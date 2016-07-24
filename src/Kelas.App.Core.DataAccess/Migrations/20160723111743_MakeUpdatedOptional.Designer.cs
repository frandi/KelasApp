using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Kelas.App.Core.DataAccess;

namespace Kelas.App.Core.DataAccess.Migrations
{
    [DbContext(typeof(KelasAppDbContext))]
    [Migration("20160723111743_MakeUpdatedOptional")]
    partial class MakeUpdatedOptional
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kelas.App.Core.ClassRoom.ClassRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("SchoolId");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Kelas.App.Core.School.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("FullName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("Kelas.App.Core.ClassRoom.ClassRoom", b =>
                {
                    b.HasOne("Kelas.App.Core.School.School", "School")
                        .WithMany("ClassRooms")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
