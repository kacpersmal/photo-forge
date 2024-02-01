﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhotoForge.Infrastructure.Database;

#nullable disable

namespace PhotoForge.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240131213824_TokenVO")]
    partial class TokenVO
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PhotoForge.Core.Features.Auth.UserSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastRefresh")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserAgent")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSession", "Auth");
                });

            modelBuilder.Entity("PhotoForge.Core.Features.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("User", "User");
                });

            modelBuilder.Entity("PhotoForge.Core.Features.Auth.UserSession", b =>
                {
                    b.HasOne("PhotoForge.Core.Features.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("PhotoForge.Core.ValueObjects.Token", "RefreshToken", b1 =>
                        {
                            b1.Property<Guid>("UserSessionId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("ExpirationDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserSessionId");

                            b1.ToTable("UserSession", "Auth");

                            b1.WithOwner()
                                .HasForeignKey("UserSessionId");
                        });

                    b.OwnsOne("PhotoForge.Core.ValueObjects.Token", "Token", b1 =>
                        {
                            b1.Property<Guid>("UserSessionId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("ExpirationDate")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserSessionId");

                            b1.ToTable("UserSession", "Auth");

                            b1.WithOwner()
                                .HasForeignKey("UserSessionId");
                        });

                    b.Navigation("RefreshToken")
                        .IsRequired();

                    b.Navigation("Token")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PhotoForge.Core.Features.Users.User", b =>
                {
                    b.OwnsOne("PhotoForge.Core.ValueObjects.EmailAddress", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.ToTable("User", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("PhotoForge.Core.ValueObjects.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.ToTable("User", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("PhotoForge.Core.ValueObjects.HashedValue", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<byte[]>("Hash")
                                .IsRequired()
                                .HasColumnType("bytea");

                            b1.Property<byte[]>("Salt")
                                .IsRequired()
                                .HasColumnType("bytea");

                            b1.HasKey("UserId");

                            b1.ToTable("User", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("FullName")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
