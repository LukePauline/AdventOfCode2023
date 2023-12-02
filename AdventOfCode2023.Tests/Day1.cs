using Aoc2023 = AdventOfCode2023;

namespace AdventOfCode2023.Tests;
public class Day1 : TestBase<Aoc2023.Day1>
{
    public override string Exercise1TestInput => """
        1abc2
        pqr3stu8vwx
        a1b2c3d4e5f
        treb7uchet
        """;

    public override object Exercise1TestResult => 142;

    public override string Exercise2TestInput => """
        two1nine
        eightwothree
        abcone2threexyz
        xtwone3four
        4nineeightseven2
        zoneight234
        7pqrstsixteen
        """;

    public override object Exercise2TestResult => 281;
}
