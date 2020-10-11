﻿// <auto-generated />
using System;
using EfCoreTask.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCoreTask.Data.Migrations
{
    [DbContext(typeof(TeamDbContext))]
    [Migration("20201010185513_CreatedSchema")]
    partial class CreatedSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("EfCoreTask.Data.Model.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("EfCoreTask.Data.Model.TeamMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Title")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("EfCoreTask.Data.Model.TeamMember", b =>
                {
                    b.HasOne("EfCoreTask.Data.Model.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}
