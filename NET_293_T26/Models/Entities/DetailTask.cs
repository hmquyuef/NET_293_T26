using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NET_293_T26.Models.Entities;

public partial class DetailTask
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}
