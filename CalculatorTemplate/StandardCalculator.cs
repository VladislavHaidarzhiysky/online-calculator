using OnlineCalculator.Check;
using OnlineCalculator.Solutions;

namespace OnlineCalculator.CalculatorTemplate;

internal class StandardCalculator : ICalculator
{
    private readonly IOperation _operation;
    private readonly IRegexExpression _regexExpression;
    public StandardCalculator(IOperation operation, IRegexExpression regexExpression)
    {
        _operation = operation;
        _regexExpression = regexExpression;
    }
    public string ReceivingAnswer(string expression)
    {
        if (!string.IsNullOrEmpty(expression))
        {                                                             
            if (!CheckExpression.CheckForInvalidStatements(expression + "="))
            {
                return "Incorrect data";
            }
            _regexExpression.RegexExp(expression);
            return _operation.Count(_regexExpression.Operands, _regexExpression.Operations).ToString();
        }
        return "String is empty";
    }
}
