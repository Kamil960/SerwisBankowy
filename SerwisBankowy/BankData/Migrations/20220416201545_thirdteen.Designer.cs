﻿// <auto-generated />
using System;
using BankData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankData.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220416201545_thirdteen")]
    partial class thirdteen
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BankData.Data.Bank.Klient", b =>
                {
                    b.Property<int>("IdKlient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKlient"), 1L, 1);

                    b.Property<bool?>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KodPocztowy")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Miejscowosc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrBudynku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrDokumentu")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("Poczta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdKlient");

                    b.ToTable("Klient");
                });

            modelBuilder.Entity("BankData.Data.Bank.KontoFirmowe", b =>
                {
                    b.Property<int>("IdUslugaSzczegolowa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUslugaSzczegolowa"), 1L, 1);

                    b.Property<bool?>("CzyAktywna")
                        .HasColumnType("bit");

                    b.Property<string>("Grafika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsluga")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<int?>("Pozycja")
                        .HasColumnType("int");

                    b.HasKey("IdUslugaSzczegolowa");

                    b.ToTable("KontoFirmowe");
                });

            modelBuilder.Entity("BankData.Data.Bank.KontoOsobiste", b =>
                {
                    b.Property<int>("IdUslugaSzczegolowa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUslugaSzczegolowa"), 1L, 1);

                    b.Property<bool?>("CzyAktywna")
                        .HasColumnType("bit");

                    b.Property<string>("Grafika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsluga")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<int?>("Pozycja")
                        .HasColumnType("int");

                    b.HasKey("IdUslugaSzczegolowa");

                    b.ToTable("KontoOsobiste");
                });

            modelBuilder.Entity("BankData.Data.Bank.Kredyt", b =>
                {
                    b.Property<int>("IdUslugaSzczegolowa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUslugaSzczegolowa"), 1L, 1);

                    b.Property<bool?>("CzyAktywna")
                        .HasColumnType("bit");

                    b.Property<string>("Grafika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsluga")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<int?>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Procent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUslugaSzczegolowa");

                    b.ToTable("Kredyt");
                });

            modelBuilder.Entity("BankData.Data.Bank.Lokata", b =>
                {
                    b.Property<int>("IdUslugaSzczegolowa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUslugaSzczegolowa"), 1L, 1);

                    b.Property<bool?>("CzyAktywna")
                        .HasColumnType("bit");

                    b.Property<string>("Grafika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsluga")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<int?>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Procent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUslugaSzczegolowa");

                    b.ToTable("Lokata");
                });

            modelBuilder.Entity("BankData.Data.Bank.Ubezpieczenie", b =>
                {
                    b.Property<int>("IdUslugaSzczegolowa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUslugaSzczegolowa"), 1L, 1);

                    b.Property<bool?>("CzyAktywna")
                        .HasColumnType("bit");

                    b.Property<string>("Grafika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsluga")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<int?>("Pozycja")
                        .HasColumnType("int");

                    b.HasKey("IdUslugaSzczegolowa");

                    b.ToTable("Ubezpieczenie");
                });

            modelBuilder.Entity("BankData.Data.Bank.UslugaSzczegolowa", b =>
                {
                    b.Property<int>("IdUslugaSzczegolowa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUslugaSzczegolowa"), 1L, 1);

                    b.Property<bool?>("CzyAktywna")
                        .HasColumnType("bit");

                    b.Property<string>("Grafika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsluga")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<int?>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Procent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUslugaSzczegolowa");

                    b.ToTable("UslugaSzczegolowa");
                });

            modelBuilder.Entity("BankData.Data.CMS.Art1", b =>
                {
                    b.Property<int>("IdArt1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArt1"), 1L, 1);

                    b.Property<string>("Grafika1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grafika2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grafika3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa1")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Nazwa2")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Nazwa3")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Opis1")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Opis2")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Opis3")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Podsumowanie")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdArt1");

                    b.ToTable("Art1");
                });

            modelBuilder.Entity("BankData.Data.CMS.Art2", b =>
                {
                    b.Property<int>("IdArt2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArt2"), 1L, 1);

                    b.Property<string>("Grafika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tresc1")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Tresc2")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("IdArt2");

                    b.ToTable("Art2");
                });

            modelBuilder.Entity("BankData.Data.CMS.Art3", b =>
                {
                    b.Property<int>("IdArt3")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArt3"), 1L, 1);

                    b.Property<string>("CrypIcon1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrypIcon2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrypIcon3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrypIcon4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrypTytul")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Crypto1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Crypto2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Crypto3")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Crypto4")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Grafika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PozGieldowa1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PozGieldowa2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PozGieldowa3")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("PozGieldowa4")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Tresc1")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Tresc2")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdArt3");

                    b.ToTable("Art3");
                });

            modelBuilder.Entity("BankData.Data.CMS.Kontakt", b =>
                {
                    b.Property<int>("IdKontakt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKontakt"), 1L, 1);

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grafika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrTelefonuKom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrTelefonuSt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis1")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Opis2")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Opis3")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Opis4")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdKontakt");

                    b.ToTable("Kontakt");
                });

            modelBuilder.Entity("BankData.Data.CMS.ONas", b =>
                {
                    b.Property<int>("IdONas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdONas"), 1L, 1);

                    b.Property<string>("Grafika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdONas");

                    b.ToTable("ONas");
                });

            modelBuilder.Entity("BankData.Data.CMS.Strony", b =>
                {
                    b.Property<int>("IdStrony")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStrony"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Pozycja")
                        .HasColumnType("int");

                    b.HasKey("IdStrony");

                    b.ToTable("Strony");
                });

            modelBuilder.Entity("BankData.Data.CMS.Usluga", b =>
                {
                    b.Property<int>("IdUsluga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsluga"), 1L, 1);

                    b.Property<string>("Grafika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.HasKey("IdUsluga");

                    b.ToTable("Usluga");
                });
#pragma warning restore 612, 618
        }
    }
}
