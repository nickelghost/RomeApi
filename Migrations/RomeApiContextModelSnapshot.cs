﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RomeApi.Data;

namespace RomeApi.Migrations
{
    [DbContext(typeof(RomeApiContext))]
    partial class RomeApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RomeApi.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CategoryGroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_group_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("parent_category_id");

                    b.Property<double>("Rank")
                        .HasColumnType("double precision")
                        .HasColumnName("rank");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.HasIndex("CategoryGroupId")
                        .HasDatabaseName("ix_categories_category_group_id");

                    b.HasIndex("ParentCategoryId")
                        .HasDatabaseName("ix_categories_parent_category_id");

                    b.HasIndex("Rank")
                        .IsUnique()
                        .HasDatabaseName("ix_categories_rank");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("RomeApi.Models.CategoryGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Rank")
                        .HasColumnType("double precision")
                        .HasColumnName("rank");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id")
                        .HasName("pk_category_groups");

                    b.HasIndex("Rank")
                        .IsUnique()
                        .HasDatabaseName("ix_category_groups_rank");

                    b.ToTable("category_groups");
                });

            modelBuilder.Entity("RomeApi.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("author_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uuid")
                        .HasColumnName("topic_id");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id")
                        .HasName("pk_posts");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("ix_posts_author_id");

                    b.HasIndex("TopicId")
                        .HasDatabaseName("ix_posts_topic_id");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("RomeApi.Models.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("author_id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id")
                        .HasName("pk_topics");

                    b.HasIndex("AuthorId")
                        .HasDatabaseName("ix_topics_author_id");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_topics_category_id");

                    b.ToTable("topics");
                });

            modelBuilder.Entity("RomeApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_admin");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_users_name");

                    b.ToTable("users");
                });

            modelBuilder.Entity("RomeApi.Models.Category", b =>
                {
                    b.HasOne("RomeApi.Models.CategoryGroup", "CategoryGroup")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryGroupId")
                        .HasConstraintName("fk_categories_category_groups_category_group_id");

                    b.HasOne("RomeApi.Models.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId")
                        .HasConstraintName("fk_categories_categories_parent_category_id");

                    b.Navigation("CategoryGroup");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("RomeApi.Models.Post", b =>
                {
                    b.HasOne("RomeApi.Models.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("fk_posts_users_author_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RomeApi.Models.Topic", "Topic")
                        .WithMany("Posts")
                        .HasForeignKey("TopicId")
                        .HasConstraintName("fk_posts_topics_topic_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("RomeApi.Models.Topic", b =>
                {
                    b.HasOne("RomeApi.Models.User", "Author")
                        .WithMany("Topics")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("fk_topics_users_author_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RomeApi.Models.Category", "Category")
                        .WithMany("Topics")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_topics_categories_category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RomeApi.Models.Category", b =>
                {
                    b.Navigation("ChildCategories");

                    b.Navigation("Topics");
                });

            modelBuilder.Entity("RomeApi.Models.CategoryGroup", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("RomeApi.Models.Topic", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("RomeApi.Models.User", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Topics");
                });
#pragma warning restore 612, 618
        }
    }
}
