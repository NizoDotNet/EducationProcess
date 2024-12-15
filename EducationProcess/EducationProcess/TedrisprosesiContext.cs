using System;
using System.Collections.Generic;
using EducationProcess.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationProcess;

public partial class TedrisprosesiContext : DbContext
{
    public TedrisprosesiContext()
    {
    }

    public TedrisprosesiContext(DbContextOptions<TedrisprosesiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cafedra> Cafedras { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Subjecttecher> Subjecttechers { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=nizami5wifi;database=tedrisprosesi");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cafedra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cafedra");

            entity.HasIndex(e => e.FacultyId, "FacultyId");

            entity.Property(e => e.Name).HasMaxLength(40);

            entity.HasOne(d => d.Faculty).WithMany(p => p.Cafedras)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("cafedra_ibfk_1");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("faculty");

            entity.Property(e => e.Adress).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(40);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("grades");

            entity.HasIndex(e => e.StudentId, "student_id");

            entity.HasIndex(e => e.SubjectId, "subject_id");

            entity.HasIndex(e => e.TeacherId, "teacher_id");

            entity.Property(e => e.ExamScore)
                .HasPrecision(10)
                .HasColumnName("exam_score");
            entity.Property(e => e.SemesterScore)
                .HasPrecision(10)
                .HasColumnName("semester_score");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("grades_ibfk_1");

            entity.HasOne(d => d.Subject).WithMany(p => p.Grades)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("grades_ibfk_3");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Grades)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("grades_ibfk_2");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("specialization");

            entity.HasIndex(e => e.CafedraId, "CafedraId");

            entity.Property(e => e.Name).HasMaxLength(40);

            entity.HasOne(d => d.Cafedra).WithMany(p => p.Specializations)
                .HasForeignKey(d => d.CafedraId)
                .HasConstraintName("specialization_ibfk_1");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student");

            entity.HasIndex(e => e.SpecializationId, "SpecializationId");

            entity.Property(e => e.Firstname).HasMaxLength(40);
            entity.Property(e => e.Lastname).HasMaxLength(40);
            entity.Property(e => e.Pin)
                .HasMaxLength(7)
                .HasColumnName("PIN");

            entity.HasOne(d => d.Specialization).WithMany(p => p.Students)
                .HasForeignKey(d => d.SpecializationId)
                .HasConstraintName("student_ibfk_1");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subject");

            entity.HasIndex(e => e.CafedraId, "CafedraId");

            entity.Property(e => e.Name).HasColumnType("text");

            entity.HasOne(d => d.Cafedra).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.CafedraId)
                .HasConstraintName("subject_ibfk_1");
        });

        modelBuilder.Entity<Subjecttecher>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("subjecttecher");

            entity.HasIndex(e => e.SubjectId, "SubjectId");

            entity.HasIndex(e => e.TecherId, "TecherId");

            entity.HasOne(d => d.Subject).WithMany()
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("subjecttecher_ibfk_1");

            entity.HasOne(d => d.Techer).WithMany()
                .HasForeignKey(d => d.TecherId)
                .HasConstraintName("subjecttecher_ibfk_2");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("teacher");

            entity.HasIndex(e => e.CafedraId, "CafedraId");

            entity.Property(e => e.Firstname).HasMaxLength(40);
            entity.Property(e => e.Lastname).HasMaxLength(40);
            entity.Property(e => e.Pin)
                .HasMaxLength(7)
                .HasColumnName("PIN");

            entity.HasOne(d => d.Cafedra).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.CafedraId)
                .HasConstraintName("teacher_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
