using System.Linq;
using System.Numerics;
using System.Text;


namespace Maui_sys_app.Core;

public class Mask
{
    private readonly string _inputMask;

    public Mask(string inputMask)
    {
        _inputMask = inputMask;
    }

    private static string Replace(string subMask)
    {
        var res = "";
        var splitResult = subMask.Split(',').ToList();

        for (var i = 0; i < int.Parse(splitResult[0]); i++)
        {
            res = res.Insert(i, splitResult[1]);
        }

        return res;
    }

    public List<string> GetMask()
    {
        var subMasks = new List<string>();
        var start = -1;
        var end = -1;

        for (var i = 0; i < _inputMask.Length; i++)
        {
            if (_inputMask[i] == '{')
            {
                start = i;
                continue;
            }

            if (_inputMask[i] == '}')
            {
                end = i;
                start++;

                var replaceRes = Replace(_inputMask.Substring(start, end - start));
                subMasks.Add(replaceRes);

                // Set to default value
                end = -1;
                start = -1;

                if (end == _inputMask.Length)
                    break;

                continue;
            }

            if (start != -1)
                continue;

            subMasks.Add(_inputMask[i].ToString());
        }

        return subMasks;
    }

    public List<string> GoodWordsInText(string text)
    {
        
        var words = new List<string>();
        var mask = GetMask();
        var inp = text.Split(" ").ToList();
        for (int i = 0; i < inp.Count; i++)
        {
            if (Comparable.Compare(RefactorInputString(inp[i]), mask))
            {
                words.Add(inp[i]);
            }

        }
        return words;
    }

    static readonly List<char> markArray = new() { '+', '-', '*', '/', '<', '>', '^', '=', '~' };

    static bool IsMark(char symbol)
    {
        for (int i = 0; i < markArray.Count; i++)
        {
            if (symbol == markArray[i])
                return true;
        }
        return false;
    }



    public static List<string> RefactorInputString(string inputStr)
    {
        List<string> res = new();
        string temp = "";

        for (int i = 0; i < inputStr.Length; i++)
        {
            if (IsMark(inputStr[i]))
            {
                if (temp.Length >= 1)
                {
                    if (temp[temp.Length - 1] != inputStr[i])
                    {
                        res.Add(temp);
                        temp = inputStr[i].ToString();
                        continue;
                    }
                }
                temp += inputStr[i].ToString();
                if (i == inputStr.Length - 1)
                    res.Add(temp);
                continue;
            }

            if (temp.Length >= 1)
            {
                res.Add(temp);
                temp = "";
                res.Add(inputStr[i].ToString());
                continue;
            }
            res.Add(inputStr[i].ToString());
        }

        return res;
    }
}
