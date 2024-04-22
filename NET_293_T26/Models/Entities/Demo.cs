using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NET_293_T26.Models.Entities;

[Table("Demo")]
public partial class Demo
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(10)]
    public string? Name { get; set; }
}
