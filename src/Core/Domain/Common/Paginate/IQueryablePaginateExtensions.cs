﻿using Microsoft.EntityFrameworkCore;

namespace Domain.Common.Paginate;

public static class IQueryablePaginateExtensions
{
    public static async Task<List<T>> ToPaginateAsync<T>(this IQueryable<T> source, int index, int size,
        int from = 0, CancellationToken cancellationToken = default)
    {
        if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must From <= Index");

        //var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
        var items = await source.Skip((index - from) * size)
            .Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);

        //var list = new Paginate<T>
        //{
        //    Index = index,
        //    Size = size,
        //    From = from,
        //    Count = count,
        //    Items = items,
        //    Pages = (int)Math.Ceiling(count / (double)size)
        //};

        return items;
    }
}