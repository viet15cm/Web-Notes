﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectWebNotes.DbContextLayer;

#nullable disable

namespace ProjectWebNotes.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    [Migration("20230315103704_v_1")]
    partial class v_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IConFont")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ParentCategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Serial")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.HasIndex("Slug");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PostId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Entities.Models.Post", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PostParentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Prime")
                        .HasColumnType("bit");

                    b.Property<int>("Serial")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.HasKey("Id");

                    b.HasIndex("PostParentId");

                    b.HasIndex("Slug");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Entities.Models.PostCategory", b =>
                {
                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PostID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Serial")
                        .HasColumnType("int");

                    b.HasKey("CategoryID", "PostID");

                    b.HasIndex("PostID");

                    b.ToTable("PostCategory");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.HasOne("Entities.Models.Category", "ParentCategory")
                        .WithMany("CategoryChildren")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Entities.Models.Image", b =>
                {
                    b.HasOne("Entities.Models.Post", "Post")
                        .WithMany("Images")
                        .HasForeignKey("PostId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Entities.Models.Post", b =>
                {
                    b.HasOne("Entities.Models.Post", "PostParent")
                        .WithMany("PostChilds")
                        .HasForeignKey("PostParentId");

                    b.Navigation("PostParent");
                });

            modelBuilder.Entity("Entities.Models.PostCategory", b =>
                {
                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Post", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("CategoryChildren");

                    b.Navigation("PostCategories");
                });

            modelBuilder.Entity("Entities.Models.Post", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("PostCategories");

                    b.Navigation("PostChilds");
                });
#pragma warning restore 612, 618
        }
    }
}