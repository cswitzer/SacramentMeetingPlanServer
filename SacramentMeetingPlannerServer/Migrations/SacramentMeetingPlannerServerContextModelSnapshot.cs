﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentMeetingPlannerServer.Data;

#nullable disable

namespace SacramentMeetingPlannerServer.Migrations
{
    [DbContext(typeof(SacramentMeetingPlannerServerContext))]
    partial class SacramentMeetingPlannerServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SacramentMeetingPlannerServer.Models.Hymn", b =>
                {
                    b.Property<int>("HymnNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HymnNumber"), 1L, 1);

                    b.Property<string>("HymnTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HymnType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HymnNumber");

                    b.ToTable("Hymn");
                });

            modelBuilder.Entity("SacramentMeetingPlannerServer.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("SacramentMeetingPlannerServer.Models.SacramentMeetingPlan", b =>
                {
                    b.Property<int>("SacramentMeetingPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SacramentMeetingPlanId"), 1L, 1);

                    b.Property<int>("ClosingHymnId")
                        .HasColumnType("int");

                    b.Property<int>("ClosingPrayerId")
                        .HasColumnType("int");

                    b.Property<int>("ConductingLeaderId")
                        .HasColumnType("int");

                    b.Property<int?>("IntermediateHymnId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MeetingTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("OpeningHymnId")
                        .HasColumnType("int");

                    b.Property<int>("OpeningPrayerId")
                        .HasColumnType("int");

                    b.Property<int>("SacramentHymnId")
                        .HasColumnType("int");

                    b.Property<int>("SacramentPrayerId")
                        .HasColumnType("int");

                    b.HasKey("SacramentMeetingPlanId");

                    b.HasIndex("ClosingHymnId");

                    b.HasIndex("ClosingPrayerId");

                    b.HasIndex("ConductingLeaderId");

                    b.HasIndex("IntermediateHymnId");

                    b.HasIndex("OpeningHymnId");

                    b.HasIndex("OpeningPrayerId");

                    b.HasIndex("SacramentHymnId");

                    b.HasIndex("SacramentPrayerId");

                    b.ToTable("SacramentMeetingPlan");
                });

            modelBuilder.Entity("SacramentMeetingPlannerServer.Models.Speaker", b =>
                {
                    b.Property<int>("SpeakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpeakerId"), 1L, 1);

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("SacramentMeetingPlanId")
                        .HasColumnType("int");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpeakerId");

                    b.HasIndex("MemberId");

                    b.HasIndex("SacramentMeetingPlanId");

                    b.ToTable("Speaker");
                });

            modelBuilder.Entity("SacramentMeetingPlannerServer.Models.SacramentMeetingPlan", b =>
                {
                    b.HasOne("SacramentMeetingPlannerServer.Models.Hymn", "ClosingHymn")
                        .WithMany()
                        .HasForeignKey("ClosingHymnId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlannerServer.Models.Member", "ClosingPrayer")
                        .WithMany()
                        .HasForeignKey("ClosingPrayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlannerServer.Models.Member", "ConductingLeader")
                        .WithMany()
                        .HasForeignKey("ConductingLeaderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlannerServer.Models.Hymn", "IntermediateHymn")
                        .WithMany()
                        .HasForeignKey("IntermediateHymnId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SacramentMeetingPlannerServer.Models.Hymn", "OpeningHymn")
                        .WithMany()
                        .HasForeignKey("OpeningHymnId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlannerServer.Models.Member", "OpeningPrayer")
                        .WithMany()
                        .HasForeignKey("OpeningPrayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlannerServer.Models.Hymn", "SacramentHymn")
                        .WithMany()
                        .HasForeignKey("SacramentHymnId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlannerServer.Models.Member", "SacramentPrayer")
                        .WithMany()
                        .HasForeignKey("SacramentPrayerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClosingHymn");

                    b.Navigation("ClosingPrayer");

                    b.Navigation("ConductingLeader");

                    b.Navigation("IntermediateHymn");

                    b.Navigation("OpeningHymn");

                    b.Navigation("OpeningPrayer");

                    b.Navigation("SacramentHymn");

                    b.Navigation("SacramentPrayer");
                });

            modelBuilder.Entity("SacramentMeetingPlannerServer.Models.Speaker", b =>
                {
                    b.HasOne("SacramentMeetingPlannerServer.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlannerServer.Models.SacramentMeetingPlan", "SacramentMeetingPlan")
                        .WithMany("Speakers")
                        .HasForeignKey("SacramentMeetingPlanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("SacramentMeetingPlan");
                });

            modelBuilder.Entity("SacramentMeetingPlannerServer.Models.SacramentMeetingPlan", b =>
                {
                    b.Navigation("Speakers");
                });
#pragma warning restore 612, 618
        }
    }
}
