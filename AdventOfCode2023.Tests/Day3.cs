namespace AdventOfCode2023.Tests;
public class Day3 : TestBase<Aoc2023.Day3>
{
    public override string Exercise1TestInput => """
        467..114..
        ...*......
        ..35..633.
        ......#...
        617*......
        .....+.58.
        ..592.....
        ......755.
        ...$.*....
        .664.598..
        """;

    public override object Exercise1TestResult => 4361;

    public override string Exercise2TestInput => Exercise1TestInput;

    public override object Exercise2TestResult => 467835;
}
