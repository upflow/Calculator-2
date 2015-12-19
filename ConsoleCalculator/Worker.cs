using System.Linq;
using ConsoleCalculator.Abstracts;
using ConsoleCalculator.Extensions;

namespace ConsoleCalculator
{
    /// <summary>
    /// Главный класс, который непосредственно управляет всей реализацией.
    /// </summary>
    public class Worker
    {
        private readonly IResultsRepository _resultsRepository;
        private readonly IOperationCounter _operationCounter;
        private readonly IWhiteSpaceTrimer _whiteSpaceTrimer;
        private readonly IBracketRemover _bracketRemover;
        private readonly IBracketCounter _bracketCounter;
        private readonly IExpressionExtractent _expressionExtractent;
        private readonly IOperandParser _operandParser;
        private readonly IExpressionDelimiter _expressionDelimiter;
        private readonly ICalculator _calculator;


        public Worker(IResultsRepository resultsRepository,                    
                      IOperationCounter operationCounter,
                      IWhiteSpaceTrimer whiteSpaceTrimer,
                      IBracketRemover bracketRemover,
                      IBracketCounter bracketCounter,
                      IExpressionExtractent expressionExtractent,
                      IOperandParser operandParser,
                      IExpressionDelimiter expressionDelimiter,
                      ICalculator calculator)
        {
            _whiteSpaceTrimer = whiteSpaceTrimer;
            _calculator = calculator;
            _resultsRepository = resultsRepository;
            _operationCounter = operationCounter;
            _bracketRemover = bracketRemover;
            _bracketCounter = bracketCounter;
            _operandParser = operandParser;
            _expressionDelimiter = expressionDelimiter;
            _expressionExtractent = expressionExtractent;
        }


        /// <summary>
        /// Возвращает результат математического выражения в виде строки
        /// формата "#x" (где x индекс массива результатов).
        /// Параметр: математическое вырожение в виде строки. Это вырожение не должно содержать скобки.
        /// </summary>
        /// <param name="expressionText"></param>
        /// <returns></returns>
        private string GetResultForExpression(string expressionText)
        {
            int countOperations = _operationCounter.GetCountOperations(expressionText);

            for (int j = 0; j < countOperations; j++)
            {
                Expression expression = _expressionExtractent.CutFirstExpression(expressionText);
                OperationInfo operationInfo = _expressionDelimiter.Divide(expression.ExpressionText);
                decimal result = _calculator.Calculate(operationInfo);

                _resultsRepository.Add(result);
                string resultForReplace = _operandParser.ParseNumber(result);

                expressionText = expressionText.ReplaceExpression(expression, resultForReplace, false);
            }
            return expressionText;
        }

        /// <summary>
        /// Возвращает результат математического выражения в виде строки
        /// формата "#x" (где x индекс массива результатов).
        /// Принимает матем. выражение. Оно может содержать скобки.
        /// </summary>
        /// <param name="mathExpression"></param>
        /// <returns></returns>
        private void GetAnswer(string mathExpression)
        {
            int countBrackets = _bracketCounter.CountBrackets(mathExpression);
            if (countBrackets != 0)
            {
                for (int i = 0; i < countBrackets; i++)
                {
                    Expression expressionInBrackets = _bracketRemover.GetExpressionInRightBrackets(mathExpression);
                    string expressionText = expressionInBrackets.ExpressionText;
                    expressionText = GetResultForExpression(expressionText);
                    mathExpression = mathExpression.ReplaceExpression(expressionInBrackets, expressionText, true);
                }
            }
            GetResultForExpression(mathExpression);
        }

        /// <summary>
        /// Главные метод, запускающий расчет.
        /// </summary>
        /// <param name="mathExpression"></param>
        /// <returns></returns>
        public decimal Work(string mathExpression)
        {
            mathExpression = _whiteSpaceTrimer.DeleteWhiteSpaces(mathExpression);

            GetAnswer(mathExpression);

            decimal result = _resultsRepository.ResultList.Last();
            _resultsRepository.Clear();

            return result;
        }
    }
}
