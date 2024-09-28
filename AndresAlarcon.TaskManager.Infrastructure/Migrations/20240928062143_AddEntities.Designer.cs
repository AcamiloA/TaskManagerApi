﻿// <auto-generated />
using System;
using AndresAlarcon.TaskManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AndresAlarcon.TaskManager.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240928062143_AddEntities")]
    partial class AddEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AndresAlarcon.TaskManager.Domain.Entities.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedOn");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)")
                        .HasColumnName("Description");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime")
                        .HasColumnName("DueDate");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int")
                        .HasColumnName("PriorityId");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Title");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdatedOn");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("PriorityId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserId");

                    b.ToTable("Board", "TaskManager");
                });

            modelBuilder.Entity("AndresAlarcon.TaskManager.Domain.Entities.Priority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedOn");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Priority", "TaskManager");
                });

            modelBuilder.Entity("AndresAlarcon.TaskManager.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedOn");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Role", "TaskManager");
                });

            modelBuilder.Entity("AndresAlarcon.TaskManager.Domain.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedOn");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Status", "TaskManager");
                });

            modelBuilder.Entity("AndresAlarcon.TaskManager.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedOn");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("PasswordHash");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleId");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdatedOn");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User", "TaskManager");
                });

            modelBuilder.Entity("AndresAlarcon.TaskManager.Domain.Entities.Board", b =>
                {
                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Priority");

                    b.Navigation("Status");

                    b.Navigation("Updater");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AndresAlarcon.TaskManager.Domain.Entities.Priority", b =>
                {
                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("AndresAlarcon.TaskManager.Domain.Entities.Role", b =>
                {
                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("AndresAlarcon.TaskManager.Domain.Entities.Status", b =>
                {
                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.User", "Updater")
                        .WithMany()
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Updater");
                });

            modelBuilder.Entity("AndresAlarcon.TaskManager.Domain.Entities.User", b =>
                {
                    b.HasOne("AndresAlarcon.TaskManager.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
