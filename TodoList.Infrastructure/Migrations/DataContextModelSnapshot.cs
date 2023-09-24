﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.Infrastructure;

#nullable disable

namespace TodoList.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TodoList.Domain.Entities.TodoListData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("NOW(6)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("NOW(6) ON UPDATE NOW(6)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("Id", "IsDeleted", "Title", "UpdatedAt");

                    b.ToTable("todo_list", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
