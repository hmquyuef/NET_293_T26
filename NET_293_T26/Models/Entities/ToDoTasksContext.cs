using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NET_293_T26.Models.Entities;

public partial class ToDoTasksContext : DbContext
{
    public ToDoTasksContext()
    {
    }

    public ToDoTasksContext(DbContextOptions<ToDoTasksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Demo> Demos { get; set; }
    public virtual DbSet<Demo1> Demo1s { get; set; }

    public virtual DbSet<DetailTask> DetailTasks { get; set; }

    public virtual DbSet<ToDoTask> ToDoTasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Demo>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).IsFixedLength();
        });

        modelBuilder.Entity<DetailTask>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<ToDoTask>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
