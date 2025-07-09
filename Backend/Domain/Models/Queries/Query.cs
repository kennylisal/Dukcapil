using System;

namespace Backend.Domain.Models.Queries;

public class RequestQuery
{
    public int Page { get; protected set; }
    public int ItemPerPage { get; protected set; }

    public RequestQuery()
    {
        Page = 1;
        ItemPerPage = 20;
    }

    public RequestQuery(int? page, int? itemPerPage)
    {
        Page = page ?? 1;
        ItemPerPage = itemPerPage ?? 10;

        if (page <= 0)
        {
            Page = 1;
        }
        if (ItemPerPage <= 0)
        {
            ItemPerPage = 10;
        }
    }
}
