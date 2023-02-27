using OnlineCalculator.Solutions;
using System.Text.RegularExpressions;

namespace OnlineCalculator;
internal class RegexExpression : IRegexExpression
{
    public List<double> Operands { get; private set; }
    public List<string> Operations { get; private set; }
    public void RegexExp(string expression)
    {
        var regex = new Regex(@"(?:(?<=[/*+-])[-+]?\d*[,]?\d+|(^[-+])?\d*[,]?\d+|[+-/*])");
        var collection = regex.Matches(expression);
        Operands = new List<double>();
        Operations = new List<string>();
        for (var i = 0; i < collection.Count; i += 2)
        {
            Operands.Add(Convert.ToDouble(collection[i].ToString()));
            if (i + 1 < collection.Count)
            {
                Operations.Add(collection[i + 1].ToString());
            }
        }
    }
}
