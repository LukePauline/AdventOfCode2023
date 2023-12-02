namespace AdventOfCode2023.Console;
public static class InputHelpers
{
    public static async Task<string> GetInputFromUrl(int day)
    {
        var sessionCookie = File.ReadAllText("cookie.txt");

        var client = new HttpClient();
        HttpRequestMessage request = new(HttpMethod.Get, $"https://adventofcode.com/2023/day/{day}/input");
        request.Headers.TryAddWithoutValidation("Cookie", $"session={sessionCookie}");
        var response = await client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }
}
