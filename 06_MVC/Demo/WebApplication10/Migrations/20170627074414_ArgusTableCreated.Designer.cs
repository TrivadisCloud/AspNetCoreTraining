using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication10.Models;

namespace WebApplication10.Migrations
{
    [DbContext(typeof(ArgusContext))]
    [Migration("20170627074414_ArgusTableCreated")]
    partial class ArgusTableCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication10.Models.ArgusModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("ArgusModel");
                });

            modelBuilder.Entity("WebApplication10.Models.Mitarbeiter", b =>
                {
                    b.Property<int>("MitarbeiterID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArgusModelID");

                    b.Property<DateTime>("EingestelltAm");

                    b.HasKey("MitarbeiterID");

                    b.HasIndex("ArgusModelID");

                    b.ToTable("Mitarbeiter");
                });

            modelBuilder.Entity("WebApplication10.Models.Mitarbeiter", b =>
                {
                    b.HasOne("WebApplication10.Models.ArgusModel")
                        .WithMany("Angestellte")
                        .HasForeignKey("ArgusModelID");
                });
        }
    }
}
