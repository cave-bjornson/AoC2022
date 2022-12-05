using System.Text;

namespace AoC2022;

public class Day03
{
    public void Part01(params string[] input)
    {
        int result = input.Aggregate(0, (i, s) =>
        {
            var halfLength = s.Length / 2;
            var half1 = s.ToCharArray(0, halfLength);
            var half2 = s.ToCharArray(halfLength, halfLength);
            var intersectChar = half1.Intersect(half2).Single();
            return i + GetPriority(intersectChar);
        }, i => i);
        Console.WriteLine(result);
    }

    public void Part02(params string[] input)
    {
        int result = input.Chunk(3).Aggregate(0, (i, s) =>
        {
            var intersectChar = s[0].Intersect(s[1]).Intersect(s[2]).Single();
            return i + GetPriority(intersectChar);
        }, i => i);
        Console.WriteLine(result);
    }

    private int GetPriority(char c)
    {
        return char.ToLower(c) - 'a' + 1 + (char.IsUpper(c) ? 26 : 0);
    }
}