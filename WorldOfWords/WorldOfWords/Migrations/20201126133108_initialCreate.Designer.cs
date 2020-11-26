﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WorldOfWords;

namespace WorldOfWords.Migrations
{
    [DbContext(typeof(WorldOfWordsContext))]
    [Migration("20201126133108_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WorldOfWords.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying");

                    b.Property<byte[]>("Image")
                        .HasColumnName("image")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.Property<int?>("TopicId")
                        .HasColumnName("topic_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("card");
                });

            modelBuilder.Entity("WorldOfWords.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.ToTable("topic");
                });

            modelBuilder.Entity("WorldOfWords.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("character varying");

                    b.Property<string>("FullName")
                        .HasColumnName("full_name")
                        .HasColumnType("character varying");

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("WorldOfWords.UserCard", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool?>("Answer")
                        .HasColumnName("answer")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("AnswerDate")
                        .HasColumnName("answer_date")
                        .HasColumnType("date");

                    b.Property<int?>("CardId")
                        .HasColumnName("card_id")
                        .HasColumnType("integer");

                    b.HasKey("UserId")
                        .HasName("user_card_pkey");

                    b.HasIndex("CardId");

                    b.ToTable("user_card");
                });

            modelBuilder.Entity("WorldOfWords.Card", b =>
                {
                    b.HasOne("WorldOfWords.Topic", "Topic")
                        .WithMany("Card")
                        .HasForeignKey("TopicId")
                        .HasConstraintName("card_topic_id_fkey");
                });

            modelBuilder.Entity("WorldOfWords.UserCard", b =>
                {
                    b.HasOne("WorldOfWords.Card", "Card")
                        .WithMany("UserCard")
                        .HasForeignKey("CardId")
                        .HasConstraintName("user_card_card_id_fkey");

                    b.HasOne("WorldOfWords.User", "User")
                        .WithOne("UserCard")
                        .HasForeignKey("WorldOfWords.UserCard", "UserId")
                        .HasConstraintName("user_card_user_id_fkey")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
