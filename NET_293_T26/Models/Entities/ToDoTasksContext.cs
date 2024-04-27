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

    public virtual DbSet<ToDoTask> ToDoTasks { get; set; }
}
