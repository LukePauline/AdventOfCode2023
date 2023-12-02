using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023;
public class Day2 : IDay
{
    public object Exercise1(string input)
    {
        int totalRed = 12;
        int totalGreen = 13;
        int totalBlue = 14;

        var lines = input.SplitByLineBreak(StringSplitOptions.RemoveEmptyEntries);
        var games = lines.Select(x => ParseGame(x));

        return games
            .Where(x => x.maxRed <= totalRed && x.maxGreen <= totalGreen && x.maxBlue <= totalBlue)
            .Sum(x => x.game);
    }

    public object Exercise2(string input)
    {
        var lines = input.SplitByLineBreak(StringSplitOptions.RemoveEmptyEntries);
        var games = lines.Select(x => ParseGame(x));

        return games.Sum(x => x.maxRed * x.maxGreen * x.maxBlue);
    }

    private (int game, int maxRed, int maxGreen, int maxBlue) ParseGame(string input)
    {
        var split = input.Split(':');
        var game = int.Parse(Regex.Match(split[0], @"Game (\d+)").Groups[1].Value);
        var clues = split[1].Split(";");
        List<int> reds = new();
        List<int> greens = new();
        List<int> blues = new();
        foreach (var c in clues)
        {
            var redMatch = Regex.Match(c, @"(\d+) red");
            var greenMatch = Regex.Match(c, @"(\d+) green");
            var blueMatch = Regex.Match(c, @"(\d+) blue");

            if (redMatch.Success)
            {
                var value = int.Parse(redMatch.Groups[1].Value);
                reds.Add(value);
            }

            if (greenMatch.Success)
            {
                var value = int.Parse(greenMatch.Groups[1].Value);
                greens.Add(value);
            }

            if (blueMatch.Success)
            {
                var value = int.Parse(blueMatch.Groups[1].Value);
                blues.Add(value);
            }
        }

        return (game, reds.Max(), greens.Max(), blues.Max());
    }
}
