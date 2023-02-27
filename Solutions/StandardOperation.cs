using System.Diagnostics;

namespace OnlineCalculator.Solutions;

internal class StandardOperation : IOperation
{
    public double Count(List<double> operands, List<string> operations)
    {
        Func<double, double, double>  function1 = (a, b) => a * b;
        Func<double, double, double>  function2 = (a, b) => a / b;
        string[] operationStr = { "*", "/", "+", "-" };
        for (int iteration = 0, j = 0; iteration < 2; iteration++, j = 2)
        {
            if (iteration == 1)
            {
                function1 = (a, b) => a + b;
                function2 = (a, b) => a - b;
            }
            while (true)
            {
                var currentOperationsIndex1 = operations.IndexOf(operationStr[j]);
                var currentOperationsIndex2 = operations.IndexOf(operationStr[j + 1]);
                int index;
                if (currentOperationsIndex1 >= 0 && currentOperationsIndex2 >= 0)
                {
                    index = Math.Min(currentOperationsIndex1, currentOperationsIndex2);
                }
                else
                {
                    index = Math.Max(currentOperationsIndex1, currentOperationsIndex2);
                }
                if (index < 0)
                {
                    break;
                }
                if (index == currentOperationsIndex1)
                {
                    operands[index] = function1(operands[index], operands[index + 1]);
                }
                else
                {
                    operands[index] = function2(operands[index], operands[index + 1]);
                }
                operations.RemoveAt(index);
                operands.RemoveAt(index + 1);
            }
        }
        return operands[0];
    }
}