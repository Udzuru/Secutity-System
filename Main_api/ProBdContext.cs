using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Main_api;

public partial class ProBdContext : DbContext
{
    public ProBdContext()
    {
    }

    public ProBdContext(DbContextOptions<ProBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Time> Times { get; set; }

    public virtual DbSet<Typ> Typs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Zaivki> Zaivkis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database = PRO_bd;Trusted_connection = true;TrustServerCertificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Сотрудники");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Otdel).HasMaxLength(255);
            entity.Property(e => e.Snp)
                .HasMaxLength(255)
                .HasColumnName("SNP");
            entity.Property(e => e.Where).HasMaxLength(255);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(255)
                .HasColumnName("date of birth");
            entity.Property(e => e.EMail)
                .HasMaxLength(255)
                .HasColumnName("E-mail");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Organization).HasMaxLength(255);
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(255)
                .HasColumnName("Passport number");
            entity.Property(e => e.PassportSeria).HasColumnName("Passport seria");
            entity.Property(e => e.Patronimic).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("Phone number");
            entity.Property(e => e.Surname).HasMaxLength(255);
        });

        modelBuilder.Entity<Time>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Times__3214EC07134AFFDA");

            entity.Property(e => e.TimeEnd)
                .HasColumnType("datetime")
                .HasColumnName("Time_end");
            entity.Property(e => e.TimeSt)
                .HasColumnType("datetime")
                .HasColumnName("Time_st");

            entity.HasOne(d => d.People).WithMany(p => p.Times)
                .HasForeignKey(d => d.PeopleId)
                .HasConstraintName("FK_Times_PeopleID");
        });

        modelBuilder.Entity<Typ>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_People_reg");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<Zaivki>(entity =>
        {
            entity.ToTable("Zaivki");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.FromDate)
                .HasColumnType("datetime")
                .HasColumnName("From_date");
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.ToDate)
                .HasColumnType("datetime")
                .HasColumnName("To_date");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.PeopleNavigation).WithMany(p => p.Zaivkis)
                .HasForeignKey(d => d.People)
                .HasConstraintName("FK__Zaivki__People__1ED998B2");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Zaivkis)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("FK_Zaivki_Typs");

            entity.HasOne(d => d.WhereNavigation).WithMany(p => p.Zaivkis)
                .HasForeignKey(d => d.Where)
                .HasConstraintName("FK__Zaivki__Where__239E4DCF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
