using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_sys_app.Core;

public static class WordGenerator
{
    private static readonly List<string> MarkArray = new() { "+", "-", "*", "/", "<", ">", "^", "=", "~" };
    private static readonly Random Random = new();
    public static bool IsMark(string symbol) => MarkArray.Any(t => symbol == t);

    private static string GenerateWord(List<string> subMasks)
    {
        var stringBuilder = new StringBuilder();

        foreach (var item in subMasks)
        {
            switch (item.Length)
            {
                case 1 when !IsMark(item):
                    stringBuilder.Append(item);
                    continue;
                case >= 1:
                    {
                        if (IsMark(item[0].ToString()))
                        {
                            var randomCount = Random.Next(item.Length, Random.Next(item.Length, 10));
                            for (var i = 0; i < randomCount; i++)
                            {
                                stringBuilder.Append(item[0].ToString());
                            }
                        }

                        break;
                    }
            }
        }

        return stringBuilder.ToString();
    }

    public static string GenerateGoodWords(int wordCount, Mask mask)
    {
        var subMasks = mask.GetMask();

        var stringBuilder = new StringBuilder();
        for (var i = 0; i < wordCount; i++)
        {
            stringBuilder.Append($"{GenerateWord(subMasks)} ");
        }

        return stringBuilder.ToString();
    }
}