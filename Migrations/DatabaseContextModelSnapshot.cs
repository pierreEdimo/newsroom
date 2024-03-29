﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using newsroom.DBContext;

namespace newsroom.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("newsroom.Model.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommentCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageCredits")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<int>("TopicId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TopicId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CommentCount = 0,
                            Content = "**Programming is a very hard and demanding task. I dont# t want to say i am some sort expert or anything like that , but i havebeen learning programming since 2 years and i want to share my experience so far**\n\n\nAt first glance, you should know that the market for electric cars is growing thanks to the aid proposed by the European Union, but due to the crisis caused by Covid, the traditional German brands are facing a huge crisis. In addition to facing their production bases, they have to invest even more capital to electrify their fleets. The result ? Mercedes Benz, for example, has launched a vast savings programme, which consists in cutting unnecessary expenses, delocalising the production of its engines for China, and thanking its workers. Indeed, Mercedes Benz has thanked more than 10,000 employees in 2020, and it's not over yet. \n\n\nIt is not only Daimler that has to restructure. Even Volkswagen Ag and the BMW group are facing the same problems. Volkswagen, on the other hand, is a little ahead of the game. While the Mercedes EQC (the first fully electric model of Mercedes) was a flop, the electric cars produced by vw have been a huge success in Europe.\n\n\nNow let's talk about Tesla. Tesla was created in 2003 by Elon Musk and was the first to create an entire fleet of 100% electric vehicles. In the beginning nobody took them seriously. But today it is a completely different story. The Tesla Model 3 is the cheapest model offered by Tesla and is the most popular and best-selling electric car in the world. That said, Tesla is not yet a profitable business. But that can change very quickly.\n\n\nIn conclusion, Tesla is changing the world whether we like it or not, and German brands have reason to be afraid.",
                            CreatedAt = new DateTime(2022, 1, 12, 21, 50, 48, 435, DateTimeKind.Local).AddTicks(2978),
                            ImageCredits = "www.unsplash.com",
                            ImageUrl = "https://images.unsplash.com/photo-1587620962725-abab7fe55159?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1489&q=80",
                            IsFavorite = false,
                            Title = "Getting started with Programming",
                            TopicId = 2
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            CommentCount = 0,
                            Content = "**At the end of 2019, everyone announced Tesla's death. But todayTesla is more valuable than Volswagen, Daimler and Toyota put together, I'll explain why and what it means for German brands.**\n\n\nAt first glance, you should know that the market for electric cars is growing thanks to the aid proposed by the European Union, but due to the crisis caused by Covid, the traditional German brands are facing a huge crisis. In addition to facing their production bases, they have to invest even more capital to electrify their fleets. The result ? Mercedes Benz, for example, has launched a vast savings programme, which consists in cutting unnecessary expenses, delocalising the production of its engines for China, and thanking its workers. Indeed, Mercedes Benz has thanked more than 10,000 employees in 2020, and it's not over yet. \n\n\nIt is not only Daimler that has to restructure. Even Volkswagen Ag and the BMW group are facing the same problems. Volkswagen, on the other hand, is a little ahead of the game. While the Mercedes EQC (the first fully electric model of Mercedes) was a flop, the electric cars produced by vw have been a huge success in Europe.\n\n\nNow let's talk about Tesla. Tesla was created in 2003 by Elon Musk and was the first to create an entire fleet of 100% electric vehicles. In the beginning nobody took them seriously. But today it is a completely different story. The Tesla Model 3 is the cheapest model offered by Tesla and is the most popular and best-selling electric car in the world. That said, Tesla is not yet a profitable business. But that can change very quickly.\n\n\nIn conclusion, Tesla is changing the world whether we like it or not, and German brands have reason to be afraid.",
                            CreatedAt = new DateTime(2022, 1, 12, 21, 50, 48, 439, DateTimeKind.Local).AddTicks(8334),
                            ImageCredits = "www.unsplash.com",
                            ImageUrl = "https://images.unsplash.com/photo-1571987502227-9231b837d92a?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=700&q=80",
                            IsFavorite = false,
                            Title = "Tesla is the highest publicly valuated car manufacturer, what does it mean for Germany",
                            TopicId = 2
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            CommentCount = 0,
                            Content = "**At the end of 2019, everyone announced Tesla's death. But todayTesla is more valuable than Volswagen, Daimler and Toyota put together, I'll explain why and what it means for German brands.**\n\n\nAt first glance, you should know that the market for electric cars is growing thanks to the aid proposed by the European Union, but due to the crisis caused by Covid, the traditional German brands are facing a huge crisis. In addition to facing their production bases, they have to invest even more capital to electrify their fleets. The result ? Mercedes Benz, for example, has launched a vast savings programme, which consists in cutting unnecessary expenses, delocalising the production of its engines for China, and thanking its workers. Indeed, Mercedes Benz has thanked more than 10,000 employees in 2020, and it's not over yet. \n\n\nIt is not only Daimler that has to restructure. Even Volkswagen Ag and the BMW group are facing the same problems. Volkswagen, on the other hand, is a little ahead of the game. While the Mercedes EQC (the first fully electric model of Mercedes) was a flop, the electric cars produced by vw have been a huge success in Europe.\n\n\nNow let's talk about Tesla. Tesla was created in 2003 by Elon Musk and was the first to create an entire fleet of 100% electric vehicles. In the beginning nobody took them seriously. But today it is a completely different story. The Tesla Model 3 is the cheapest model offered by Tesla and is the most popular and best-selling electric car in the world. That said, Tesla is not yet a profitable business. But that can change very quickly.\n\n\nIn conclusion, Tesla is changing the world whether we like it or not, and German brands have reason to be afraid.",
                            CreatedAt = new DateTime(2022, 1, 12, 21, 50, 48, 439, DateTimeKind.Local).AddTicks(8403),
                            ImageCredits = "www.unsplash.com",
                            ImageUrl = "https://images.unsplash.com/photo-1545693315-85b6be26a3d6?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=871&q=80",
                            IsFavorite = false,
                            Title = "Genders aren't social constructs",
                            TopicId = 9
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 1,
                            CommentCount = 0,
                            Content = "**At the end of 2019, everyone announced Tesla's death. But todayTesla is more valuable than Volswagen, Daimler and Toyota put together, I'll explain why and what it means for German brands.**\n\n\nAt first glance, you should know that the market for electric cars is growing thanks to the aid proposed by the European Union, but due to the crisis caused by Covid, the traditional German brands are facing a huge crisis. In addition to facing their production bases, they have to invest even more capital to electrify their fleets. The result ? Mercedes Benz, for example, has launched a vast savings programme, which consists in cutting unnecessary expenses, delocalising the production of its engines for China, and thanking its workers. Indeed, Mercedes Benz has thanked more than 10,000 employees in 2020, and it's not over yet. \n\n\nIt is not only Daimler that has to restructure. Even Volkswagen Ag and the BMW group are facing the same problems. Volkswagen, on the other hand, is a little ahead of the game. While the Mercedes EQC (the first fully electric model of Mercedes) was a flop, the electric cars produced by vw have been a huge success in Europe.\n\n\nNow let's talk about Tesla. Tesla was created in 2003 by Elon Musk and was the first to create an entire fleet of 100% electric vehicles. In the beginning nobody took them seriously. But today it is a completely different story. The Tesla Model 3 is the cheapest model offered by Tesla and is the most popular and best-selling electric car in the world. That said, Tesla is not yet a profitable business. But that can change very quickly.\n\n\nIn conclusion, Tesla is changing the world whether we like it or not, and German brands have reason to be afraid.",
                            CreatedAt = new DateTime(2022, 1, 12, 21, 50, 48, 439, DateTimeKind.Local).AddTicks(8412),
                            ImageCredits = "www.unsplash.com",
                            ImageUrl = "https://images.unsplash.com/photo-1528629297340-d1d466945dc5?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=922&q=80",
                            IsFavorite = false,
                            Title = "Biking is healthy",
                            TopicId = 1
                        });
                });

            modelBuilder.Entity("newsroom.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = " Pierre Edimo "
                        });
                });

            modelBuilder.Entity("newsroom.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("newsroom.Model.FavoritesArticles", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OwnerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("ArticleId", "OwnerId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("newsroom.Model.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("newsroom.Model.SavedWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SavedWords");
                });

            modelBuilder.Entity("newsroom.Model.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://images.unsplash.com/photo-1483721310020-03333e577078?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1400&q=80",
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://images.unsplash.com/photo-1518770660439-4636190af475?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                            Name = "Tech/It"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "https://images.unsplash.com/photo-1532938911079-1b06ac7ceec7?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1489&q=80",
                            Name = "Health"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "https://images.unsplash.com/photo-1470076892663-af684e5e15af?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1217&q=80",
                            Name = "Entertainment"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "https://images.unsplash.com/photo-1454165804606-c3d57bc86b40?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                            Name = "Business"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "https://images.unsplash.com/photo-1501747315-124a0eaca060?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80",
                            Name = "Lifestyle"
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = "https://images.unsplash.com/photo-1520187044487-b2efb58f0cba?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80",
                            Name = "Religion"
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = "https://images.unsplash.com/photo-1476900543704-4312b78632f8?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=634&q=80",
                            Name = "Travel"
                        },
                        new
                        {
                            Id = 9,
                            ImageUrl = "https://images.unsplash.com/photo-1564325724739-bae0bd08762c?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                            Name = "Science"
                        },
                        new
                        {
                            Id = 10,
                            ImageUrl = "https://images.unsplash.com/photo-1535903021127-d50417eae4a3?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                            Name = "Politic"
                        });
                });

            modelBuilder.Entity("newsroom.Model.UserEntity", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("UserEntity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("newsroom.Model.Article", b =>
                {
                    b.HasOne("newsroom.Model.Author", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newsroom.Model.Topic", "Topic")
                        .WithMany("Articles")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("newsroom.Model.Comment", b =>
                {
                    b.HasOne("newsroom.Model.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newsroom.Model.UserEntity", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("newsroom.Model.FavoritesArticles", b =>
                {
                    b.HasOne("newsroom.Model.Article", "Article")
                        .WithMany("HasFavorites")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newsroom.Model.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("newsroom.Model.Report", b =>
                {
                    b.HasOne("newsroom.Model.Comment", "Comment")
                        .WithMany("Reports")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("newsroom.Model.Article", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("HasFavorites");
                });

            modelBuilder.Entity("newsroom.Model.Author", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("newsroom.Model.Comment", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("newsroom.Model.Topic", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("newsroom.Model.UserEntity", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
