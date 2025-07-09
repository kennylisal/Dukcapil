using System;

namespace Backend.Domain.Models.Queries;

public class QueryResults<T>
{
    public List<T> Items { get; set; } = [];
    public int TotalItems { get; set; } = 0;
}
