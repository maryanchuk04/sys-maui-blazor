using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_sys_app.Extension;

public static class StringExtension
{
    public static string ReplacePrevious(this string input, string word, string replacement, int startIndex)
    {
        int index = input.LastIndexOf(word, startIndex - 1);
        if (index == -1)
        {
            return input;
        }
        return input.Substring(0, index) + replacement + input.Substring(index + word.Length);
    }

    public static string ReplaceFirstByIndex(this string input, string word, string replacement, int startIndex = 0)
    {
        int index = input.IndexOf(word, startIndex);
        if (index == -1)
        {
            return input;
        }
        return input.Substring(0, index) + replacement + input.Substring(index + word.Length);
    }

    public static string ReplaceFirst(this string text, string search, string replace)
    {
        int pos = text.IndexOf(search);
        if (pos < 0)
        {
            return text;
        }
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }
}
