namespace AdventOfCode2023;
public static class GridHelpers
{
    public static IEnumerable<(T item, int i, int j)> Neighbours<T>(this T[][] grid, int i, int j)
    {
        List<(int i, int j)> indices = Enumerable.Range(i - 1, 3).SelectMany(x =>
            Enumerable.Range(j - 1, 3).Select(y => (i: x, j: y))
        ).Aggregate(new List<(int i, int j)>(), (list, ij) =>
        {
            if ((i, j) == ij)
                return list;

            var (x, y) = ij;
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[0].Length)
                return list;

            list.Add((x, y));
            return list;
        }).ToList();

        return indices.Select(x => (grid[x.i][x.j], x.i, x.j));
    }
}
