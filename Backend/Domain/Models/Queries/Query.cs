using System;

namespace Backend.Domain.Models.Queries;

public class RequestQuery
{
    public int Page { get; protected set; }
    public int ItemPerPage { get; protected set; }

    public RequestQuery(int page, int itemPerPage)
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
