﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroPersonaExtra.DAL;

namespace RegistroPersonaExtra.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200307024334_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("RegistroPersonaExtra.Entidades.Personas", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonaId");

                    b.ToTable("personas");
                });
#pragma warning restore 612, 618
        }
    }
}
