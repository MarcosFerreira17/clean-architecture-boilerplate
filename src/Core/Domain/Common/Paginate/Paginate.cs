namespace Domain.Common.Paginate;
public class Paginate<T> : IPaginate<T>
{
    internal Paginate(IEnumerable<T> source, int index, int size, int from)
    {
        var enumerable = source as T[] ?? source.ToArray();

        if (from > index)
            throw new ArgumentException($"indexFrom: {from} > pageIndex: {index}, must indexFrom <= pageIndex");
        Size = size;
        Index = index;
        From = from;
        if (source is IQueryable<T> queryable)
        {
            Count = queryable.Count();
            Items = queryable.Skip((Index - From) * Size).Take(Size).ToList();
        }
        else
        {
            Count = enumerable.Length;
            Items = enumerable.Skip((Index - From) * Size).Take(Size).ToList();
        }

        Pages = (int)(Math.Ceiling(Count / (double)Size));
    }

    internal Paginate()
    {
        Items = Array.Empty<T>();
    }

    public int From { get; set; }
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public IList<T> Items { get; set; }
    public bool HasPrevious => Index - From > 1;
    public bool HasNext => Index - From + 1 < Pages;
}


internal class Paginate<TSource, TResult> : IPaginate<TResult>
{
    public Paginate(IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
        int index, int size, int from)
    {
        var enumerable = source as TSource[] ?? source.ToArray();

        if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must From <= Index");
        Index = index;
        Size = size;
        From = from;

        if (source is IQueryable<TSource> queryable)
        {
            Count = queryable.Count();
            var items = queryable.Skip((Index - From) * Size).Take(Size).ToArray();
            Items = new List<TResult>(converter(items));
        }
        else
        {
            Count = enumerable.Count();
            var items = enumerable.Skip((Index - From) * Size).Take(Size).ToArray();
            Items = new List<TResult>(converter(items));
        }
        Pages = (int)Math.Ceiling(Count / (double)Size);
    }


    public Paginate(IPaginate<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
    {
        Index = source.Index;
        Size = source.Size;
        From = source.From;
        Count = source.Count;
        Pages = source.Pages;

        Items = new List<TResult>(converter(source.Items));
    }

    public int Index { get; }

    public int Size { get; }

    public int Count { get; }

    public int Pages { get; }

    public int From { get; }

    public IList<TResult> Items { get; }

    public bool HasPrevious => Index - From > 0;

    public bool HasNext => Index - From + 1 < Pages;
}
