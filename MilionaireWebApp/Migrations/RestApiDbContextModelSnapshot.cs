﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using MilionaireWebApp.Models;
using System;

namespace MilionaireWebApp.Migrations
{
    [DbContext(typeof(RestApiDbContext))]
    partial class RestApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("MilionaireWebApp.Models.QuestionModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Question");

                    b.Property<string>("RightAnswer");

                    b.Property<string>("WrongAnswer1");

                    b.Property<string>("WrongAnswer2");

                    b.Property<string>("WrongAnswer3");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
