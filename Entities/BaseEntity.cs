﻿namespace LuftbornCodeTest;
public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;

    public DateTime? ModificationDate { get; set; }
}
