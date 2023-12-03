namespace AdventOfCode2023;
public class Day3 : IDay
{
    public object Exercise1(string input)
    {
        var grid = ParseInput(input);
        var width = grid[0].Length;

        List<string> partNumbers = new();

        for (int row = 0; row < grid.Length; row++)
        {
            string currNum = "";
            bool isPartNum = false;
            for (int col = 0; col < width; col++)
            {
                var c = grid[row][col];
                if (char.IsNumber(c))
                {
                    currNum += c;

                    if (grid.Neighbours(row, col).Any(x => !char.IsNumber(x.item) && x.item != '.'))
                        isPartNum = true;
                }

                if (col + 1 < width && char.IsNumber(grid[row][col + 1]))
                    continue;

                if (!string.IsNullOrEmpty(currNum) && isPartNum)
                    partNumbers.Add(currNum);

                currNum = "";
                isPartNum = false;

            }
        }
        return partNumbers.Sum(x => int.Parse(x));
    }

    public object Exercise2(string input)
    {
        var grid = ParseInput(input);
        var width = grid[0].Length;
        Dictionary<(int r, int c), HashSet<string>> gearCandidates = new();

        for (int row = 0; row < grid.Length; row++)
        {
            string currNum = "";
            HashSet<(int, int)> asterisks = new();
            for (int col = 0; col < width; col++)
            {
                var c = grid[row][col];
                if (char.IsNumber(c))
                {
                    currNum += c;
                    asterisks.AddRange(grid.Neighbours(row, col).Where(x => x.item == '*').Select(x => (x.i, x.j)));
                }

                if (col + 1 < width && char.IsNumber(grid[row][col + 1]))
                    continue;

                if (!string.IsNullOrEmpty(currNum))
                {
                    foreach (var asterisk in asterisks)
                    {
                        var partNumbers = gearCandidates.ContainsKey(asterisk)
                            ? gearCandidates[asterisk]
                            : new HashSet<string>();
                        partNumbers.Add(currNum);
                        gearCandidates.TryAdd(asterisk, partNumbers);
                    }

                    currNum = "";
                    asterisks = new HashSet<(int, int)>();

                }
            }
        }
        return gearCandidates
            .Where(x => x.Value.Count == 2)
            .Sum(x => int.Parse(x.Value.First()) * int.Parse(x.Value.Last()));
    }


    private char[][] ParseInput(string input) => input
            .SplitByLineBreak(StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.ToCharArray())
            .ToArray();
}

