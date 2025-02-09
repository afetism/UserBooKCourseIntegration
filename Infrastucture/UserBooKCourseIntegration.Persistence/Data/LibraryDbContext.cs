using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UserBooKCourseIntegration.Domain.Models.Concretes;
using UserBooKCourseIntegration.Persistence.Configuration.Configuration;

namespace UserBooKCourseIntegration.Persistence.Data;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext()
    {
    }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-0P1DC60\\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC07840AB856");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.ApplyConfiguration(new BookConfiguration());   

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC070076F2FB");
            entity.Property(e => e.VideoId).HasMaxLength(100);
            entity.Property(e => e.Mentor).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RequiredSkill).HasMaxLength(100);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genres__3214EC07D1E1DEB8");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Speciali__3214EC07C5A1113F");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07649AD678");

            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);

            entity.HasOne(d => d.Speciality).WithMany(p => p.Users)
                .HasForeignKey(d => d.SpecialityId)
                .HasConstraintName("FK__Users__Specialit__3B75D760");

            entity.HasMany(d => d.Books).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserBook",
                    r => r.HasOne<Book>().WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserBook__BookId__4CA06362"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserBook__UserId__4BAC3F29"),
                    j =>
                    {
                        j.HasKey("UserId", "BookId").HasName("PK__UserBook__7456C06C8F196821");
                        j.ToTable("UserBook");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
