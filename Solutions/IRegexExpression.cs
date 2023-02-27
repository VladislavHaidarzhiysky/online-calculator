
namespace OnlineCalculator.Solutions
{
    internal interface IRegexExpression
    {
        List<double> Operands { get; }
        List<string> Operations { get; }
        void RegexExp(string expression);
    }
}
