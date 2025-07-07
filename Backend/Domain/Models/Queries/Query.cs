using System;

namespace Backend.Domain.Models.Queries;

public class Query
{
    public int Page { get; protected set; }
    public int ItemPerPage { get; protected set; }

    public Query(int page, int itemPerPage)
    {
        Page = page;
        ItemPerPage = itemPerPage;

        if (page <= 0)
        {
            Page = 1;
        }
        if (ItemPerPage <= 0)
        {
            itemPerPage = 10;
        }
    }
}
