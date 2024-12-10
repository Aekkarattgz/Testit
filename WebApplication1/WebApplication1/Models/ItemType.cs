﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ItemType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
