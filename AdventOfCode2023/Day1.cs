using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023;
public class Day1 : IDay
{
    public object Exercise1(string input)
    {
        var lines = input.SplitByLineBreak(StringSplitOptions.RemoveEmptyEntries);
        var nums = lines.Select(x => x.ToCharArray().Where(char.IsDigit));
        return nums.Sum(x => int.Parse(new string(new[] { x.First(), x.Last() })));
    }

    public object Exercise2(string input)
    {

        IEnumerable<string> lines = input
            .SplitByLineBreak(StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.ReplaceFirstOf(_numbers).ReplaceLastOf(_numbers));
        var nums = lines.Select(x => x.ToCharArray().Where(char.IsDigit));
        return nums.Sum(x => int.Parse(new string(new[] { x.First(), x.Last() })));
    }

    private static readonly Dictionary<string, string> _numbers = new()
    {
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" }
    };
}
