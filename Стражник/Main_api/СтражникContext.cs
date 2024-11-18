using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Main_api;

public partial class СтражникContext : DbContext
{
    public СтражникContext()
    {
    }

    public СтражникContext(DbContextOptions<СтражникContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Должность> Должностьs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<ТипПользователя> ТипПользователяs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database = Стражник;Trusted_connection = true;TrustServerCertificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Должность>(entity =>
        {
            entity.ToTable("Должность");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Должность1)
                .HasMaxLength(255)
                .HasColumnName("Должность");
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Пользователи1");

            entity.ToTable("Пользователи");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Логин).HasMaxLength(255);
            entity.Property(e => e.Пароль).HasMaxLength(255);
            entity.Property(e => e.Пол).HasMaxLength(255);
            entity.Property(e => e.СекретноеСлово)
                .HasMaxLength(255)
                .HasColumnName("Секретное слово");
            entity.Property(e => e.ТипПользователя).HasColumnName("Тип пользователя");
            entity.Property(e => e.Фио)
                .HasMaxLength(255)
                .HasColumnName("ФИО");

            entity.HasOne(d => d.ДолжностьNavigation).WithMany(p => p.Пользователиs)
                .HasForeignKey(d => d.Должность)
                .HasConstraintName("FK_Пользователи_Должность");

            entity.HasOne(d => d.ТипПользователяNavigation).WithMany(p => p.Пользователиs)
                .HasForeignKey(d => d.ТипПользователя)
                .HasConstraintName("FK_Пользователи_'Тип пользователя'");
        });

        modelBuilder.Entity<ТипПользователя>(entity =>
        {
            entity.ToTable("'Тип пользователя'");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ТипПользователя1)
                .HasMaxLength(255)
                .HasColumnName("Тип пользователя");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
