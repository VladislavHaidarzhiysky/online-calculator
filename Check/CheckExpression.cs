using System.Text.RegularExpressions;

namespace OnlineCalculator.Check;

internal static class CheckExpression
{
    public static bool CheckForInvalidStatements(string expression)
    {
        var checkArray = new Regex(@"(?:\d*?\+\+|\d*?//|\d*?--|\d*?\*\*|\d*?\*/|\d*?/\*|\d*?//|\d*?-\*|\d*?-/|\d*?\+\*|\d*?\+/|\d*?-=|\d*?\+=|\d*?/=|\d*?\*=|\d*?,,|\d*?,\+|\d*?,-|\d*?,\*|\d*?,/|^,|\d*?-,|\d*?\+,|\d*?\*,|\d*?/,|\d*?,\d+,)|/0[^,]");
        if (checkArray.IsMatch(expression))
        {
            return false;
        }
        return true;
    }
}
