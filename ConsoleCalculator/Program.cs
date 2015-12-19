using System;
using Ninject;
using ConsoleCalculator.Abstracts;
using ConsoleCalculator.Operations;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main()
        {
            IKernel ninjectKernel = AddBindings();
            Worker worker = ninjectKernel.Get<Worker>();

            while (true)
            {
                Console.WriteLine("Введите выражение:");           
                string mathExpression = Console.ReadLine();
                if (mathExpression == "q") return;

                decimal answer;
                try
                {
                    answer = worker.Work(mathExpression);
                }
                catch
                {
                    Console.WriteLine("Возникла ошибка. Возможно выражение некорректно.");
                    continue;
                }

                Console.WriteLine("= " + Decimal.Round(answer, 4));
            }
        }

        // Добавляет привязки в Ninject.
        static IKernel AddBindings()
        {
            IKernel ninject = new StandardKernel();

            // В первую очередь выполняются операции с более высоким приоритетом.
            ninject.Bind<IOperation>().To<SumOperation>().WithConstructorArgument("priority", 5); // приоритет 5
            ninject.Bind<IOperation>().To<DifferentOperation>().WithConstructorArgument("priority", 5); 
            ninject.Bind<IOperation>().To<MultiplicationOperation>().WithConstructorArgument("priority", 10); // приоритет 10
            ninject.Bind<IOperation>().To<DivisionOperation>().WithConstructorArgument("priority", 10);

            ninject.Bind<IOpenBracket>().To<OpenBracket>();
            ninject.Bind<ICloseBracket>().To<CloseBracket>();
            ninject.Bind<IResultsRepository>().To<ResultsRepository>();
            ninject.Bind<IBracketRemover>().To<BracketRemover>();
            ninject.Bind<IBracketCounter>().To<BracketCounter>();
            ninject.Bind<IOperationFinder>().To<OperationFinder>();
            ninject.Bind<IOperationCounter>().To<OperationCounter>();
            ninject.Bind<IOperationsPriorities>().To<OperationsPriorities>();
            ninject.Bind<IOperandParser>().To<OperandParser>();
            ninject.Bind<IExpressionExtractent>().To<ExpressionExtractent>();
            ninject.Bind<IExpressionDelimiter>().To<ExpressionDelimiter>();
            ninject.Bind<IPriorityOperationFinder>().To<PriorityOperationFinder>();          
            ninject.Bind<IWhiteSpaceTrimer>().To<WhiteSpaceTrimer>();
            ninject.Bind<ICalculator>().To<Calculator>();

            ninject.Bind<Worker>().ToSelf();
            
            return ninject;
        }
    }
}
